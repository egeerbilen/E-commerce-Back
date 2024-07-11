using Entity.Model;

namespace Entity.Repositories
{
    public interface IBasketProductRepository
    {
        Task<bool> IsBasketProductAsync(int userId, int productId);
        Task<List<Product>> GetUserBasketsByIdAsync(int userId);
        Task CreateBasketProductAsync(BasketProduct basket);
        Task<bool> DeleteBasketProductAsync(int userId, int productId);
    }
}
