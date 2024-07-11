using API.Controllers;
using Core.DTOs;
using Entity.DTOs;
using Entity.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class BasketProductController : CustomBaseController
    {
        private readonly IBasketProductService _basketProductService;

        public BasketProductController(IBasketProductService basketService)
        {
            _basketProductService = basketService;
        }

        [HttpGet("{userId}/products/{productId}")]
        public async Task<IActionResult> IsBasketProductAsync(int userId, int productId)
        {
            var result = await _basketProductService.IsBasketProductAsync(userId, productId);
            return CreateActionResult(result);
        }

        [HttpGet("{userId}/baskets")]
        public async Task<IActionResult> GetUserBasketsByIdAsync(int userId)
        {
            var result = await _basketProductService.GetBasketProductsByIdAsync(userId);
            return CreateActionResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserBasketProductAsync([FromBody] BasketProductDto basket)
        {
            var result = await _basketProductService.CreateBasketProductAsync(basket);
            return CreateActionResult(result);
        }

        [HttpDelete("{userId}/products/{productId}")]
        public async Task<IActionResult> DeleteUserBasketProductAsync(int userId, int productId)
        {
            var result = await _basketProductService.DeleteUserBasketProductAsync(userId, productId);
            return CreateActionResult(result);
        }
    }
}
