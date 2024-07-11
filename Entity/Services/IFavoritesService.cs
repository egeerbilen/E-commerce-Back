using Core.DTOs;
using Entity.DTOs;
using Entity.Model;

namespace Entity.Services
{
    // generic servisi kaldır IGenericService buna gerek yok ya da override et buna conroller da yazman gerekecek çümkü sen burada favorite ye erişiyorsun senin [UserFavorites] tablosuna erişmen gerek generin yapmasan da olur
    public interface IFavoritesService
    {
        Task<CustomResponseDto<bool>> IsFavoriteAsync(int userId, int productId);
        Task<CustomResponseDto<List<ProductDto>>> GetFavoritesByUserIdAsync(int userId);
        Task<CustomResponseDto<NoContentDto>> CreateFavoriteAsync(FavoritesDto favorites);
        Task<CustomResponseDto<NoContentDto>> DeleteFavoriteAsync(int userId, int productId);

    }
}
