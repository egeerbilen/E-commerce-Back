using AutoMapper;
using Core.DTOs;
using Core.UnitOfWorks;
using Entity.DTOs;
using Entity.Model;
using Entity.Repositories;
using Entity.Services;

namespace Bussines.Services
{
    public class FavoritesService : GenericManyToManyService<Favorite, FavoritesDto>, IFavoritesService
    {
        private readonly IFavoritesRepository _favoritesRepository;

        public FavoritesService(IGenericManyToManyRepository<Favorite> repository, IUnitOfWork unitOfWork, IMapper mapper, IFavoritesRepository favoritesRepository) : base(repository, unitOfWork, mapper)
        {
            _favoritesRepository = favoritesRepository;
        }

        public Task<CustomResponseDto<List<Favorite>>> GetFavoritesByUserIdAsync(int userId, string propertyName)
        {
            return GetFavoritesByUserIdAsync(userId, propertyName);
        }
    }
}
