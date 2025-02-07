﻿using Aban360.LocationPool.Domain.Features.MainHierarchy.Dto.Queries;

namespace Aban360.LocationPool.Application.Features.MainHierarchy.Handlers.Queries.Contracts
{
    public interface IHeadquarterGetAllHandler
    {
        Task<ICollection<HeadquarterGetDto>> Handle(CancellationToken cancellationToken);
    }
}
