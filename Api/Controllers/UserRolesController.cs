using API.Controllers;
using Entity.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize(Roles = "SuperUser")]
    public class UserRolesController : CustomBaseController
    {
        private readonly IUserRoleService _userRoleService;

        public UserRolesController(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }

        [HttpPost("userId/{userId}/roleId/{roleId}")]
        public async Task<IActionResult> AddUserRoleAsync(int userId, int roleId)
        {
            var response = await _userRoleService.AddUserRoleAsync(userId, roleId);
            return CreateActionResult(response);
        }

        [HttpDelete("userId/{userId}/roleId/{roleId}")]
        public async Task<IActionResult> RemoveUserRoleAsync(int userId, int roleId)
        {
            var response = await _userRoleService.RemoveUserRoleAsync(userId, roleId);
            return CreateActionResult(response);
        }
    }
}
