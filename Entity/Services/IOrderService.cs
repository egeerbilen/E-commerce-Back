

using Core.DTOs;
using Core.Services;
using Entity.Model;

namespace Entity.Services
{
    public interface IOrderService : IGenericService<Order, OrderDto>
    {
        Task<CustomResponseDto<List<int>>> SaveOrdersAndReturnIdsAsync(List<OrderDto> orderDtos);

    }
}
