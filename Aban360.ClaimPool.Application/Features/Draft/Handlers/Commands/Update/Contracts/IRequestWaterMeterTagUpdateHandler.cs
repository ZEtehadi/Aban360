﻿using Aban360.ClaimPool.Domain.Features.Draft.Dto.Commands;

namespace Aban360.ClaimPool.Application.Features.Draft.Handlers.Commands.Update.Contracts
{
    public interface IRequestWaterMeterTagUpdateHandler
    {
        Task Handle(WaterMeterTagRequestUpdateDto updateDto, CancellationToken cancellationToken);
    }
}
