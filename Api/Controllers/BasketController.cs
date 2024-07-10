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
            return CreateActionResult(await _userBasketServices.GetUserBasketsByIdAsync(id));
        }

        [ServiceFilter(typeof(NotFoundFilter<User>))]
        [HttpGet("{userId}/{productId}")]
        public async Task<IActionResult> IsBasketProduct(int userId, int productId)
        {
            return CreateActionResult(await _userBasketServices.IsBasketProductAsync(userId, productId));
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserBasketProductAsync(BasketDto basket)
        {
            return CreateActionResult(await _userBasketServices.CreateUserBasketProductAsync(basket));
        }

        [ServiceFilter(typeof(NotFoundFilter<User>))]
        [HttpDelete("{userId}/{productId}")]
        public async Task<IActionResult> DeleteUserBasketProductAsync(int userId, int productId)
        {
            return CreateActionResult(await _userBasketServices.DeleteUserBasketProductAsync(userId, productId));
        }
    }
}
