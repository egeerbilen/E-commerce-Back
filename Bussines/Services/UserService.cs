using AutoMapper;
using Core;
using Core.DTOs;
using Core.Repositories;
using Core.UnitOfWorks;
using DataAccess.Repositories;
using Entity.DTOs;
using Entity.Model;
using Entity.Repositories;
using Entity.Services;
using JwtInDotnetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NLayer.Core.Repositories;
using Service.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Bussines.Services
{
    public class UserService : GenericService<User, UserDto>, IUserService
    {
        private IConfiguration _config;
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;
        private readonly IBasketRepository _basketRepository;
        private readonly IFavoritesRepository _favoritesRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRoleRepository _userRoleRepository;
        public UserService(IGenericRepository<User> repository, IRoleRepository roleRepository, IConfiguration config, IFavoritesRepository favoritesRepository, IBasketRepository basketRepository,
                           IUserRoleRepository userRoleRepository, IUnitOfWork unitOfWork, IMapper mapper, IUserRepository userRepository, IProductRepository productRepository) : base(repository, unitOfWork, mapper)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _basketRepository = basketRepository;
            _favoritesRepository = favoritesRepository;
            _productRepository = productRepository;
            _userRoleRepository = userRoleRepository;
            _config = config;
        }

        public async Task<CustomResponseDto<BaseDto>> AddUserAsync(UserCreateDto dto)
        {
            var userLoginDto = _mapper.Map<UserLoginRequestDto>(dto);
            var user = await _userRepository.FindUserByEmailWithRolesAsync(userLoginDto);

            if (user != null)
            {
                return CustomResponseDto<BaseDto>.Fail(StatusCodes.Status400BadRequest, "Email is available in system");
            }

            dto.Password = PasswordHelper.HashPassword(dto.Password);
            var newEntity = _mapper.Map<User>(dto);
            await _userRepository.AddAsync(newEntity);
            await _unitOfWork.CommitAsync();
            await _userRoleRepository.AddUserRoleAsync(newEntity.Id, 6); // 4 read yetkisi şuanlık statik ileride bir dosya yapılıp oradan alınır seed e de ordan yazdırır sın
            await _unitOfWork.CommitAsync();
            var newDto = _mapper.Map<BaseDto>(newEntity);
            return CustomResponseDto<BaseDto>.Success(StatusCodes.Status200OK, newDto);
        }

        public async Task<CustomResponseDto<NoContentDto>> UpdateUserAsync(UserUpdateDto dto)
        {
            dto.Password = PasswordHelper.HashPassword(dto.Password);
            var entity = _mapper.Map<User>(dto);
            _userRepository.Update(entity);
            await _unitOfWork.CommitAsync();
            return CustomResponseDto<NoContentDto>.Success(StatusCodes.Status200OK);
        }

        public async Task<CustomResponseDto<NoContentDto>> DeleteUserWithDependenciesAsync(int userId)
        {
            var entity = await _userRepository.GetByIdAsync(userId);
            // id değeri zaten midle varede kontrol ediliyor o yüzden burada kontrole gerek yok
            //if (entity == null)
            //{
            //    return CustomResponseDto<NoContentDto>.Fail(StatusCodes.Status404NotFound, "User not found");
            //}
            // user silindiğinde favorileri ve basketleri silmedim bilerek vazgeçme süresü kona
            // bilir ki kullanıcı vazgeçerse favoriler ve basketler dursun
            var userProducts = await _productRepository.GetProductsByUserIdAsync(userId);
            _productRepository.RemoveRange(userProducts);
            await _unitOfWork.CommitAsync();

            _userRepository.Remove(entity);
            await _unitOfWork.CommitAsync();

            return CustomResponseDto<NoContentDto>.Success(StatusCodes.Status200OK);
        }

        public async Task<CustomResponseDto<string>> GenerateJwtTokenAsync(UserLoginRequestDto dto)
        {
            var user = await _userRepository.FindUserByEmailWithRolesAsync(dto);
            var basket = await _basketRepository.GetByIdAsync(user.Id);

            if (user == null || PasswordHelper.HashPassword(dto.Password) != user.Password)
            {
                return CustomResponseDto<string>.Fail(StatusCodes.Status403Forbidden, "Email or Password is not correct");
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim("email", user.Email),
                new Claim("firstName", user.FirstName),
                new Claim("lastName", user.LastName),
                new Claim("userId", user.Id.ToString()),
                new Claim("basketId", basket.Id.ToString())
            };

            foreach (var userRole in user.UserRoles)
            {
                var role = await _roleRepository.GetByIdAsync(userRole.RoleId);
                claims.Add(new Claim("roles", role.RoleName));
            }

            var Sectoken = new JwtSecurityToken(
              _config["Jwt:Issuer"], // issuer tokeni oluşturan veya yayınlayan tarafı tanımlar. Bu, JWT'nin güvenilirliğini
                                     // sağlamak için önemlidir çünkü doğru
                                     // bir şekilde tanımlanmış bir "issuer" alanı, tokeni oluşturan veya yayınlayanın kim olduğunu belirtir.
              _config["Jwt:Issuer"], // audience  tokenin hedef alındığı alıcıları temsil eder. Yani, tokenin hangi uygulamaya veya
                                     // servise gönderildiğini belirtir.
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);

            return CustomResponseDto<string>.Success(StatusCodes.Status200OK, token);
        }
    }
}
