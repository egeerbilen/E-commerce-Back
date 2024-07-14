using AutoMapper;
using Core.DTOs;
using Core.Repositories;
using Core.UnitOfWorks;
using DataAccess.Repositories;
using Entity.Model;
using Entity.Repositories;
using Entity.Services;
using Microsoft.AspNetCore.Http;
using Service.Services;

namespace Business.Services
{
    public class OrderProductService : GenericService<OrderProduct, OrderProductDto>, IOrderProductService
    {
        private readonly IOrderProductRepository _orderProductRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderProductService(IGenericRepository<OrderProduct> repository, IOrderProductRepository orderProductRepository, IUnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
            _orderProductRepository = orderProductRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<NoContentDto>> CreateOrderProductAsync(List<OrderProductDto> dto)
        {
            var orderProducts = _mapper.Map<List<OrderProduct>>(dto);
            await _orderProductRepository.CreateOrderProductAsync(orderProducts);
            await _unitOfWork.CommitAsync();
            return CustomResponseDto<NoContentDto>.Success(StatusCodes.Status200OK);
        }

        public async Task<CustomResponseDto<List<OrderDto>>> GetUserOrdersAsync(int userId)
        {
            var orders = await _orderProductRepository.GetUserOrderProductsAsync(userId);
            var orderDtos = _mapper.Map<List<OrderDto>>(orders);
            return CustomResponseDto<List<OrderDto>>.Success(StatusCodes.Status200OK, orderDtos);
        }

        public async Task<CustomResponseDto<List<ProductDto>>> GetOrderProductsAsync(int orderId)
        {
            var orders = await _orderProductRepository.GetOrderProductsAsync(orderId);
            var orderDtos = _mapper.Map<List<ProductDto>>(orders);
            return CustomResponseDto<List<ProductDto>>.Success(StatusCodes.Status200OK, orderDtos);
        }
    }
}
