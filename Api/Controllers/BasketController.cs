using API.Controllers;
using Entity.DTOs;
using Entity.Model;
using Entity.Services;
using Microsoft.AspNetCore.Mvc;
using NLayer.API.Filters;

namespace Api.Controllers
{
    public class BasketController : CustomBaseController
    {
        private readonly IBasketService _userBasketServices;

        public BasketController(IBasketService basketService)
        {
            _userBasketServices = basketService;
        }

        [ServiceFilter(typeof(NotFoundFilter<User>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserBasketsById(int id)
        {
            return CreateActionResult(await _userBasketServices.GetUserBasketsById(id));
        }

        [ServiceFilter(typeof(NotFoundFilter<User>))]
        [HttpGet("{userId}/{productId}")]
        public async Task<IActionResult> IsBasketProduct(int userId, int productId)
        {
            return CreateActionResult(await _userBasketServices.IsBasketProduct(userId, productId));
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserBasketProductsAsync(BasketDto basket)
        {
            return CreateActionResult(await _userBasketServices.CreateUserBasketProductsAsync(basket));
        }

        [ServiceFilter(typeof(NotFoundFilter<User>))]
        [HttpDelete("{userId}/{productId}")]
        public async Task<IActionResult> DeleteUserBasketProductsAsync(int userId, int productId)
        {
            return CreateActionResult(await _userBasketServices.DeleteUserBasketProductsAsync(userId, productId));
        }
    }
}
