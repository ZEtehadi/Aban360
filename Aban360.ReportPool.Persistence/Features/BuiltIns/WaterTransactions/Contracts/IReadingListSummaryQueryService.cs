﻿using Aban360.ReportPool.Domain.Base;
using Aban360.ReportPool.Domain.Features.BuiltIns.WaterTransactions.Inputs;
using Aban360.ReportPool.Domain.Features.BuiltIns.WaterTransactions.Outputs;

namespace Aban360.ReportPool.Persistence.Features.BuiltIns.WaterTransactions.Contracts
{
    public interface IReadingListSummaryQueryService
    {
        Task<ReportOutput<ReadingListHeaderOutputDto, ReadingListSummaryDataOutputDto>> GetInfo(ReadingListInputDto input);
    }
}
