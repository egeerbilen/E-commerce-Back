using AutoMapper;
using Core.DTOs;
using Core.UnitOfWorks;
using Entity.DTOs;
using Entity.Model;
using Entity.Repositories;
using Entity.Services;
using Microsoft.AspNetCore.Http;

namespace Bussines.Services
{
    public class UserBasketsService : BaseUnitMapper, IUserBasketServices
    {
        private readonly IUserBasketRepository _userBasketsService;

        public UserBasketsService(IUserBasketRepository userBasketRepository, IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            _userBasketsService = userBasketRepository;
        }

        public async Task<CustomResponseDto<NoContentDto>> CreateUserBasketProductsAsync(UserBasketsDto userBasket)
        {
            var newDto = _mapper.Map<UserBaskets>(userBasket);
            await _userBasketsService.CreateUserBasketProductsAsync(newDto);
            await _unitOfWork.CommitAsync(); // Unitofwork üzerinden save change metodunu çağırıyoruz

            return CustomResponseDto<NoContentDto>.Success(StatusCodes.Status200OK);
        }
        public async Task<CustomResponseDto<NoContentDto>> DeleteUserBasketProductsAsync(int userId, int productId)
        {
            var result = await _userBasketsService.DeleteUserBasketProductsAsync(userId, productId);
            if (result)
            {
                await _unitOfWork.CommitAsync(); // Unitofwork üzerinden save change metodunu çağırıyoruz
                return CustomResponseDto<NoContentDto>.Success(StatusCodes.Status200OK);
            }

            return CustomResponseDto<NoContentDto>.Fail(StatusCodes.Status404NotFound, "User favorite product not found.");
        }

    }
}
