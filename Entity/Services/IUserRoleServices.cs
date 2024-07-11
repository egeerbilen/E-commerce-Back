using Core.DTOs;

namespace Entity.Services
{
    public interface IUserRoleServices
    {
        Task<CustomResponseDto<bool>> AddUserRoleAsync(int basketId, int productId);
        Task<CustomResponseDto<bool>> RemoveUserRoleAsync(int basketId, int productId);
    }
}
