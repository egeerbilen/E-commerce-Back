using API.Controllers;
using Autofac.Core;
using Entity.DTOs;
using Entity.Model;
using Entity.Services;
using Microsoft.AspNetCore.Mvc;
using NLayer.API.Filters;

namespace YourNamespace.Controllers
{
    public class FavoriteController : CustomBaseController
    {
        private readonly IFavoritesService _userFavoritesServices;

        public FavoriteController(IFavoritesService userFavoriteServices)
        {
            _userFavoritesServices = userFavoriteServices;
        }

        [ServiceFilter(typeof(NotFoundFilter<User>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserFavoritesById(int id)
        {
            return CreateActionResult(await _userFavoritesServices.GetRelatedEntitiesByFirstEntityIdAsync(id, "UserId"));
        }

        [ServiceFilter(typeof(NotFoundFilter<User>))]
        [HttpGet("{userId}/{productId}")]
        public async Task<IActionResult> IsFavoriteProduct(int userId, int productId)
        {
            return CreateActionResult(await _userFavoritesServices.IsRelatedEntityAsync(userId, productId));
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserFavoriteProduct(FavoritesDto favorites)
        {
            return CreateActionResult(await _userFavoritesServices.CreateRelatedEntityAsync(favorites));
        }

        [ServiceFilter(typeof(NotFoundFilter<User>))]
        [HttpDelete("{userId}/{productId}")]
        public async Task<IActionResult> DeleteUserFavoriteProduct(int userId, int productId)
        {
            return CreateActionResult(await _userFavoritesServices.DeleteRelatedEntityAsync(userId, productId));
        }
    }
}
