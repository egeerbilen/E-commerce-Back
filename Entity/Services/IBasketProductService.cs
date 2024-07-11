using Core.DTOs;

namespace Entity.Services
{
    public interface IBasketProductService
    {
        Task<CustomResponseDto<bool>> IsBasketProductAsync(int userId, int productId);
        Task<CustomResponseDto<List<ProductDto>>> GetBasketProductsByIdAsync(int userId);
        Task<CustomResponseDto<NoContentDto>> CreateBasketProductAsync(BasketProductDto basket);
        Task<CustomResponseDto<NoContentDto>> DeleteUserBasketProductAsync(int userId, int productId);
    }
}
