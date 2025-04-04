﻿using Aban360.ClaimPool.Application.Features.Land.Handlers.Commands.Update.Contracts;
using Aban360.ClaimPool.Domain.Features.Land.Dto.Commands;
using Aban360.ClaimPool.Persistence.Features.Land.Queries.Contracts;
using Aban360.Common.Extensions;
using AutoMapper;

namespace Aban360.ClaimPool.Application.Features.Land.Handlers.Commands.Update.Implementations
{
    internal sealed class UsageLevel1UpdateHandler : IUsageLevel1UpdateHandler
    {
        private readonly IMapper _mapper;
        private readonly IUsageLevel1QueryService _usageLevel1QueryService;
        public UsageLevel1UpdateHandler(
            IMapper mapper,
            IUsageLevel1QueryService usageLevel1QueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));

            _usageLevel1QueryService = usageLevel1QueryService;
            _usageLevel1QueryService.NotNull(nameof(_usageLevel1QueryService));
        }

        public async Task Handle(UsageLevel1UpdateDto updateDto, CancellationToken cancellationToken)
        {
            var usageLevel1 = await _usageLevel1QueryService.Get(updateDto.Id);
            _mapper.Map(updateDto, usageLevel1);
        }
    }
}
