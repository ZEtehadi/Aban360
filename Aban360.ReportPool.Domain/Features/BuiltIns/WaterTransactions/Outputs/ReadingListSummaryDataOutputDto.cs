﻿namespace Aban360.ReportPool.Domain.Features.BuiltIns.WaterTransactions.Outputs
{
    public record ReadingListSummaryDataOutputDto
    {
        public string ZoneTitle { get; set; }
        public int ReadingCount { get; set; }
        public int CloseCount { get; set; }
        public int ObstacleCount { get; set; }
        public int ReplacementBranchCount { get; set; }
        public int AdvancePaymentCount { get; set; }
       // public int SettlementCount { get; set; }
    }
}
