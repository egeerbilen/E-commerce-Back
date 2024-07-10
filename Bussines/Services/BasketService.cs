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
    public class BasketService : BaseUnitMapper, IBasketService
    {
        private readonly IBasketRepository _basketRepository;

        public BasketService(IBasketRepository basketRepository, IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            _basketRepository = basketRepository;
        }
        public async Task<CustomResponseDto<NoContentDto>> CreateUserBasketProductAsync(BasketDto basket)
        {
            var newDto = _mapper.Map<Basket>(basket);
            await _basketRepository.CreateUserBasketProductAsync(newDto);
            await _unitOfWork.CommitAsync(); // Unitofwork üzerinden save change metodunu çağırıyoruz

            return CustomResponseDto<NoContentDto>.Success(StatusCodes.Status200OK);
        }

        public async Task<CustomResponseDto<NoContentDto>> DeleteUserBasketProductAsync(int userId, int productId)
        {
            var result = await _basketRepository.DeleteUserBasketProductAsync(userId, productId);
            if (result)
            {
                await _unitOfWork.CommitAsync(); // Unitofwork üzerinden save change metodunu çağırıyoruz
                return CustomResponseDto<NoContentDto>.Success(StatusCodes.Status200OK);
            }

            return CustomResponseDto<NoContentDto>.Fail(StatusCodes.Status404NotFound, "User favorite product not found.");
        }

        public async Task<CustomResponseDto<List<ProductDto>>> GetUserBasketsByIdAsync(int userId)
        {
            var baskets = await _basketRepository.GetUserBasketsByIdAsync(userId);
            var dtos = _mapper.Map<List<ProductDto>>(baskets);
            return CustomResponseDto<List<ProductDto>>.Success(StatusCodes.Status200OK, dtos);
        }

        public async Task<CustomResponseDto<bool>> IsBasketProductAsync(int userId, int productId)
        {
            var baskets = await _basketRepository.IsBasketProductAsync(userId, productId);
            return CustomResponseDto<bool>.Success(StatusCodes.Status200OK, baskets);
        }
    }
}
