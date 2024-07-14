using Core.DTOs;
using Entity.Model;

namespace Entity.Repositories
{
    public interface IOrderProductRepository
    {
        Task<NoContentDto> CreateOrderProductAsync(List<OrderProduct> orderProducts);
        Task<List<Order>> GetUserOrderProductsAsync(int userId);
        Task<List<Product>> GetOrderProductsAsync(int orderId);
    }
}
