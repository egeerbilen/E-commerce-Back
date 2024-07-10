
using Core.DTOs;

namespace Entity.Services
{
    public interface IGenericManyToManyService<TEntity, TDto> where TEntity : class where TDto : class
    {
        Task<CustomResponseDto<bool>> IsRelatedEntityAsync(int firstEntityId, int secondEntityId);
        Task<CustomResponseDto<List<TDto>>> GetRelatedEntitiesByFirstEntityIdAsync(int firstEntityId, string propertyName);
        Task<CustomResponseDto<NoContentDto>> CreateRelatedEntityAsync(TDto dto);
        Task<CustomResponseDto<NoContentDto>> DeleteRelatedEntityAsync(int firstEntityId, int secondEntityId);


    }
}
