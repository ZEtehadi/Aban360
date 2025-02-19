﻿using Aban360.LocationPool.Domain.Features.MainHierarchy.Entities;

namespace Aban360.LocationPool.Persistence.Features.MainHierarchy.Commands.Contracts
{
    public interface IZoneCommandService
    {
        Task Add(Zone zone);
        Task Remove(Zone zone);
    }
}
