using AutoMapper;
using Core;
using Core.DTOs;
using Core.Repositories;
using Core.UnitOfWorks;
using Entity.DTOs;
using Entity.Model;
using Entity.Repositories;
using Entity.Services;
using JwtInDotnetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Service.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Bussines.Services
{
    public class UserService : GenericService<User, UserDto>, IUserServices
    {
        private IConfiguration _config;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        public UserService(IGenericRepository<User> repository, IRoleRepository roleRepository, IConfiguration config, IUnitOfWork unitOfWork, IMapper mapper, IUserRepository userRepository) : base(repository, unitOfWork, mapper)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _config = config;
        }

        public async Task<CustomResponseDto<BaseDto>> AddAsync(UserCreateDto dto)
        {
            dto.Password = PasswordHelper.HashPassword(dto.Password);
            var newEntity = _mapper.Map<User>(dto);
            await _userRepository.AddAsync(newEntity);
            await _unitOfWork.CommitAsync();
            var newDto = _mapper.Map<BaseDto>(newEntity);
            return CustomResponseDto<BaseDto>.Success(StatusCodes.Status200OK, newDto);
        }

        public async Task<CustomResponseDto<NoContentDto>> UpdateAsync(UserUpdateDto dto)
        {
            dto.Password = PasswordHelper.HashPassword(dto.Password);
            var entity = _mapper.Map<User>(dto);
            _userRepository.Update(entity);
            await _unitOfWork.CommitAsync();
            return CustomResponseDto<NoContentDto>.Success(StatusCodes.Status200OK);
        }

        public async Task<CustomResponseDto<string>> createJwtToken(UserLoginRequestDto dto)
        {
            var user = await _userRepository.FindUserByEmailWithUserRoles(dto);

            if (user == null || PasswordHelper.HashPassword(dto.Password) != user.Password)
            {
                return CustomResponseDto<string>.Fail(StatusCodes.Status401Unauthorized, "Email or Password is not correct");
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim("email", user.Email),
                new Claim("firstName", user.FirstName),
                new Claim("lastName", user.LastName),
                new Claim("userId", user.Id.ToString())
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
