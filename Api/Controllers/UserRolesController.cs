using API.Controllers;
using Core.DTOs;
using Entity.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers
{
    public class UserRolesController : CustomBaseController
    {
        private readonly IUserRoleService _userRoleService;

        public UserRolesController(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }

        [HttpPost()]
        public async Task<IActionResult> AddUserRoleAsync([FromQuery] int userId, [FromQuery] int roleId)
        {
            var response = await _userRoleService.AddUserRoleAsync(userId, roleId);
            return CreateActionResult(response);
        }

        [HttpDelete()]
        public async Task<IActionResult> RemoveUserRoleAsync([FromQuery] int userId, [FromQuery] int roleId)
        {
            var response = await _userRoleService.RemoveUserRoleAsync(userId, roleId);
            return CreateActionResult(response);
        }
    }
}
