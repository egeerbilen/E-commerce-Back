using AutoMapper;
using Core.DTOs;
using Core.Repositories;
using Core.UnitOfWorks;
using DataAccess.Repositories;
using Entity.DTOs;
using Entity.Model;
using Entity.Repositories;
using Entity.Services;
using Microsoft.AspNetCore.Http;

namespace Bussines.Services
{
    public class BasketProductService : BaseUnitMapper, IBasketProductService
    {
        private readonly IBasketProductRepository _basketProductRepository;

        public BasketProductService(IUnitOfWork unitOfWork, IMapper mapper, IBasketProductRepository basketProductRepository) : base(unitOfWork, mapper)
        {
            _basketProductRepository = basketProductRepository;
        }

        public async Task<CustomResponseDto<NoContentDto>> CreateBasketProductAsync(BasketProductDto basket)
        {
            var newDto = _mapper.Map<BasketProduct>(basket);
            await _basketProductRepository.CreateBasketProductAsync(newDto);
            await _unitOfWork.CommitAsync(); // Unitofwork üzerinden save change metodunu çağırıyoruz

            return CustomResponseDto<NoContentDto>.Success(StatusCodes.Status200OK);
        }

        public async Task<CustomResponseDto<NoContentDto>> DeleteUserBasketProductAsync(int userId, int productId)
        {
            var result = await _basketProductRepository.DeleteBasketProductAsync(userId, productId);
            if (result)
            {
                await _unitOfWork.CommitAsync(); // Unitofwork üzerinden save change metodunu çağırıyoruz
                return CustomResponseDto<NoContentDto>.Success(StatusCodes.Status200OK);
            }

            return CustomResponseDto<NoContentDto>.Fail(StatusCodes.Status404NotFound, "User favorite product not found.");
        }

        public async Task<CustomResponseDto<List<ProductDto>>> GetBasketProductsByIdAsync(int userId)
        {
            var baskets = await _basketProductRepository.GetUserBasketsByIdAsync(userId);
            var dtos = _mapper.Map<List<ProductDto>>(baskets);
            return CustomResponseDto<List<ProductDto>>.Success(StatusCodes.Status200OK, dtos);
        }

        public async Task<CustomResponseDto<bool>> IsBasketProductAsync(int userId, int productId)
        {
            var baskets = await _basketProductRepository.IsBasketProductAsync(userId, productId);
            return CustomResponseDto<bool>.Success(StatusCodes.Status200OK, baskets);
        }
    }
}
