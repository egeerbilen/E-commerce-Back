using Entity.Model;

namespace Entity.Repositories
{
    public interface IBasketRepository
    {
        Task<bool> IsBasketProductAsync(int userId, int productId);
        Task<List<Product>> GetUserBasketsByIdAsync(int userId);
        Task<Basket> CreateUserBasketProductAsync(Basket basket);
        Task<bool> DeleteUserBasketProductAsync(int userId, int productId);
    }
}
