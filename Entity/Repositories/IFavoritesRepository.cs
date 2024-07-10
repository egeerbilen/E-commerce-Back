using Core.DTOs;
using Entity.DTOs;
using Entity.Model;

namespace Entity.Repositories
{
    public interface IFavoritesRepository
    {
        Task<bool> IsFavoriteProduct(int userId, int productId);
        Task<List<Product>> GetUserFavoritesById(int userId);
        Task<Favorite> CreateUserFavoriteProductsAsync(Favorite favorites);
        Task<bool> DeleteUserFavoriteProductsAsync(int userId, int productId);
    }
}
