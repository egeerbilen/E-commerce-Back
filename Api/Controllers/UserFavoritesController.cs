using API.Controllers;
using Autofac.Core;
using Entity.DTOs;
using Entity.Model;
using Entity.Services;
using Microsoft.AspNetCore.Mvc;

namespace YourNamespace.Controllers
{
    public class UserFavoritesController : CustomBaseController
    {
        private readonly IUserFavoritesProductsService _userFavoritesProductsServices;

        public UserFavoritesController(IUserFavoritesProductsService userFavoritesProductsServices)
        {
            _userFavoritesProductsServices = userFavoritesProductsServices;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserFavoriteProduct(UserFavoritesProductsDto userFavoritesProductsDto)
        {
            return CreateActionResult(await _userFavoritesProductsServices.CreateUserFavoriteProductsAsync(userFavoritesProductsDto));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUserFavoriteProduct(UserFavoritesProductsDto userFavoritesProductsDto)
        {
            return CreateActionResult(await _userFavoritesProductsServices.DeleteUserFavoriteProductsAsync(userFavoritesProductsDto.UserId, userFavoritesProductsDto.ProductId));
        }
    }
}
