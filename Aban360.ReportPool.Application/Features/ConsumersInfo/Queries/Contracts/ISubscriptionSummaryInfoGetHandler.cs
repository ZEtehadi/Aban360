﻿using Aban360.ReportPool.Domain.Features.ConsumersInfo.Dto;

namespace Aban360.ReportPool.Application.Features.ConsumersInfo.Queries.Contracts
{
    public interface ISubscriptionSummaryInfoGetHandler
    {
        Task<ConsumerSummaryDto> Handle(string billId,CancellationToken cancellationToken);
    }
}
