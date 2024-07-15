using API.Controllers;
using Core.DTOs;
using Entity.DTOs;
using Entity.Model;
using Entity.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLayer.API.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    public class OrderController : CustomBaseController
    {
        private readonly IOrderService _service;

        public OrderController(IOrderService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize(Roles = "SuperUser, Admin")]
        public async Task<IActionResult> GetAll()
        {
            return CreateActionResult(await _service.GetAllAsync());
        }

        [Authorize(Roles = "SuperUser, Admin")]
        [ServiceFilter(typeof(NotFoundFilter<Order>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return CreateActionResult(await _service.GetByIdAsync(id));
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(OrderDto orderDto)
        {
            return CreateActionResult(await _service.AddAsync(orderDto));
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateList(List<OrderDto> orderDto)
        {
            return CreateActionResult(await _service.AddRangeAsync(orderDto));
        }

        [Authorize(Roles = "SuperUser, Admin")]
        [ServiceFilter(typeof(NotFoundFilter<Order>))]
        [HttpPut]
        public async Task<IActionResult> Update(OrderDto orderDto)
        {
            return CreateActionResult(await _service.UpdateAsync(orderDto));
        }

        [Authorize(Roles = "SuperUser, Admin")]
        [ServiceFilter(typeof(NotFoundFilter<Order>))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            return CreateActionResult(await _service.RemoveAsync(id));
        }


        [Authorize(Roles = "SuperUser, Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateAndReturnIds(List<OrderDto> orderDtos)
        {
            return CreateActionResult(await _service.SaveOrdersAndReturnIdsAsync(orderDtos));
        }
    }
}
