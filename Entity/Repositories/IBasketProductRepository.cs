using Core.DTOs;
using Entity.Model;

namespace Entity.Repositories
{
    public interface IBasketProductRepository
    {
        Task<BasketProduct> IsProductInBasketAsync(int basketId, int productId);
        Task<List<Product>> GetProductsByBasketIdAsync(int basketId);
        Task<List<BasketProduct>> GetBasketIdsByProductIdAsync(int basketId);
        Task AddProductToBasketAsync(BasketProduct basket);
        Task UpdateBasketIdsByProductIdAsync(BasketProduct basket);
    }
}
