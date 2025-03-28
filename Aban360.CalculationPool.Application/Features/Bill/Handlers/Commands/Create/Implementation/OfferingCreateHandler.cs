﻿using Aban360.CalculationPool.Application.Features.Bill.Handlers.Commands.Create.Contracts;
using Aban360.CalculationPool.Domain.Features.Bill.Dtos.Commands;
using Aban360.CalculationPool.Domain.Features.Bill.Entities;
using Aban360.CalculationPool.Persistence.Features.Bill.Commands.Contracts;
using Aban360.Common.Extensions;
using AutoMapper;

namespace Aban360.CalculationPool.Application.Features.Bil.Handlers.Commands.Create.Implementation
{
    internal sealed class OfferingCreateHandler : IOfferingCreateHandler
    {
        private readonly IMapper _mapper;
        private readonly IOfferingCommandService _offeringCommandService;
        public OfferingCreateHandler(
            IMapper mapper,
            IOfferingCommandService offeringCommandService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _offeringCommandService = offeringCommandService;
            _offeringCommandService.NotNull(nameof(offeringCommandService));
        }

        public async Task Handle(OfferingCreateDto createDto, CancellationToken cancellationToken)
        {
            Offering offering = _mapper.Map<Offering>(createDto);
            await _offeringCommandService.Add(offering);
        }
    }
}
