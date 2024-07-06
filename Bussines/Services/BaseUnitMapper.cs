using AutoMapper;
using Core.UnitOfWorks;

namespace Bussines.Services
{
    public class BaseUnitMapper
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;

        public BaseUnitMapper(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;// veri tabanına yansıtmak için bu interface var
                                     // önce cache alıyor ve sonrasında atıyoruz her hangi birinde hata varsa veri tabanına atmıyoruz
            _mapper = mapper;
        }
    }
}
