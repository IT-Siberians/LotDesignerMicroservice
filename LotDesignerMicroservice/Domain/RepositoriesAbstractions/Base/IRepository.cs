using LotDesignerMicroservice.Domain.Entities.Base;

namespace LotDesignerMicroservice.Domain.RepositoriesAbstractions.Base
{
    public interface IRepository<TEntity, in TKey>
        where TEntity : Entity<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken);
        Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken);
        Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken);
        Task<bool> UpdateAsync(TEntity entity, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(TEntity entity, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(TKey id, CancellationToken cancellationToken);
    }
}
