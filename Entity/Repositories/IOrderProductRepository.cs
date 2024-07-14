using Core.DTOs;
using Entity.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Entity.Repositories
{
    public interface IOrderProductRepository
    {
        Task<NoContentDto> CreateOrderProductAsync(List<OrderProduct> orderProducts);
        Task<List<Product>> GetUserOrders(int userId);
    }
}
