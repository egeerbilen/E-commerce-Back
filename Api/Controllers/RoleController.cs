using API.Controllers;
using Core.DTOs;
using Entity.DTOs;
using Entity.Model;
using Entity.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLayer.API.Filters;
using System.Threading.Tasks;

namespace Api.Controllers
{

    [Authorize(Roles = "SuperUser")]
    public class RoleController : CustomBaseController
    {
        private readonly IRoleService _service;

        public RoleController(IRoleService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CreateActionResult(await _service.GetAllAsync());
        }

        [ServiceFilter(typeof(NotFoundFilter<Role>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return CreateActionResult(await _service.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoleDto roleDto)
        {
            return CreateActionResult(await _service.AddAsync(roleDto));
        }

        [ServiceFilter(typeof(NotFoundFilter<Role>))]
        [HttpPut]
        public async Task<IActionResult> Update(RoleDto roleDto)
        {
            return CreateActionResult(await _service.UpdateAsync(roleDto));
        }

        [ServiceFilter(typeof(NotFoundFilter<Role>))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            return CreateActionResult(await _service.RemoveAsync(id));
        }
    }
}
