﻿using Aban360.CalculationPool.Application.Features.Rule.Handlers.Queries.Contracts;
using Aban360.CalculationPool.Domain.Constants;
using Aban360.CalculationPool.Domain.Features.Rule.Dto.Queries;
using Aban360.CalculationPool.Domain.Features.Rule.Entities;
using Aban360.CalculationPool.Persistence.Features.Rule.Queries.Contracts;
using Aban360.Common.Extensions;
using AutoMapper;

namespace Aban360.CalculationPool.Application.Features.Rule.Handlers.Queries.Implementations
{
    internal sealed class TariffCalculationModeGetSingleHandler : ITariffCalculationModeGetSingleHandler
    {
        private readonly IMapper _mapper;
        private readonly ITariffCalculationModeQueryService _tariffCalculationModeQueryService;
        public TariffCalculationModeGetSingleHandler(
            IMapper mapper,
            ITariffCalculationModeQueryService tariffCalculationModeQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _tariffCalculationModeQueryService = tariffCalculationModeQueryService;
            _tariffCalculationModeQueryService.NotNull(nameof(tariffCalculationModeQueryService));
        }

        public async Task<TariffCalculationModeGetDto> Handle(TariffCalculationModeEnum id, CancellationToken cancellationToken)
        {
            TariffCalculationMode tariffCalculationMode = await _tariffCalculationModeQueryService.Get(id);
            return _mapper.Map<TariffCalculationModeGetDto>(tariffCalculationMode);
        }
    }
}
