using Core.DTOs;
using Core.Services;
using Entity.DTOs;
using Entity.Model;
using JwtInDotnetCore;

namespace Entity.Services
{
    public interface IUserService : IGenericService<User, UserDto>
    {
        Task<CustomResponseDto<List<UserWithRolesDto>>> GetAllUsersWithRolesAsync();
        Task<CustomResponseDto<NoContentDto>> DeleteUserWithDependenciesAsync(int id);
        Task<CustomResponseDto<BaseDto>> AddUserAsync(UserCreateDto dto);
        Task<CustomResponseDto<string>> GenerateJwtTokenAsync(UserLoginRequestDto dto);
        Task<CustomResponseDto<NoContentDto>> UpdateUserAsync(UserUpdateDto dto);
    }
}
