﻿namespace Aban360.ReportPool.Domain.Features.BuiltIns.ServiceLinkTransaction.Outputs
{
    public record ServiceLinkModifiedBillsHeaderOutputDto
    {
        public string FromDateJalali { get; set; }
        public string ToDateJalali { get; set; }
        public string ReportDateJalali { get; set; }
        public int RecordCount { get; set; }

        public long SumAmount { get; set; }
        public long SumOffAmount { get; set; }
        public long SumFinalAmount { get; set; }
    }
}
