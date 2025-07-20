﻿using Aban360.ReportPool.Domain.Features.BuiltIns.CustomersTransactions.Outputs;

namespace Aban360.ReportPool.Application.Features.BuiltsIns.CustomersTransactions.Handlers.Contracts
{
    public interface IZoneAllHandler
    {
        Task<IEnumerable<UserZoneIdsOutputDto>> Handle(CancellationToken cancellationToken);
    }
}
