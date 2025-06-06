﻿using Aban360.ClaimPool.Domain.Features.Land.Entities;
using Aban360.ClaimPool.Persistence.Contexts.Contracts;
using Aban360.ClaimPool.Persistence.Features.Land.Queries.Contracts;
using Aban360.Common.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Aban360.UserPool.Persistence.Features.TimeTable.Queries.Implementations
{
    internal sealed class UsageLevel2QueryService : IUsageLevel2QueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<UsageLevel2> _usageLevel2;
        public UsageLevel2QueryService(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.NotNull(nameof(_uow));

            _usageLevel2 = _uow.Set<UsageLevel2>();
            _usageLevel2.NotNull(nameof(_usageLevel2));
        }

        public async Task<UsageLevel2> Get(short id)
        {
            return await _usageLevel2
                .Include(u => u.UsageLevel1)
                .Where(u => u.Id == id)
                .SingleAsync();
        }

        public async Task<ICollection<UsageLevel2>> Get()
        {
            return await _usageLevel2
                .Include(u => u.UsageLevel1)
                .ToListAsync();
        }
    }
}
