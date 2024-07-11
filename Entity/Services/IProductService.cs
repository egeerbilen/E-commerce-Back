using Core.DTOs;
using Entity.DTOs;
using Entity.Model;
using NLayer.Core.DTOs;

namespace Core.Services
{
    public interface IProductService : IGenericService<Product, ProductDto>
    {
        // Motodları overload ettik aşağıda
        // UpdateAsync için üst sınıfadan gelen bir upda te motodu var istediğimiz zaman ProductUpdateDto ya geçer bilirim yada productdto ya geçe biliriz
        Task<CustomResponseDto<NoContentDto>> UpdateProductAsync(ProductUpdateDto dto);
        Task<CustomResponseDto<ProductDto>> AddProductAsync(ProductCreateDto dto); // ProductDto dönecek -- ProductCreateDto alacak
        Task<CustomResponseDto<List<ProductDto>>> GetUserProductsAsync(int userId);
        Task<CustomResponseDto<NoContentDto>> DeleteProductWithDependenciesAsync(int productId);
    }
}
