using LotDesignerMicroservice.Domain.Entities.Entities;
using LotDesignerMicroservice.Domain.RepositoriesAbstractions.Abstractions;
using LotDesignerMicroservice.Infrastructure.InMemoryRepository.Base;

namespace LotDesignerMicroservice.Infrastructure.InMemoryRepository.Repositories
{
    public class InMemorySellersRepository(IEnumerable<Seller> sellers)
        : InMemoryRepository<Seller, Guid>(sellers), ISellersRepository
    {
        public Task<Seller?> GetByUsernameAsync(string username, CancellationToken cancellationToken)
        {
            var seller = Entities.FirstOrDefault(s => s.UserName.Value.Equals(username));
            return Task.FromResult(seller);
        }
    }
}