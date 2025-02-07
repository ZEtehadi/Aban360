﻿using Aban360.LocationPool.Domain.Features.MainHierarchy.Dto.Commands;

namespace Aban360.LocationPool.Application.Features.MainHierarchy.Handlers.Commands.Delete.Contracts
{
    public interface IMunicipalityDeleteHandler
    {
        Task Handel(MunicipalityDeleteDto deleteDto, CancellationToken cancellationToken);
    }
}
