﻿using Aban360.ReportPool.Domain.Base;
using Aban360.ReportPool.Domain.Features.BuiltIns.CustomersTransactions.Inputs;
using Aban360.ReportPool.Domain.Features.BuiltIns.CustomersTransactions.Outputs;

namespace Aban360.ReportPool.Application.Features.BuiltsIns.CustomersTransactions.Handlers.Contracts
{
    public interface IHandoverSummaryHandler
    {
        Task<ReportOutput<HandoverHeaderOutputDto, HandoverSummaryDataOutputDto>> Handle(HandoverInputDto input, CancellationToken cancellationToken);
    }
}
