
using Entity.Model;
using Entity.Repositories;
using Repository;
using Repository.Repositories;

namespace DataAccess.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<int>> SaveAndReturnIdsAsync(List<Order> orders)
        {
            await _context.Set<Order>().AddRangeAsync(orders);
            await _context.SaveChangesAsync();
            return orders.Select(order => order.Id).ToList();
        }
    }
}
