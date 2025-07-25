﻿namespace Aban360.ReportPool.Domain.Features.BuiltIns.WaterTransactions.Outputs
{
    public record UnreadHeaderOutputDto
    {
        public string FromReadingNumber { get; set; }
        public string ToReadingNumber { get; set; }
        public int PeriodCount { get; set; }
        public string  ReportDateJalali { get; set; }
        public int RecordCount { get; set; }
    }
}
