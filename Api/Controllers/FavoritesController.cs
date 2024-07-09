using API.Controllers;
using Autofac.Core;
using Entity.DTOs;
using Entity.Model;
using Entity.Services;
using Microsoft.AspNetCore.Mvc;
using NLayer.API.Filters;

namespace YourNamespace.Controllers
{
    public class FavoritesController : CustomBaseController
    {
        private readonly IFavoritesService _userFavoritesProductsServices;

        public FavoritesController(IFavoritesService userFavoritesProductsServices)
        {
            _userFavoritesProductsServices = userFavoritesProductsServices;
        }

        [ServiceFilter(typeof(NotFoundFilter<User>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserFavoritesById(int id)
        {
            return CreateActionResult(await _userFavoritesProductsServices.GetUserFavoritesById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserFavoriteProduct(FavoritesDto userFavoritesProductsDto)
        {
            return CreateActionResult(await _userFavoritesProductsServices.CreateUserFavoriteProductsAsync(userFavoritesProductsDto));
        }

        [ServiceFilter(typeof(NotFoundFilter<User>))]
        [HttpDelete("{userId}/{productId}")]
        public async Task<IActionResult> DeleteUserFavoriteProduct(int userId, int productId)
        {
            return CreateActionResult(await _userFavoritesProductsServices.DeleteUserFavoriteProductsAsync(userId, productId));
        }
    }
}
