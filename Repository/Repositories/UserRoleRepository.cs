using Entity.Model;
using Entity.Repositories;
using Microsoft.EntityFrameworkCore;
using Repository;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UserRoleRepository : IUserRoleRepository
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<UserRole> _dbSet;

        public UserRoleRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<UserRole>();
        }

        public async Task<bool> AddUserRoleAsync(int userId, int roleId)
        {
            var userRole = new UserRole
            {
                UserId = userId,
                RoleId = roleId
            };

            await _dbSet.AddAsync(userRole);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> RemoveUserRoleAsync(int userId, int roleId)
        {
            var userRole = await _dbSet.FirstOrDefaultAsync(ur => ur.UserId == userId && ur.RoleId == roleId);

            if (userRole == null)
                return false;

            _dbSet.Remove(userRole);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
