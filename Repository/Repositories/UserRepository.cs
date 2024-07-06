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

        public async Task<User> FindUserByEmailWithUserRoles(UserLoginRequestDto dto)
        {
            return await _context.Users.Include(x => x.UserRoles).Where(x => x.Email == dto.Email).SingleOrDefaultAsync();
        }
    }
}
