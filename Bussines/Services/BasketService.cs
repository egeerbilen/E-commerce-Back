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
        public async Task<CustomResponseDto<NoContentDto>> CreateUserBasketProductsAsync(BasketDto basket)
        {
            var newDto = _mapper.Map<Basket>(basket);
            await _basketRepository.CreateUserBasketProductsAsync(newDto);
            await _unitOfWork.CommitAsync(); // Unitofwork üzerinden save change metodunu çağırıyoruz

            return CustomResponseDto<NoContentDto>.Success(StatusCodes.Status200OK);
        }

        public async Task<CustomResponseDto<NoContentDto>> DeleteUserBasketProductsAsync(int userId, int productId)
        {
            var result = await _basketRepository.DeleteUserBasketProductsAsync(userId, productId);
            if (result)
            {
                await _unitOfWork.CommitAsync(); // Unitofwork üzerinden save change metodunu çağırıyoruz
                return CustomResponseDto<NoContentDto>.Success(StatusCodes.Status200OK);
            }

            return CustomResponseDto<NoContentDto>.Fail(StatusCodes.Status404NotFound, "User favorite product not found.");
        }

        public async Task<CustomResponseDto<List<ProductDto>>> GetUserBasketsById(int userId)
        {
            var baskets = await _basketRepository.GetUserBasketsById(userId);
            var dtos = _mapper.Map<List<ProductDto>>(baskets);
            return CustomResponseDto<List<ProductDto>>.Success(StatusCodes.Status200OK, dtos);
        }

        public async Task<CustomResponseDto<bool>> IsBasketProduct(int userId, int productId)
        {
            var baskets = await _basketRepository.IsBasketProduct(userId, productId);
            return CustomResponseDto<bool>.Success(StatusCodes.Status200OK, baskets);
        }
    }
}
