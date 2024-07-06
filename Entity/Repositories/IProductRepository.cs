using Core.Model;
using Core.Repositories;
using Entity.Model;

namespace NLayer.Core.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<List<Product>> GetProductsWitCategoryAsync(); // Task ile async bir işlem olacakğını belirttik
        Task<Product> GetProductByIdWithProductDetailsAsync(int productId); // Task ile async bir işlem olacakğını belirttik
    }
}
