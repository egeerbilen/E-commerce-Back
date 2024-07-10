using Core.DTOs;
using Entity.DTOs;
using Entity.Model;

namespace Entity.Services
{
    // generic servisi kaldır IGenericService buna gerek yok ya da override et buna conroller da yazman gerekecek çümkü sen burada favorite ye erişiyorsun senin [UserFavorites] tablosuna erişmen gerek generin yapmasan da olur
    public interface IFavoritesService : IGenericManyToManyService<Favorite, FavoritesDto>
    {
        Task<CustomResponseDto<List<Favorite>>> GetFavoritesByUserIdAsync(int userId, string propertyName);
        //Task<CustomResponseDto<bool>> IsFavoriteProductAsync(int userId, int productId);
        //Task<CustomResponseDto<List<ProductDto>>> GetUserFavoritesByIdAsync(int userId);
        //Task<CustomResponseDto<NoContentDto>> CreateUserFavoriteProductAsync(FavoritesDto favorites);
        //Task<CustomResponseDto<NoContentDto>> DeleteUserFavoriteProductAsync(int userId, int productId);

    }
}
