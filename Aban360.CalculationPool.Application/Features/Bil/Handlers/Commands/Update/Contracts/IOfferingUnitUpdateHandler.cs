﻿using Aban360.CalculationPool.Domain.Features.Bill.Dtos.Commands;

namespace Aban360.CalculationPool.Application.Features.Bil.Handlers.Commands.Update.Contracts
{
    public interface IOfferingUnitUpdateHandler
    {
        Task Handle(OfferingUnitUpdateDto updateDto, CancellationToken cancellationToken);
    }
}
