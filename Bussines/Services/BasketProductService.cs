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
using Microsoft.EntityFrameworkCore;

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
            if (isProductAvailable == null)
            {
                return CustomResponseDto<NoContentDto>.Fail(StatusCodes.Status200OK, "The relevant product is already available in the basket");
            }
            await _basketProductRepository.AddProductToBasketAsync(newDto);
            await _unitOfWork.CommitAsync(); // Unitofwork üzerinden save change metodunu çağırıyoruz

            return CustomResponseDto<NoContentDto>.Success(StatusCodes.Status200OK);
        }

        public async Task<CustomResponseDto<List<ProductWithQuantityDto>>> GetProductsByBasketIdAsync(int basketId)
        {
            var basketProducts = await _basketProductRepository.GetProductsByBasketIdAsync(basketId);
            var productDtos = new List<ProductWithQuantityDto>();

            foreach (var product in basketProducts)
            {
                var productInBasket = await _basketProductRepository.IsProductInBasketAsync(basketId, product.Id);
                var productDto = _mapper.Map<ProductWithQuantityDto>(product);
                productDto.NumberOfProducts = productInBasket.NumberOfProducts;
                productDtos.Add(productDto);
            }

            return CustomResponseDto<List<ProductWithQuantityDto>>.Success(StatusCodes.Status200OK, productDtos);

        }

        public async Task<CustomResponseDto<BasketProduct>> IsProductInBasketAsync(int basketId, int productId)
        {
            var isInBasket = await _basketProductRepository.IsProductInBasketAsync(basketId, productId);
            return CustomResponseDto<BasketProduct>.Success(StatusCodes.Status200OK, isInBasket);
        }

        public async Task<CustomResponseDto<NoContentDto>> UpdateBasketIdsByProductIdAsync(BasketProductDto basket)
        {
            var existingBasketProduct = await _basketProductRepository.IsProductInBasketAsync(basket.BasketId, basket.ProductId);

            if (existingBasketProduct == null)
            {
                // Ürün sepet içerisinde değilse, ürünü eklemek için AddProductToBasketAsync metodunu çağır.
                return await AddProductToBasketAsync(basket);
            }

            // Ürün sepet içerisindeyse, gelen NumberOfProducts değerini güncelle.
            var newDto = _mapper.Map<BasketProduct>(basket);
            newDto.NumberOfProducts = basket.NumberOfProducts;

            await _basketProductRepository.UpdateBasketIdsByProductIdAsync(newDto);
            await _unitOfWork.CommitAsync();

            return CustomResponseDto<NoContentDto>.Success(StatusCodes.Status200OK);
        }

    }
}
