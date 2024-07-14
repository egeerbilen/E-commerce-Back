using Core.DTOs;
using Entity.Model;

namespace Entity.Repositories
{
    public interface IBasketProductRepository
    {
        Task<bool> IsProductInBasketAsync(int basketId, int productId);
        Task<List<Product>> GetProductsByBasketIdAsync(int basketId);
        Task<List<BasketProduct>> GetBasketIdsByProductIdAsync(int basketId);
        Task AddProductToBasketAsync(BasketProduct basket);
        Task<bool> RemoveProductFromBasketAsync(int basketId, int productId);
        Task UpdateBasketIdsByProductIdAsync(BasketProduct basket);
    }
}
