using Core.DTOs;
using Entity.DTOs;
using Entity.Model;

namespace Entity.Services
{
    // generic servisi kaldır IGenericService buna gerek yok ya da override et buna conroller da yazman gerekecek çümkü sen burada favorite ye erişiyorsun senin [UserFavorites] tablosuna erişmen gerek generin yapmasan da olur
    public interface IUserFavoritesProductsService
    {
        Task<CustomResponseDto<List<ProductDto>>> GetUserFavoritesById(int userId);
        Task<CustomResponseDto<NoContentDto>> CreateUserFavoriteProductsAsync(UserFavoritesProductsDto userFavoritesProducts);
        Task<CustomResponseDto<NoContentDto>> DeleteUserFavoriteProductsAsync(int userId, int productId);

    }
}
