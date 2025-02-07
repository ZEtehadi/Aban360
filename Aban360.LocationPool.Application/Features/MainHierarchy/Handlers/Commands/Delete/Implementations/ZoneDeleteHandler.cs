﻿using Aban360.Common.Extensions;
using Aban360.LocationPool.Application.Features.MainHierarchy.Handlers.Commands.Delete.Contracts;
using Aban360.LocationPool.Domain.Features.MainHierarchy.Dto.Commands;
using Aban360.LocationPool.Persistence.Features.MainHierarchy.Commands.Contracts;
using Aban360.LocationPool.Persistence.Features.MainHierarchy.Queries.Contracts;

namespace Aban360.LocationPool.Application.Features.MainHierarchy.Handlers.Commands.Delete.Implementations
{
    public class ZoneDeleteHandler : IZoneDeleteHandler
    {
        private readonly IZoneQueryService _zoneQueryService;
        private readonly IZoneCommandService _zoneCommandService;
        public ZoneDeleteHandler(
           IZoneQueryService zoneQueryService,
            IZoneCommandService zoneCommandService)
        {
            _zoneQueryService = zoneQueryService;
            _zoneQueryService.NotNull(nameof(zoneQueryService));

            _zoneCommandService = zoneCommandService;
            _zoneCommandService.NotNull(nameof(zoneCommandService));
        }

        public async Task Handle(ZoneDeleteDto deleteDto, CancellationToken cancellationToken)
        {
            var zone = await _zoneQueryService.Get(deleteDto.Id);
            if (zone == null)
            {
                throw new InvalidDataException();
            }
            await _zoneCommandService.Remove(zone);
        }
    }
}
