using Core.DTOs;

namespace Entity.Repositories
{
    public interface IGenericManyToManyRepository<TEntity> where TEntity : class
    {
        Task<bool> IsRelatedEntityAsync(int firstEntityId, int secondEntityId);
        Task<List<TEntity>> GetRelatedEntitiesByFirstEntityIdAsync(int firstEntityId, string propertyName);
        Task<bool> CreateRelatedEntityAsync(TEntity firstEntity);
        Task<bool> DeleteRelatedEntityAsync(int firstEntityId, int secondEntityId);
    }
}
