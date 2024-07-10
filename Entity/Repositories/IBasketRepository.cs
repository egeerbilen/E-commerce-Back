using Entity.Model;

namespace Entity.Repositories
{
    public interface IBasketRepository
    {
        Task<bool> IsBasketProduct(int userId, int productId);
        Task<List<Product>> GetUserBasketsById(int userId);
        Task<Basket> CreateUserBasketProductAsync(Basket basket);
        Task<bool> DeleteUserBasketProductAsync(int userId, int productId);
    }
}
