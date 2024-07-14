using Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Entity.Services
{
    public interface IOrderProductService
    {
        Task<CustomResponseDto<NoContentDto>> CreateOrderProductAsync(List<OrderProductDto> dto);
        Task<CustomResponseDto<List<OrderDto>>> GetUserOrders(int userId);
    }
}
