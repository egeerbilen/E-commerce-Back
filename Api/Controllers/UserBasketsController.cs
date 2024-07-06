using API.Controllers;
using Entity.DTOs;
using Entity.Services;
using Microsoft.AspNetCore.Mvc;

namespace YourNamespace.Controllers
{
    public class UserBasketsController : CustomBaseController
    {
        private readonly IUserBasketServices _userBasketServices;

        public UserBasketsController(IUserBasketServices userBasketServices)
        {
            _userBasketServices = userBasketServices;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserBasketProduct(UserBasketsDto userFavoritesProductsDto)
        {
            return CreateActionResult(await _userBasketServices.CreateUserBasketProductsAsync(userFavoritesProductsDto));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUserBasketProduct(UserBasketsDto userFavoritesProductsDto)
        {
            return CreateActionResult(await _userBasketServices.DeleteUserBasketProductsAsync(userFavoritesProductsDto.UserId, userFavoritesProductsDto.ProductId));
        }
    }
}
