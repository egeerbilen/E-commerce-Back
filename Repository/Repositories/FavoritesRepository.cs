using Core.DTOs;
using Entity.Model;
using Entity.Repositories;
using Repository;

namespace DataAccess.Repositories
{
    public class FavoritesRepository : GenericManyToManyRepository<Favorite>, IFavoritesRepository
    {
        public FavoritesRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Favorite>> GetFavoritesByUserIdAsync(int userId, string propertyName)
        {
            return await GetRelatedEntitiesByFirstEntityIdAsync(userId, nameof(Favorite.UserId));
        }
    }
}
