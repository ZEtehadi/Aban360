﻿using Aban360.CalculationPool.Domain.Features.Bill.Dtos.Commands;

namespace Aban360.CalculationPool.Application.Features.Bill.Handlers.Commands.Create.Contracts
{
    public interface ITariffCalculationHandler
    {
        Task<IntervalCalculationResultWrapper> Test(TariffTestInput tariffTestInput,CancellationToken cancellationToken);
    }
}