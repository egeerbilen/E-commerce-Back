using AutoMapper;
using Core.DTOs;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWorks;
using Entity.Model;
using Entity.Repositories;
using Microsoft.AspNetCore.Http;
using NLayer.Core.DTOs;
using NLayer.Core.Repositories;

namespace Service.Services
{
    public class ProductService : GenericService<Product, ProductDto>, IProductService
    {
        // Direk olarak ProductRepository e erişmek için aşağodaki kodu yazdık
        private readonly IProductRepository _productRepository;
        private readonly IBasketProductRepository _basketProductRepository;
        private readonly IFavoritesRepository _favoritesRepository;

        public ProductService(IGenericRepository<Product> repository, IUnitOfWork unitOfWork, IMapper mapper, 
            IProductRepository productRepository, IBasketProductRepository basketProductRepository, IFavoritesRepository favoritesRepository) : base(repository, unitOfWork, mapper)
        {
            _productRepository = productRepository;
            _favoritesRepository = favoritesRepository;
            _basketProductRepository = basketProductRepository;
        }

        public async Task<CustomResponseDto<ProductDto>> AddProductAsync(ProductCreateDto dto)
        {
            var newEntity = _mapper.Map<Product>(dto);
            await _productRepository.AddAsync(newEntity);
            await _unitOfWork.CommitAsync();
            var newDto = _mapper.Map<ProductDto>(newEntity);
            return CustomResponseDto<ProductDto>.Success(StatusCodes.Status200OK, newDto);
        }

        public async Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductsWitCategoryAsync()
        {
            // bussine kodunu burada yazıyoruz bir try cache kullanırsak burada yazacağız
            var products = await _productRepository.GetProductsWitCategoryAsync();

            var productsDto = _mapper.Map<List<ProductWithCategoryDto>>(products); // products değerini -> List<ProductWithCategoryDto> değerine dönüştürüyoruz
            return CustomResponseDto<List<ProductWithCategoryDto>>.Success(200, productsDto);
        }

        public async Task<CustomResponseDto<List<ProductDto>>> GetUserProductsAsync(int userId)
        {
            var products = await _productRepository.GetProductsByUserIdAsync(userId);

            var productsDto = _mapper.Map<List<ProductDto>>(products);
            return CustomResponseDto<List<ProductDto>>.Success(200, productsDto);
        }

        public async Task<CustomResponseDto<NoContentDto>> UpdateProductAsync(ProductUpdateDto dto)
        {
            var entity = _mapper.Map<Product>(dto);
            _productRepository.Update(entity);
            await _unitOfWork.CommitAsync();
            return CustomResponseDto<NoContentDto>.Success(StatusCodes.Status200OK);
        }

        public async Task<CustomResponseDto<NoContentDto>> DeleteProductWithDependenciesAsync(int productId)
        {
            var userFavorites = await _favoritesRepository.GetFavoritesByProductIdAsync(productId);
            var basketProducts = await _basketProductRepository.GetBasketIdsByProductIdAsync(productId);

            foreach (var userFavorite in userFavorites)
            {
                await _favoritesRepository.DeleteFavoriteAsync(userFavorite.UserId, productId);
                await _unitOfWork.CommitAsync();
            }

            foreach (var basketProduct in basketProducts)
            {
                basketProduct.NumberOfProducts = 0;
                await _basketProductRepository.UpdateBasketIdsByProductIdAsync(basketProduct);
                await _unitOfWork.CommitAsync();
            }

            var productEntity = await _productRepository.GetByIdAsync(productId);
            _productRepository.Remove(productEntity);
            await _unitOfWork.CommitAsync();
            return CustomResponseDto<NoContentDto>.Success(StatusCodes.Status200OK);
        }

    }
}
