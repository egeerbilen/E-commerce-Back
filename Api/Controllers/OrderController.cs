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
    [Authorize(Roles = "Admin")]
    public class OrderController : CustomBaseController
    {
        private readonly IOrderService _service;

        public OrderController(IOrderService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CreateActionResult(await _service.GetAllAsync());
        }

        [ServiceFilter(typeof(NotFoundFilter<Order>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return CreateActionResult(await _service.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderDto orderDto)
        {
            return CreateActionResult(await _service.AddAsync(orderDto));
        }

        [ServiceFilter(typeof(NotFoundFilter<Order>))]
        [HttpPut]
        public async Task<IActionResult> Update(OrderDto orderDto)
        {
            return CreateActionResult(await _service.UpdateAsync(orderDto));
        }

        [ServiceFilter(typeof(NotFoundFilter<Order>))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            return CreateActionResult(await _service.RemoveAsync(id));
        }
    }
}
