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

        public async Task<CustomResponseDto<NoContentDto>> AddProductToBasketAsync(BasketProductDto basket)
        {
            var newDto = _mapper.Map<BasketProduct>(basket);
            var isProductAvailable = await IsProductInBasketAsync(newDto.BasketId, newDto.ProductId);  
            if (isProductAvailable.Data)  
            {
                return CustomResponseDto<NoContentDto>.Fail(StatusCodes.Status200OK, "The relevant product is already available in the basket");
            }
            await _basketProductRepository.AddProductToBasketAsync(newDto);
            await _unitOfWork.CommitAsync(); // Unitofwork üzerinden save change metodunu çağırıyoruz

            return CustomResponseDto<NoContentDto>.Success(StatusCodes.Status200OK);
        }


        public async Task<CustomResponseDto<NoContentDto>> RemoveProductFromBasketAsync(int basketId, int productId)
        {
            var result = await _basketProductRepository.RemoveProductFromBasketAsync(basketId, productId);
            if (result)
            {
                await _unitOfWork.CommitAsync(); // Unitofwork üzerinden save change metodunu çağırıyoruz
                return CustomResponseDto<NoContentDto>.Success(StatusCodes.Status200OK);
            }

            return CustomResponseDto<NoContentDto>.Fail(StatusCodes.Status404NotFound, "User favorite product not found.");
        }

        public async Task<CustomResponseDto<List<ProductDto>>> GetProductsByBasketIdAsync(int basketId)
        {
            var baskets = await _basketProductRepository.GetProductsByBasketIdAsync(basketId);
            var dtos = _mapper.Map<List<ProductDto>>(baskets);
            return CustomResponseDto<List<ProductDto>>.Success(StatusCodes.Status200OK, dtos);
        }

        public async Task<CustomResponseDto<bool>> IsProductInBasketAsync(int basketId, int productId)
        {
            var baskets = await _basketProductRepository.IsProductInBasketAsync(basketId, productId);
            return CustomResponseDto<bool>.Success(StatusCodes.Status200OK, baskets);
        }
    }
}
