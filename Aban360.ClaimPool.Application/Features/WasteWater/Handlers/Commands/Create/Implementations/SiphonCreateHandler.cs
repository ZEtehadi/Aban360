﻿using Aban360.ClaimPool.Application.Features.WasteWater.Handlers.Commands.Create.Contracts;
using Aban360.ClaimPool.Domain.Features.WasteWater.Dto.Commands;
using Aban360.ClaimPool.Domain.Features.WasteWater.Entities;
using Aban360.ClaimPool.Persistence.Features.WasteWater.Commands.Contracts;
using Aban360.Common.Extensions;
using AutoMapper;

namespace Aban360.ClaimPool.Application.Features.WasteWater.Handlers.Commands.Create.Implementations
{
    internal sealed class SiphonCreateHandler : ISiphonCreateHandler
    {
        private readonly IMapper _mapper;
        private readonly ISiphonCommandService _commandService;
        public SiphonCreateHandler(
            IMapper mapper,
            ISiphonCommandService commandService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _commandService = commandService;
            _commandService.NotNull(nameof(commandService));
        }

        public async Task Handle(SiphonCreateDto createDto, CancellationToken cancellationToken)
        {
            Siphon siphon = _mapper.Map<Siphon>(createDto);

            siphon.ValidFrom = DateTime.Now;
            siphon.InsertLogInfo = "SampleLogInfo";
            siphon.Hash = "SmapleHash";
            await _commandService.Add(siphon);
        }
    }
}
