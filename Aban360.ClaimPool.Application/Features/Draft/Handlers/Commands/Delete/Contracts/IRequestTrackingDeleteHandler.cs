﻿using Aban360.ClaimPool.Domain.Features.Draft.Dto.Commands;
using Aban360.Common.ApplicationUser;

namespace Aban360.ClaimPool.Application.Features.Draft.Handlers.Commands.Delete.Contracts
{
    public interface IRequestTrackingDeleteHandler
    {
        Task Handle(RequestTrackingDeleteDto deleteDto, CancellationToken cancellationToken);
    }
}
