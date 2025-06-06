﻿using Aban360.ClaimPool.Domain.Features.Draft.Dto.Commands;

namespace Aban360.ClaimPool.Application.Features.Draft.Handlers.Commands.Update.Contracts
{
    public interface IRequestTrackingUpdateHandler
    {
        Task Handle(RequestTrackingUpdateDto updateDto, CancellationToken cancellationToken);
    }
}
