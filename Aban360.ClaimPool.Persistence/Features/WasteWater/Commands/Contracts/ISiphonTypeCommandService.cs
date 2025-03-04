﻿using Aban360.ClaimPool.Domain.Features.WasteWater.Entities;

namespace Aban360.ClaimPool.Persistence.Features.WasteWater.Commands.Contracts
{
    public interface ISiphonTypeCommandService
    {
        Task Add(SiphonType siphonType);
        Task Remove(SiphonType siphonType);
    }
}
