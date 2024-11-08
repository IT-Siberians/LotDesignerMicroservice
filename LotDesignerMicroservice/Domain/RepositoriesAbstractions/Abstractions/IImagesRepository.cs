using LotDesignerMicroservice.Domain.RepositoriesAbstractions.Base;
using LotDesignerMicroservice.Domain.Entities.Entities;

namespace LotDesignerMicroservice.Domain.RepositoriesAbstractions.Abstractions
{
    public interface IImagesRepository : IRepository<Image, Guid>
    {
        Task<IEnumerable<Image>> GetImagesByLotCardId(Guid lotCardId, CancellationToken cancellationToken);
    }
}
