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
    public class UserFavoritesProductsService : BaseUnitMapper, IUserFavoritesProductsService
    {
        private readonly IUserFavoritesProductsRepository _userFavoritesProductsRepository;

        public UserFavoritesProductsService(IUserFavoritesProductsRepository userFavoritesProductsRepository, IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            _userFavoritesProductsRepository = userFavoritesProductsRepository;
        }

        public async Task<CustomResponseDto<NoContentDto>> CreateUserFavoriteProductsAsync(UserFavoritesProductsDto userFavoritesProducts)
        {
            var newDto = _mapper.Map<UserFavoritesProducts>(userFavoritesProducts);
            var userFavoritesProductsList = await _userFavoritesProductsRepository.CreateUserFavoriteProductsAsync(newDto);
            await _unitOfWork.CommitAsync(); // Unitofwork üzerinden save change metodunu çağırıyoruz

            return CustomResponseDto<NoContentDto>.Success(StatusCodes.Status200OK);
        }
        public async Task<CustomResponseDto<NoContentDto>> DeleteUserFavoriteProductsAsync(int userId, int productId)
        {
            var result = await _userFavoritesProductsRepository.DeleteUserFavoriteProductsAsync(userId, productId);
            if (result)
            {
                await _unitOfWork.CommitAsync(); // Unitofwork üzerinden save change metodunu çağırıyoruz
                return CustomResponseDto<NoContentDto>.Success(StatusCodes.Status200OK);
            }

            return CustomResponseDto<NoContentDto>.Fail(StatusCodes.Status404NotFound, "User favorite product not found.");
        }

        public async Task<CustomResponseDto<List<ProductDto>>> GetUserFavoritesById(int userId)
        {
            var userFavoritesProductsList = await _userFavoritesProductsRepository.GetUserFavoritesById(userId);
            var dtos = _mapper.Map<List<ProductDto>>(userFavoritesProductsList);
            return CustomResponseDto<List<ProductDto>>.Success(StatusCodes.Status200OK, dtos);
        }
    }
}
