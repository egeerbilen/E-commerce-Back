using Core.DTOs;
using Core.Services;
using Entity.DTOs;
using Entity.Model;
using JwtInDotnetCore;

namespace Entity.Services
{
    public interface IUserServices : IGenericService<User, UserDto>
    {
        Task<CustomResponseDto<NoContentDto>> RemoveUserAsync(int id);
        Task<CustomResponseDto<BaseDto>> AddAsync(UserCreateDto dto);
        Task<CustomResponseDto<string>> createJwtToken(UserLoginRequestDto dto);
        Task<CustomResponseDto<NoContentDto>> UpdateAsync(UserUpdateDto dto);
    }
}
