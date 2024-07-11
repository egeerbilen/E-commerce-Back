using Core.DTOs;
using Entity.Repositories;
using Entity.Services;

namespace Bussines.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository _userRoleRepository;

        public UserRoleService(IUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }

        public async Task<CustomResponseDto<bool>> AddUserRoleAsync(int userId, int roleId)
        {
            // eğer eynısından varsa patlar ilgili koşul yazılmalı aynı şeyi eklerse yada olmayan bir role ile user varsa vs.
            var result = await _userRoleRepository.AddUserRoleAsync(userId, roleId);
            if (result)
            {
                return CustomResponseDto<bool>.Success(200, true);
            }
            return CustomResponseDto<bool>.Fail(400, "Failed to add UserRole");
        }

        public async Task<CustomResponseDto<bool>> RemoveUserRoleAsync(int userId, int roleId)
        {
            // eğer eynısından varsa patlar ilgili koşul yazılmalı aynı şeyi eklerse yada olmayan bir role ile user varsa vs.
            var result = await _userRoleRepository.RemoveUserRoleAsync(userId, roleId);
            if (result)
            {
                return CustomResponseDto<bool>.Success(200, true);
            }
            return CustomResponseDto<bool>.Fail(400, "Failed to remove UserRole");
        }
    }
}
