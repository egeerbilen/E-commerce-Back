using Microsoft.AspNetCore.Mvc;
using Core.DTOs;
using Entity.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Controllers;

namespace Api.Controllers
{
    public class OrderProductController : CustomBaseController
    {
        private readonly IOrderProductService _orderProductService;

        public OrderProductController(IOrderProductService orderProductService)
        {
            _orderProductService = orderProductService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderProduct(List<OrderProductDto> orderProductDtos)
        {
            var result = await _orderProductService.CreateOrderProductAsync(orderProductDtos);
            return CreateActionResult(result);
        }

        [HttpGet("User/{userId}")]
        public async Task<IActionResult> GetUserOrders(int userId)
        {
            var result = await _orderProductService.GetUserOrdersAsync(userId);
            return CreateActionResult(result);
        }

        [HttpGet("Order/{orderId}")]
        public async Task<IActionResult> GetOrderProducts(int orderId)
        {
            var result = await _orderProductService.GetOrderProductsAsync(orderId);
            return CreateActionResult(result);
        }
    }
}
