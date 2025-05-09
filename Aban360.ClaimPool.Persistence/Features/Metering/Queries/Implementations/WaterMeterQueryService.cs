﻿using Aban360.ClaimPool.Domain.Features.Metering.Entities;
using Aban360.ClaimPool.Persistence.Contexts.Contracts;
using Aban360.ClaimPool.Persistence.Features.Metering.Queries.Contracts;
using Aban360.Common.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Aban360.ClaimPool.Persistence.Features.Metering.Queries.Implementations
{
    internal sealed class WaterMeterQueryService : IWaterMeterQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<WaterMeter> _wateMere;
        public WaterMeterQueryService(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.NotNull(nameof(_uow));

            _wateMere = _uow.Set<WaterMeter>();
            _wateMere.NotNull(nameof(_wateMere));
        }

        public async Task<WaterMeter> Get(int id)
        {
            return await _uow.FindOrThrowAsync<WaterMeter>(id);
        }

        public async Task<ICollection<WaterMeter>> Get()
        {
            return await _wateMere.ToListAsync();
        }
        public async Task<ICollection<WaterMeter>> Get(string fromDate, string toDate, short usageId
            , short individualTypeId, string fromBillId, string toBillId, int ZoneId)//individualTypeId,zoneId
        {
            return await _wateMere
                .Where(d => DateTime.Parse(d.InstallationDate) >= DateTime.Parse(fromDate) &
                       DateTime.Parse(d.InstallationDate) <= DateTime.Parse(toDate) &
                       d.Estate.UsageConsumtionId == usageId &
                       long.Parse(d.BillId) >= long.Parse(fromBillId) &
                       long.Parse(d.BillId) <= long.Parse(toBillId))
                .ToListAsync();
        }
    }
}
