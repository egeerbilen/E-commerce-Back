using Core.DTOs;
using Entity.Model;
using Entity.Repositories;
using JwtInDotnetCore;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Repositories;

namespace DataAccess.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<User> FindUserByEmailWithRolesAsync(UserLoginRequestDto dto)
        {
            return await _context.Users.Include(x => x.UserRoles).Where(x => x.Email == dto.Email && !x.IsDeleted).AsNoTracking().SingleOrDefaultAsync();
        }

        public async Task<List<User>> GetAllUsersWithRolesAsync()
        {
            return await _context.Users.Include(x => x.UserRoles).ThenInclude(ur => ur.Role).AsNoTracking().Where(u => !u.IsDeleted).ToListAsync();
        }

    }
}
