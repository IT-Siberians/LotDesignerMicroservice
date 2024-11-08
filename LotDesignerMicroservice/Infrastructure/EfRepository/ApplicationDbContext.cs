using LotDesignerMicroservice.Domain.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace LotDesignerMicroservice.Infrastructure.EfRepository
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<LotCard> LotsCards { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}