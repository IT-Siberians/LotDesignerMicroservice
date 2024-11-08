using LotDesignerMicroservice.Domain.Entities.Base;
using LotDesignerMicroservice.Domain.RepositoriesAbstractions.Base;
using System.Collections.Immutable;

namespace LotDesignerMicroservice.Infrastructure.InMemoryRepository.Base
{
    public abstract class InMemoryRepository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : Entity<TKey> where TKey : struct, IEquatable<TKey>
    {
        public InMemoryRepository(IEnumerable<TEntity> entities)
        {
            if (entities is null)
                Entities = [];
            else
                Entities = entities.ToImmutableList();
        }

        protected ImmutableList<TEntity> Entities { get; set; }

        public virtual Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            EntityValidation(entity);
            Entities.Add(entity);
            return Task.FromResult(entity);
        } 

        public virtual Task<bool> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            EntityValidation(entity);
            Entities.Remove(entity);
            return Task.FromResult(true);
        }

        public virtual async Task<bool> DeleteAsync(TKey id, CancellationToken cancellationToken = default)
        {
            var entity = await GetByIdAsync(id, cancellationToken);
            return await DeleteAsync(entity!, cancellationToken);
        }

        public virtual Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
            => Task.FromResult(Entities.AsEnumerable());

        public virtual Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken = default)
        {
            var foundEntity = Entities.FirstOrDefault(x => x.Id.Equals(id));
            return Task.FromResult(foundEntity);
        }

        public virtual Task<bool> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            EntityValidation(entity);
            var foundEntity = Entities.FirstOrDefault(x => x.Id.Equals(entity.Id));

            if (foundEntity is null)
                Task.FromResult(false);

            Entities.Replace(foundEntity, entity);
            return Task.FromResult(true);
        }

        protected virtual void EntityValidation(TEntity entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity), "Received entity is null");
        }
    }
}
