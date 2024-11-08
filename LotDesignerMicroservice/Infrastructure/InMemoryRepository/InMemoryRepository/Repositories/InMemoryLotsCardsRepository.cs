using LotDesignerMicroservice.Domain.Entities.Entities;
using LotDesignerMicroservice.Domain.RepositoriesAbstractions.Abstractions;
using LotDesignerMicroservice.Infrastructure.InMemoryRepository.Base;

namespace LotDesignerMicroservice.Infrastructure.InMemoryRepository.Repositories
{
    public class InMemoryLotsCardsRepository(IEnumerable<LotCard> lotsCards)
        : InMemoryRepository<LotCard, Guid>(lotsCards), ILotsCardsRepository
    {
        public Task<IEnumerable<LotCard>> GetLotsCardsBySeller(Seller seller, CancellationToken cancellationToken = default)
        {
            if (seller is null)
                throw new ArgumentNullException(nameof(seller));

            var lotsCards = Entities.Where(l => l.Seller.Equals(seller));

            return Task.FromResult(lotsCards);
        }
    }
}