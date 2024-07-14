using Core.DTOs;
using Core.Services;
using Entity.Model;

namespace Entity.Services
{
    public interface IOrderProductService : IGenericService<OrderProduct, OrderProductDto>
    {
        Task<CustomResponseDto<NoContentDto>> CreateOrderProductAsync(List<OrderProductDto> dto);
        Task<CustomResponseDto<List<OrderDto>>> GetUserOrdersAsync(int userId);
        Task<CustomResponseDto<List<ProductDto>>> GetOrderProductsAsync(int orderId);
    }
}
