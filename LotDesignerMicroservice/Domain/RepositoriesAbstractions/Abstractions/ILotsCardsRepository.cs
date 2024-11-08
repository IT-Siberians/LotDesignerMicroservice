using LotDesignerMicroservice.Domain.RepositoriesAbstractions.Base;
using LotDesignerMicroservice.Domain.Entities.Entities;

namespace LotDesignerMicroservice.Domain.RepositoriesAbstractions.Abstractions
{
    public interface ILotsCardsRepository : IRepository<LotCard, Guid>
    {
        Task<IEnumerable<LotCard>> GetLotsCardsBySeller(Seller seller, CancellationToken cancellationToken);
    }
}
