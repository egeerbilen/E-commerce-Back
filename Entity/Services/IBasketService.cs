using Core.DTOs;
using Entity.DTOs;

namespace Entity.Services
{
    public interface IBasketService
    {
        Task<CustomResponseDto<bool>> IsBasketProduct(int userId, int productId);
        Task<CustomResponseDto<List<ProductDto>>> GetUserBasketsById(int userId);
        Task<CustomResponseDto<NoContentDto>> CreateUserBasketProductAsync(BasketDto basket);
        Task<CustomResponseDto<NoContentDto>> DeleteUserBasketProductAsync(int userId, int productId);
    }
}
