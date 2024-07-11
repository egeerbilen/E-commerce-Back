using Core.DTOs;

namespace Entity.Services
{
    public interface IUserRoleService
    {
        Task<CustomResponseDto<bool>> AddUserRoleAsync(int basketId, int productId);
        Task<CustomResponseDto<bool>> RemoveUserRoleAsync(int basketId, int productId);
    }
}
