﻿using Aban360.ReportPool.Domain.Base;
using Aban360.ReportPool.Domain.Features.BuiltIns.ServiceLinkTransaction.Inputs;
using Aban360.ReportPool.Domain.Features.BuiltIns.ServiceLinkTransaction.Outputs;

namespace Aban360.ReportPool.Application.Features.BuiltsIns.ServiceLinkTransactions.Handlers.Contracts
{
    public interface IServiceLinkNetItemsSummaryHandler
    {
        Task<ReportOutput<ServiceLinkNetItemsHeaderOutputDto, ServiceLinkNetItemsSummaryDataOutputDto>> Handle(ServiceLinkNetItemsInputDto input, CancellationToken cancellationToken);
    }
}
