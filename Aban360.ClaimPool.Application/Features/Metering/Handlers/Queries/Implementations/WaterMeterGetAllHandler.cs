﻿using Aban360.ClaimPool.Application.Features.Metering.Handlers.Queries.Contracts;
using Aban360.ClaimPool.Domain.Features.Metering.Dto.Queries;
using Aban360.ClaimPool.Domain.Features.Metering.Entities;
using Aban360.ClaimPool.Persistence.Features.Metering.Queries.Contracts;
using Aban360.Common.Extensions;
using AutoMapper;

namespace Aban360.ClaimPool.Application.Features.Metering.Handlers.Queries.Implementations
{
    internal sealed class WaterMeterGetAllHandler : IWaterMeterGetAllHandler
    {
        private readonly IMapper _mapper;
        private readonly IWaterMeterQueryService _queryService;
        public WaterMeterGetAllHandler(
            IMapper mapper,
            IWaterMeterQueryService queryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _queryService = queryService;
            _queryService.NotNull(nameof(queryService));
        }


        public async Task<ICollection<WaterMeterGetDto>> Handle(CancellationToken cancellationToken)
        {
            ICollection<WaterMeter> waterMeter = await _queryService.Get();
            if (waterMeter == null)
            {
                throw new InvalidDataException();
            }
            return _mapper.Map<ICollection<WaterMeterGetDto>>(waterMeter);
        }
    }
}
