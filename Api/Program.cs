// .Net6 da Startup dosyasý ortadan kalktý starup dosyasýndaki kodlar program.cs dosyasýna geldi
// ibr þey global ise Program.cs dosyasý içerisine yazmamýz gerekiyor

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

// JwtBearerDefaults.AuthenticationScheme kullanýlarak varsayýlan JWT doðrulama þemasýný ekler ve tüm isteklerin bu JWT token ile doðrulanmasýný gerektirir.
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
// ValidateFilterAttribute deðerini her bir controllessa tek tek eklemek yerine AddControllers(options => options.Filters.Add(new ValidateFilterAttribute()))
// þeklinde ekleye biliriz
// arrow functionlarda eðer tek satýr varsa {} lere ihtiyaç yoktur

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


//bizim bu iþ için kendi filtýr ýmýz var diyoruz
//builder.Services.Configure<ApiBehaviorOptions>(options =>
//{
//    options.SuppressModelStateInvalidFilter = true; //Frame workün kendi dönmüþ olduðu SuppressModelStateInvalidFilter baskýladýk
//});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Cache eklemek istiyorsan aþaðýdaki commenti aç
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

// Filtreleme iþlemlarimizi burada yaptýk
builder.Services.AddScoped(typeof(NotFoundFilter<>)); // Generic olduðu için typeof ile içine giriyorum NotFoundFilter diyoruz generic olduðu içide <> kapadýk


builder.Services.AddAutoMapper(typeof(MapProfile));


builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), options =>
    {
        // SqlConnection'ý Repository de kullandýðýmýz için bunu Repository katmanýna bildiriyoruz
        // options.MigrationsAssembly("Repository"); -> bu tip güvenli deðil yani ilerde repository ismi deðiþtirmem gerekirse burayý da deðiþtirmem gerek
        options.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name); // Tip güvenli hale geldi bu
    });
});

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new RepoServiceModule()));

// Migration oluþturmak için kullanmamýz gereken komutlar
// 1- Package manager Consolu aç 
// 2- Default project: Repository seçili olsun
// solition sað týk properity den API seçili olsun (Microsoft.EntityFrameworkCore.Desig ekli olmasý gerek bunu sadece 1 kere ekliyoruz dbcontext assebly den ayrý bir yerde olduðu için gerekli)
// add-migration initial
// Migration dosyasý oluþturur sonrasýnda
// snapshot dosyasý ile karþýlaþtýrýr (bu öndceden add-migration dediðmizde snapshot alýr sonra eklenen table sütunu varsa bulup ekler)
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
app.UseAuthorization(); // bir request geldiðinde token doðrulamasý bu midleware de gerçekleþir
app.UseHttpsRedirection(); // https yönledirmesi
app.UseMiddleware<LowercaseResponseMiddleware>();
app.UseCustomException(); // bu bizim eklediðimiz hata katmaný bu hata katmanýnýn üst tarafta olmasý önemli
app.UseIpRateLimiting();
app.MapControllers();
app.Run();
