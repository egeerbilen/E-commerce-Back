using Entity.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class GenericManyToManyRepository<TEntity> : IGenericManyToManyRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _entitySet;

        public GenericManyToManyRepository(DbContext context)
        {
            _context = context;
            _entitySet = _context.Set<TEntity>();
        }

        public async Task<bool> CreateRelatedEntityAsync(TEntity entity)
        {
            await _entitySet.AddAsync(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteRelatedEntityAsync(int firstEntityId, int secondEntityId)
        {
            var entity = await _entitySet.FindAsync(firstEntityId, secondEntityId);
            if (entity != null)
            {
                _entitySet.Remove(entity);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<List<TEntity>> GetRelatedEntitiesByFirstEntityIdAsync(int firstEntityId, string propertyName)
        {
            return await _entitySet
                .Where(entity => EF.Property<int>(entity, propertyName) == firstEntityId)
                .ToListAsync();
        }

        public async Task<bool> IsRelatedEntityAsync(int firstEntityId, int secondEntityId)
        {
            return await _entitySet.FindAsync(firstEntityId, secondEntityId) != null;
        }
    }
}
