using AutoMapper;
using Core.Repositories;
using Core.UnitOfWorks;
using Entity.DTOs;
using Entity.Model;
using Entity.Repositories;
using Entity.Services;
using Service.Services;

namespace Bussines.Services
{
    public class BasketService : GenericService<Basket, BasketDto>, IBasketService
    {
        private readonly IBasketRepository _basketRepository;

        public BasketService(IGenericRepository<Basket> repository, IBasketRepository basketRepository, IUnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
            _basketRepository = basketRepository;
        }
    }
}
