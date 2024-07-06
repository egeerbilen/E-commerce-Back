using AutoMapper;
using Core.DTOs;
using Core.Repositories;
using Core.UnitOfWorks;
using Entity.DTOs;
using Entity.Model;
using Entity.Repositories;
using Entity.Services;
using NLayer.Core.DTOs;
using NLayer.Core.Repositories;

namespace Service.Services
{
    public class ProductDetailsService : GenericService<ProductDetails, ProductDetailsDto>, IProductDetailsService
    {
        // Direk olarak ProductRepository e erişmek için aşağodaki kodu yazdık
        private readonly IProductDetailsRepository _productDetailsRepository;

        public ProductDetailsService(IGenericRepository<ProductDetails> repository, IUnitOfWork unitOfWork, IMapper mapper, IProductDetailsRepository productDetailsRepository) : base(repository, unitOfWork, mapper)
        {
            _productDetailsRepository = productDetailsRepository;
        }

    }
}
