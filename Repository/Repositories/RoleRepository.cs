using Entity.Model;
using Entity.Repositories;
using Repository;
using Repository.Repositories;

namespace DataAccess.Repositories
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(AppDbContext context) : base(context)
        {
        }
    }
}
