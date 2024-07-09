using Core.DTOs;
using Core.Model;
using Core.Repositories;
using Entity.Model;

namespace NLayer.Core.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<List<Product>> GetProductsWitCategoryAsync(); // Task ile async bir işlem olacakğını belirttik
        Task<List<Product>> GetUserProducts(int userId);
    }
}
