using API.Controllers;
using Core.DTOs;
using Entity.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    public class BasketProductController : CustomBaseController
    {
        private readonly IBasketProductService _basketProductService;

        public BasketProductController(IBasketProductService basketService)
        {
            _basketProductService = basketService;
        }

        [HttpGet("{userId}/products/{productId}")]
        public async Task<IActionResult> IsBasketProduct(int userId, int productId)
        {
            var result = await _basketProductService.IsProductInBasketAsync(userId, productId);
            return CreateActionResult(result);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserBasketsById(int userId)
        {
            var result = await _basketProductService.GetProductsByBasketIdAsync(userId);
            return CreateActionResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBasketProduct([FromBody] BasketProductDto basket)
        {
            var result = await _basketProductService.AddProductToBasketAsync(basket);
            return CreateActionResult(result);
        }

        [HttpDelete("userId/{userId}/products/{productId}")]
        public async Task<IActionResult> DeleteBasketProduct(int userId, int productId)
        {
            var result = await _basketProductService.RemoveProductFromBasketAsync(userId, productId);
            return CreateActionResult(result);
        }
    }
}
