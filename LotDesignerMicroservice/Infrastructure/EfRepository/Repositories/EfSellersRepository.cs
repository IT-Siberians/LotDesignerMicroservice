﻿using LotDesignerMicroservice.Domain.Entities.Entities;
using LotDesignerMicroservice.Domain.RepositoriesAbstractions.Abstractions;
using LotDesignerMicroservice.Infrastructure.EfRepository.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace LotDesignerMicroservice.Infrastructure.EfRepository.Repositories
{
    public class EfSellersRepository(ApplicationDbContext context)
        : EfRepository<Seller, Guid>(context), ISellersRepository
    {
        private readonly DbSet<Seller> _sellers = context.Set<Seller>();

        public async Task<Seller> GetByUsernameAsync(string username, CancellationToken cancellationToken = default)
        {
            var seller = await _sellers
                .FirstOrDefaultAsync(s => s.UserName.Value.Equals(username), cancellationToken);

            if (seller is null)
                throw new ArgumentNullException(nameof(seller), $"Not found seller with username {username}");

            return seller;
        }
    }
}
