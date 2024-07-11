using AutoMapper;
using Core.DTOs;
using Core.UnitOfWorks;
using Entity.DTOs;
using Entity.Model;
using Entity.Repositories;
using Entity.Services;
using Microsoft.AspNetCore.Http;

namespace Bussines.Services
{
    public class FavoritesService : BaseUnitMapper, IFavoritesService
    {
        private readonly IFavoritesRepository _favoritesRepository;

        public FavoritesService(IFavoritesRepository userFavoritesProductsRepository, IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            _favoritesRepository = userFavoritesProductsRepository;
        }

        public async Task<CustomResponseDto<NoContentDto>> CreateFavoriteAsync(FavoritesDto favorites)
        {
            var newDto = _mapper.Map<Favorite>(favorites);
            await _favoritesRepository.CreateFavoriteAsync(newDto);
            await _unitOfWork.CommitAsync(); // Unitofwork üzerinden save change metodunu çağırıyoruz

            return CustomResponseDto<NoContentDto>.Success(StatusCodes.Status200OK);
        }
        public async Task<CustomResponseDto<NoContentDto>> DeleteFavoriteAsync(int userId, int productId)
        {
            var result = await _favoritesRepository.DeleteFavoriteAsync(userId, productId);
            if (result)
            {
                await _unitOfWork.CommitAsync(); // Unitofwork üzerinden save change metodunu çağırıyoruz
                return CustomResponseDto<NoContentDto>.Success(StatusCodes.Status200OK);
            }

            return CustomResponseDto<NoContentDto>.Fail(StatusCodes.Status404NotFound, "User favorite product not found.");
        }

        public async Task<CustomResponseDto<List<ProductDto>>> GetFavoritesByUserIdAsync(int userId)
        {
            var favorites = await _favoritesRepository.GetFavoritesByUserIdAsync(userId);
            var dtos = _mapper.Map<List<ProductDto>>(favorites);
            return CustomResponseDto<List<ProductDto>>.Success(StatusCodes.Status200OK, dtos);
        }

        public async Task<CustomResponseDto<bool>> IsFavoriteAsync(int userId, int productId)
        {
            var favorites = await _favoritesRepository.IsFavoriteAsync(userId, productId);
            return CustomResponseDto<bool>.Success(StatusCodes.Status200OK, favorites);
        }
    }
}
