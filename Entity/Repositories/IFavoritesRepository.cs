using Core.DTOs;
using Entity.DTOs;
using Entity.Model;

namespace Entity.Repositories
{
    public interface IFavoritesRepository
    {
        Task<List<Favorite>> GetFavoritesByUserIdAsync(int userId, string propertyName);
        //Task<bool> IsFavoriteProductAsync(int userId, int productId);
        //Task<List<Product>> GetUserFavoritesByIdAsync(int userId);
        //Task<Favorite> CreateUserFavoriteProductAsync(Favorite favorites);
        //Task<bool> DeleteUserFavoriteProductAsync(int userId, int productId);
    }
}
