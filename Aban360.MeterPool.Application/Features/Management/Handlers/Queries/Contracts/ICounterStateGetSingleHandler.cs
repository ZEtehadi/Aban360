﻿using Aban360.MeterPool.Domain.Features.Management.Dtos.Queries;

namespace Aban360.MeterPool.Application.Features.Management.Handlers.Queries.Contracts
{
    public interface ICounterStateGetSingleHandler
    {
        Task<CounterStateGetDto> Handle(short id, CancellationToken cancellationToken);
    }
}
