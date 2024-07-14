
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
    }
}
