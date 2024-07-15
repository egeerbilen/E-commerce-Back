
using Core.Repositories;
using Entity.Model;

namespace Entity.Repositories
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<List<int>> SaveAndReturnIdsAsync(List<Order> orders);
    }
}
