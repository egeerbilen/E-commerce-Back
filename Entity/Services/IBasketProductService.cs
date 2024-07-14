using Core.DTOs;
using Entity.Model;

namespace Entity.Services
{
    public interface IBasketProductService
    {
        Task<CustomResponseDto<bool>> IsProductInBasketAsync(int basketId, int productId);
        Task<CustomResponseDto<List<ProductDto>>> GetProductsByBasketIdAsync(int basketId);
        Task<CustomResponseDto<NoContentDto>> AddProductToBasketAsync(BasketProductDto basket);
        Task<CustomResponseDto<NoContentDto>> RemoveProductFromBasketAsync(int basketId, int productId);
        Task<CustomResponseDto<NoContentDto>> UpdateBasketIdsByProductIdAsync(BasketProductDto basket);
    }
}
