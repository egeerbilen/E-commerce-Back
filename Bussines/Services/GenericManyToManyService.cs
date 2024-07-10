using AutoMapper;
using Core.DTOs;
using Core.UnitOfWorks;
using Entity.Repositories;
using Entity.Services;
using Microsoft.AspNetCore.Http;

namespace Bussines.Services
{
    public class GenericManyToManyService<TEntity, TDto> : BaseUnitMapper, IGenericManyToManyService<TEntity, TDto>
        where TEntity : class
        where TDto : class
    {
        private readonly IGenericManyToManyRepository<TEntity> _repository;

        public GenericManyToManyService(IGenericManyToManyRepository<TEntity> repository, IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            _repository = repository;
        }

        public async Task<CustomResponseDto<NoContentDto>> CreateRelatedEntityAsync(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            await _repository.CreateRelatedEntityAsync(entity);
            await _unitOfWork.CommitAsync();

            return CustomResponseDto<NoContentDto>.Success(StatusCodes.Status200OK);
        }

        public async Task<CustomResponseDto<NoContentDto>> DeleteRelatedEntityAsync(int firstEntityId, int secondEntityId)
        {
            var result = await _repository.DeleteRelatedEntityAsync(firstEntityId, secondEntityId);
            if (result)
            {
                await _unitOfWork.CommitAsync();
                return CustomResponseDto<NoContentDto>.Success(StatusCodes.Status200OK);
            }

            return CustomResponseDto<NoContentDto>.Fail(StatusCodes.Status404NotFound, "Related entity not found.");
        }

        public async Task<CustomResponseDto<List<TDto>>> GetRelatedEntitiesByFirstEntityIdAsync(int firstEntityId, string propertyName)
        {
            var entities = await _repository.GetRelatedEntitiesByFirstEntityIdAsync(firstEntityId, propertyName);
            var dtos = _mapper.Map<List<TDto>>(entities);
            return CustomResponseDto<List<TDto>>.Success(StatusCodes.Status200OK, dtos);
        }

        public async Task<CustomResponseDto<bool>> IsRelatedEntityAsync(int firstEntityId, int secondEntityId)
        {
            var isRelated = await _repository.IsRelatedEntityAsync(firstEntityId, secondEntityId);
            return CustomResponseDto<bool>.Success(StatusCodes.Status200OK, isRelated);
        }
    }
}
