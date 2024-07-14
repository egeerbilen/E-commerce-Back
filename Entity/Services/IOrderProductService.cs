using Core.DTOs;
using Entity.Model;

namespace Entity.Services
{
    public interface IOrderProductService
    {
        Task<CustomResponseDto<NoContentDto>> CreateOrderProductAsync(List<OrderProductDto> dto);
        Task<CustomResponseDto<List<OrderDto>>> GetUserOrdersAsync(int userId);
        Task<CustomResponseDto<List<ProductDto>>> GetOrderProductsAsync(int orderId);
    }
}
