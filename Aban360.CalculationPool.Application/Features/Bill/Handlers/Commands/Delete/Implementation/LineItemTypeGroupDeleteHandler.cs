﻿using Aban360.CalculationPool.Application.Features.Bill.Handlers.Commands.Delete.Contracts;
using Aban360.CalculationPool.Domain.Features.Bill.Dtos.Commands;
using Aban360.CalculationPool.Domain.Features.Bill.Entities;
using Aban360.CalculationPool.Persistence.Features.Bill.Commands.Contracts;
using Aban360.CalculationPool.Persistence.Features.Bill.Queries.Contracts;
using Aban360.Common.Extensions;

namespace Aban360.CalculationPool.Application.Features.Bill.Handlers.Commands.Delete.Implementation
{
    internal sealed class LineItemTypeGroupDeleteHandler : ILineItemTypeGroupDeleteHandler
    {
        private readonly ILineItemTypeGroupCommandService _lineItemTypeGroupCommandService;
        private readonly ILineItemTypeGroupQueryService _lineItemTypeGroupQueryService;
        public LineItemTypeGroupDeleteHandler(
            ILineItemTypeGroupCommandService lineItemTypeGroupCommandService,
            ILineItemTypeGroupQueryService lineItemTypeGroupQueryService)
        {
            _lineItemTypeGroupCommandService = lineItemTypeGroupCommandService;
            _lineItemTypeGroupCommandService.NotNull(nameof(lineItemTypeGroupCommandService));

            _lineItemTypeGroupQueryService = lineItemTypeGroupQueryService;
            _lineItemTypeGroupQueryService.NotNull(nameof(lineItemTypeGroupQueryService));
        }

        public async Task Handle(LineItemTypeGroupDeleteDto deleteDto, CancellationToken cancellationToken)
        {
            LineItemTypeGroup lineItemTypeGroup = await _lineItemTypeGroupQueryService.Get(deleteDto.Id);
            await _lineItemTypeGroupCommandService.Remove(lineItemTypeGroup);
        }
    }
}
