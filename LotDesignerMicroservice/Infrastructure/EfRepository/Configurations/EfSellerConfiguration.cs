using LotDesignerMicroservice.Domain.Entities.Entities;
using LotDesignerMicroservice.Domain.ValueObjects.Constants;
using LotDesignerMicroservice.Domain.ValueObjects.StringObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LotDesignerMicroservice.Infrastructure.EfRepository.Configurations
{
    public class EfSellerConfiguration : IEntityTypeConfiguration<Seller>
    {
        public void Configure(EntityTypeBuilder<Seller> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.UserName)
                .IsRequired()
                .HasMaxLength(UserNameConstants.MAX_LENGHT)
                .HasConversion(
                    username => username.Value,
                    value => new UserName(value)
                );

            builder.HasMany<LotCard>("_lotCards").WithOne(l => l.Seller);
        }
    }
}