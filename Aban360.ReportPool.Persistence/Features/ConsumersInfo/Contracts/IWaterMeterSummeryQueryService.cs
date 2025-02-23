﻿namespace Aban360.ReportPool.Persistence.Queries.Implementations
{
    public interface IWaterMeterSummeryQueryService
    {
        Task<IEnumerable<WaterMeterSummaryDto>> GetInfo(string billId, short meterUseTypeId);
    }
}
