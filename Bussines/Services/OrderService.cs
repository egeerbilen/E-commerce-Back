using AutoMapper;
using Core.DTOs;
using Core.Repositories;
using Core.UnitOfWorks;
using DataAccess.Repositories;
using Entity.Model;
using Entity.Repositories;
using Entity.Services;
using Service.Services;

namespace Bussines.Services
{
    public class OrderService : GenericService<Order, OrderDto>, IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IGenericRepository<Order> repository, IUnitOfWork unitOfWork, IMapper mapper, IOrderRepository orderRepository) : base(repository, unitOfWork, mapper)
        {
            _orderRepository = orderRepository;
        }


        public async Task<CustomResponseDto<List<int>>> SaveOrdersAndReturnIdsAsync(List<OrderDto> orderDtos)
        {
            var orders = _mapper.Map<List<Order>>(orderDtos);
            var ids = await _orderRepository.SaveAndReturnIdsAsync(orders);
            return CustomResponseDto<List<int>>.Success(200, ids);
        }
    }
}
