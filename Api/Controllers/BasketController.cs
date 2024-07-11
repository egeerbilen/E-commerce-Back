using API.Controllers;
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
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return CreateActionResult(await _userBasketServices.GetByIdAsync(id));
        }
    }
}
