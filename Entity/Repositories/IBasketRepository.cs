using Entity.Model;

namespace Entity.Repositories
{
    public interface IBasketRepository
    {
        Task<bool> IsBasketProduct(int userId, int productId);
        Task<List<Product>> GetUserBasketsById(int userId);
        Task<Basket> CreateUserBasketProductsAsync(Basket basket);
        Task<bool> DeleteUserBasketProductsAsync(int userId, int productId);
    }
}
