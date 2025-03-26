﻿using Aban360.Common.Extensions;
using Aban360.UserPool.Application.Features.TimeTable.Handlers.Commands.Update.Contracts;
using Aban360.UserPool.Domain.Features.TimeTable.Dto.Commands;
using Aban360.UserPool.Persistence.Features.TimeTable.Queries.Contracts;
using AutoMapper;

namespace Aban360.UserPool.Application.Features.TimeTable.Handlers.Commands.Update.Implementations
{
    internal sealed class UsageLevel3UpdateHandler : IUsageLevel3UpdateHandler
    {
        private readonly IMapper _mapper;
        private readonly IUsageLevel3QueryService _usageLevel3QueryService;
        public UsageLevel3UpdateHandler(
            IMapper mapper,
            IUsageLevel3QueryService usageLevel3QueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));

            _usageLevel3QueryService = usageLevel3QueryService;
            _usageLevel3QueryService.NotNull(nameof(_usageLevel3QueryService));
        }

        public async Task Handle(UsageLevel3UpdateDto updateDto, CancellationToken cancellationToken)
        {
            var usageLevel3 = await _usageLevel3QueryService.Get(updateDto.Id);
            _mapper.Map(updateDto, usageLevel3);
        }
    }
}
