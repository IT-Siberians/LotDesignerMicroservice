using LotDesignerMicroservice.Domain.RepositoriesAbstractions.Base;
using LotDesignerMicroservice.Domain.Entities.Entities;

namespace LotDesignerMicroservice.Domain.RepositoriesAbstractions.Abstractions
{
    public interface ISellersRepository : IRepository<Seller, Guid>
    {
        Task<Seller> GetByUsernameAsync(string username, CancellationToken cancellationToken);
    }
}
