﻿namespace Aban360.ReportPool.Persistence.Queries.Implementations
{
    public interface IFlatSummeryQueryService
    {
        Task<IEnumerable<ResultFlatDto>> GetInfo(string billId);
    }
}
