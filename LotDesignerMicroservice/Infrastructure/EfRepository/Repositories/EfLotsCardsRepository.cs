using LotDesignerMicroservice.Domain.Entities.Entities;
using LotDesignerMicroservice.Domain.RepositoriesAbstractions.Abstractions;
using LotDesignerMicroservice.Infrastructure.EfRepository.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace LotDesignerMicroservice.Infrastructure.EfRepository.Repositories
{
    public class EfLotsCardsRepository(ApplicationDbContext context)
        : EfRepository<LotCard, Guid>(context), ILotsCardsRepository
    {
        private readonly DbSet<LotCard> _lotsCards = context.Set<LotCard>();

        public async Task<IEnumerable<LotCard>> GetLotsCardsBySeller(Seller seller, CancellationToken cancellationToken = default)
        {
            if (seller is null)
                throw new ArgumentNullException(nameof(seller));

            var lotsCards = await _lotsCards
                .Include(s => s.Seller)
                .Where(l => l.Seller.Equals(seller))
                .ToListAsync(cancellationToken);

            return lotsCards.AsEnumerable();
        }
    }
}