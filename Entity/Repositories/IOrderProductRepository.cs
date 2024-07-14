using Core.DTOs;
using Core.Repositories;
using Entity.Model;

namespace Entity.Repositories
{
    public interface IOrderProductRepository : IGenericRepository<OrderProduct>
    {
        Task<NoContentDto> CreateOrderProductAsync(List<OrderProduct> orderProducts);
        Task<List<Order>> GetUserOrderProductsAsync(int userId);
        Task<List<Product>> GetOrderProductsAsync(int orderId);
    }
}
