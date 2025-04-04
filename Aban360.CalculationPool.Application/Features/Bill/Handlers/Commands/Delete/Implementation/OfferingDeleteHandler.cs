﻿using Aban360.CalculationPool.Application.Features.Bill.Handlers.Commands.Delete.Contracts;
using Aban360.CalculationPool.Domain.Features.Bill.Dtos.Commands;
using Aban360.CalculationPool.Domain.Features.Bill.Entities;
using Aban360.CalculationPool.Persistence.Features.Bill.Commands.Contracts;
using Aban360.CalculationPool.Persistence.Features.Bill.Queries.Contracts;
using Aban360.Common.Extensions;

namespace Aban360.CalculationPool.Application.Features.Bill.Handlers.Commands.Delete.Implementation
{
    internal sealed class OfferingDeleteHandler : IOfferingDeleteHandler
    {
        private readonly IOfferingCommandService _offeringCommandService;
        private readonly IOfferingQueryService _offeringQueryService;
        public OfferingDeleteHandler(
            IOfferingCommandService offeringCommandService,
            IOfferingQueryService offeringQueryService)
        {
            _offeringCommandService = offeringCommandService;
            _offeringCommandService.NotNull(nameof(offeringCommandService));

            _offeringQueryService = offeringQueryService;
            _offeringQueryService.NotNull(nameof(offeringQueryService));
        }

        public async Task Handle(OfferingDeleteDto deleteDto, CancellationToken cancellationToken)
        {
            Offering offering = await _offeringQueryService.Get(deleteDto.Id);
            await _offeringCommandService.Remove(offering);
        }
    }
}
