﻿using Aban360.ClaimPool.Domain.Features.Land.Entities;
using Aban360.ClaimPool.Persistence.Contexts.Contracts;
using Aban360.ClaimPool.Persistence.Features.Land.Queries.Contracts;
using Aban360.Common.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Aban360.ClaimPool.Persistence.Features.Land.Queries.Implementations
{
    internal sealed class FlatQueryService : IFlatQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Flat> _flat;
        public FlatQueryService(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.NotNull(nameof(_uow));

            _flat = _uow.Set<Flat>();
            _flat.NotNull(nameof(_flat));
        }

        public async Task<Flat> Get(int id)
        {
            return await _flat
                .Include(f => f.Estate)
                .Where(f => f.Id == id)
                .SingleAsync();
        }

        public async Task<ICollection<Flat>> Get()
        {
            return await _flat
                .Include(f => f.Estate)
                .ToListAsync();
        }
    }
}
