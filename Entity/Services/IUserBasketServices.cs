using Core.DTOs;
using Entity.DTOs;

namespace Entity.Services
{
    public interface IUserBasketServices
    {
        Task<CustomResponseDto<NoContentDto>> CreateUserBasketProductsAsync(UserBasketsDto userFavoritesProducts);
        Task<CustomResponseDto<NoContentDto>> DeleteUserBasketProductsAsync(int userId, int productId);
    }
}
