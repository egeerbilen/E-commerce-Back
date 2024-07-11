using Entity.Model;

namespace Entity.Repositories
{
    public interface IBasketProductRepository
    {
        Task<bool> IsBasketProductAsync(int basketId, int productId);
        Task<List<Product>> GetUserBasketsByIdAsync(int basketId);
        Task CreateBasketProductAsync(BasketProduct basket);
        Task<bool> DeleteBasketProductAsync(int basketId, int productId);
    }
}
