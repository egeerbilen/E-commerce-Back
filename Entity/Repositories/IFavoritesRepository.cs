using Core.DTOs;
using Entity.DTOs;
using Entity.Model;

namespace Entity.Repositories
{
    public interface IFavoritesRepository
    {
        Task<List<Product>> GetUserFavoritesById(int userId);
        Task<Favorites> CreateUserFavoriteProductsAsync(Favorites favorites);
        Task<bool> DeleteUserFavoriteProductsAsync(int userId, int productId);
    }
}
