using Core.DTOs;
using Core.Repositories;
using Entity.Model;
using JwtInDotnetCore;

namespace Entity.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> FindUserByEmailWithRolesAsync(UserLoginRequestDto dto); 
        Task<List<User>> GetAllUsersWithRolesAsync();

    }
}
