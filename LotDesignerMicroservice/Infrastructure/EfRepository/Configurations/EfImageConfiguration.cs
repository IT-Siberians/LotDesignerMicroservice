using LotDesignerMicroservice.Domain.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LotDesignerMicroservice.Infrastructure.EfRepository.Repositories
{
    public class EfImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Url)
                .IsRequired()
                .HasMaxLength(500)
                .HasConversion(
                    url => url.ToString(),
                    value => new Uri(value)
                );

            builder.HasOne(x => x.LotCard)
                .WithMany(x => x.Images)
                .IsRequired();
        }
    }
}
