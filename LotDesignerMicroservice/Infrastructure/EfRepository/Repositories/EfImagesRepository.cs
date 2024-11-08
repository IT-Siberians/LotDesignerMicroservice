using LotDesignerMicroservice.Domain.Entities.Entities;
using LotDesignerMicroservice.Domain.RepositoriesAbstractions.Abstractions;
using LotDesignerMicroservice.Infrastructure.EfRepository.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace LotDesignerMicroservice.Infrastructure.EfRepository.Repositories
{
    public class EfImagesRepository(ApplicationDbContext context)
        : EfRepository<Image, Guid>(context), IImagesRepository
    {
        private readonly DbSet<Image> _images = context.Set<Image>();

        public async Task<IEnumerable<Image>> GetImagesByLotCardId(Guid lotCardId, CancellationToken cancellationToken = default)
        {
            var lotCardImages = await _images
                .Include(c => c.LotCard)
                .Where(c => c.LotCard.Id.Equals(lotCardId))
                .ToListAsync(cancellationToken);

            return lotCardImages.AsEnumerable();
        }
    }
}