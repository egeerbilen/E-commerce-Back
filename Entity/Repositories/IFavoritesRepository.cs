using Core.DTOs;
using Entity.DTOs;
using Entity.Model;

namespace Entity.Repositories
{
    public interface IFavoritesRepository
    {
        Task<bool> IsFavoriteAsync(int userId, int productId);
        Task<List<Product>> GetFavoritesByUserIdAsync(int userId);
        Task<Favorite> CreateFavoriteAsync(Favorite favorites);
        Task<bool> DeleteFavoriteAsync(int userId, int productId);
        Task<List<Favorite>> GetFavoritesByProductIdAsync(int productId);
    }
}
