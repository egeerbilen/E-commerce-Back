

using Core.DTOs;
using Entity.DTOs;

namespace Entity.Services
{
    public interface IBasketProductService
    {
        Task<CustomResponseDto<bool>> IsBasketProductAsync(int userId, int productId);
        Task<CustomResponseDto<List<ProductDto>>> GetUserBasketsByIdAsync(int userId);
        Task<CustomResponseDto<NoContentDto>> CreateUserBasketProductAsync(BasketDto basket);
        Task<CustomResponseDto<NoContentDto>> DeleteUserBasketProductAsync(int userId, int productId);
    }
}
