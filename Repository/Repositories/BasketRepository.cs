

using Entity.Model;
using Entity.Repositories;
using Repository;
using Repository.Repositories;

namespace DataAccess.Repositories
{
    public class BasketRepository : GenericRepository<Basket>, IBasketRepository
    {
        public BasketRepository(AppDbContext context) : base(context)
        {
        }
    }
}
