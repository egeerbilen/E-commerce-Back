// .Net6 da Startup dosyas� ortadan kalkt� starup dosyas�ndaki kodlar program.cs dosyas�na geldi
// ibr �ey global ise Program.cs dosyas� i�erisine yazmam�z gerekiyor

using AspNetCoreRateLimit;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Bussines.Validations;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NLayer.API.Filters;
using NLayer.API.Middlewares;
using NLayer.API.Modules;
using NLayer.Service.Validations;
using Repository;
using Serilog;
using Service.Mapping;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//Jwt configuration starts here
var jwtIssuer = builder.Configuration.GetSection("Jwt:Issuer").Get<string>();
var jwtKey = builder.Configuration.GetSection("Jwt:Key").Get<string>();

if (string.IsNullOrEmpty(jwtIssuer) || string.IsNullOrEmpty(jwtKey))
{
    throw new Exception("JWT Issuer or Key is not configured properly.");
}

// JwtBearerDefaults.AuthenticationScheme kullan�larak varsay�lan JWT do�rulama �emas�n� ekler ve t�m isteklerin bu JWT token ile do�rulanmas�n� gerektirir.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
 .AddJwtBearer(options =>
 {
     options.TokenValidationParameters = new TokenValidationParameters
     {
         ValidateIssuer = true,
         ValidateAudience = true,
         ValidateLifetime = true,
         ValidateIssuerSigningKey = true,
         ValidIssuer = jwtIssuer,
         ValidAudience = jwtIssuer,
         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
     };
 });
//Jwt configuration ends here

IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();

//LoggerConfiguration
Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();

builder.Host.UseSerilog();

// Add services to the container.
// ValidateFilterAttribute de�erini her bir controllessa tek tek eklemek yerine AddControllers(options => options.Filters.Add(new ValidateFilterAttribute()))
// �eklinde ekleye biliriz
// arrow functionlarda e�er tek sat�r varsa {} lere ihtiya� yoktur

builder.Services.AddControllers(options => options.Filters.Add(new ValidateFilterAttribute()))
    .AddFluentValidation(x =>
    {
        x.RegisterValidatorsFromAssemblyContaining<ProductCreateDtoValidator>();
        x.RegisterValidatorsFromAssemblyContaining<UserCreateDtoValidator>();
        x.RegisterValidatorsFromAssemblyContaining<UserUpdateDtoValidator>();
        x.RegisterValidatorsFromAssemblyContaining<CategoryCreateDtoValidator>();
        x.RegisterValidatorsFromAssemblyContaining<UserLoginRequestValidator>();
    });

builder.Services.AddAuthorization();

// CORS configuration starts here
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", builder =>
    {
        builder.WithOrigins("http://localhost:4200")
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});
// CORS configuration ends here


//bizim bu i� i�in kendi filt�r �m�z var diyoruz
//builder.Services.Configure<ApiBehaviorOptions>(options =>
//{
//    options.SuppressModelStateInvalidFilter = true; //Frame work�n kendi d�nm�� oldu�u SuppressModelStateInvalidFilter bask�lad�k
//});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Cache eklemek istiyorsan a�a��daki commenti a�
builder.Services.AddMemoryCache();


// Configure Rate Limiting
builder.Services.Configure<IpRateLimitOptions>(options =>
{
    options.EnableEndpointRateLimiting = true;
    options.StackBlockedRequests = false;
    options.HttpStatusCode = 429;
    options.RealIpHeader = "X-Real-IP";
    options.ClientIdHeader = "X-ClientId";
    options.GeneralRules = new List<RateLimitRule>
    {
        new RateLimitRule
        {
            Endpoint = "*",
            Period = "20s",
            Limit = 20
        }
    };
});

builder.Services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
builder.Services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
builder.Services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();
builder.Services.AddInMemoryRateLimiting();

// Filtreleme i�lemlarimizi burada yapt�k
builder.Services.AddScoped(typeof(NotFoundFilter<>)); // Generic oldu�u i�in typeof ile i�ine giriyorum NotFoundFilter diyoruz generic oldu�u i�ide <> kapad�k


builder.Services.AddAutoMapper(typeof(MapProfile));


builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), options =>
    {
        // SqlConnection'� Repository de kulland���m�z i�in bunu Repository katman�na bildiriyoruz
        // options.MigrationsAssembly("Repository"); -> bu tip g�venli de�il yani ilerde repository ismi de�i�tirmem gerekirse buray� da de�i�tirmem gerek
        options.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name); // Tip g�venli hale geldi bu
    });
});

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new RepoServiceModule()));

// Migration olu�turmak i�in kullanmam�z gereken komutlar
// 1- Package manager Consolu a� 
// 2- Default project: Repository se�ili olsun
// solition sa� t�k properity den API se�ili olsun (Microsoft.EntityFrameworkCore.Desig ekli olmas� gerek bunu sadece 1 kere ekliyoruz dbcontext assebly den ayr� bir yerde oldu�u i�in gerekli)
// add-migration initial
// Migration dosyas� olu�turur sonras�nda
// snapshot dosyas� ile kar��la�t�r�r (bu �ndceden add-migration dedi�mizde snapshot al�r sonra eklenen table s�tunu varsa bulup ekler)
// update-database
// Drop-Database ->table sil


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigin");
app.UseAuthorization(); // bir request geldi�inde token do�rulamas� bu midleware de ger�ekle�ir
app.UseHttpsRedirection(); // https y�nledirmesi
app.UseMiddleware<LowercaseResponseMiddleware>();
app.UseCustomException(); // bu bizim ekledi�imiz hata katman� bu hata katman�n�n �st tarafta olmas� �nemli
app.UseIpRateLimiting();
app.MapControllers();
app.Run();
