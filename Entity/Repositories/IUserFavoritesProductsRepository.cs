using Core.DTOs;
using Entity.DTOs;
using Entity.Model;

namespace Entity.Repositories
{
    public interface IUserFavoritesProductsRepository
    {
        Task<List<UserFavoritesProducts>> GetUserFavoritesById(int userId);
        Task<UserFavoritesProducts> CreateUserFavoriteProductsAsync(UserFavoritesProducts userFavoritesProducts);
        Task<bool> DeleteUserFavoriteProductsAsync(int userId, int productId);
    }
}
