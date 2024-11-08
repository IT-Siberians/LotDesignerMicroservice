using LotDesignerMicroservice.Domain.Entities.Entities;
using LotDesignerMicroservice.Domain.RepositoriesAbstractions.Abstractions;
using LotDesignerMicroservice.Infrastructure.InMemoryRepository.Base;

namespace LotDesignerMicroservice.Infrastructure.InMemoryRepository.Repositories
{
    public class InMemoryImagesRepository(IEnumerable<Image> images)
        : InMemoryRepository<Image, Guid>(images), IImagesRepository
    {
        public Task<IEnumerable<Image>> GetImagesByLotCardId(Guid lotCardId, CancellationToken cancellationToken = default)
            => Task.FromResult(Entities.Where(x => x.LotCard.Id.Equals(lotCardId)));
    }
}