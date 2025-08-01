﻿using Aban360.OldCalcPool.Domain.Features.Rules.Dto.Queries;

namespace Aban360.OldCalcPool.Persistence.Features.Rules.Queries.Contracts
{
    public interface IZaribByDateAndZoneIdQueryService
    {
        Task<ZaribGetDto> Get(ZaribInputDto input);
    }
}
