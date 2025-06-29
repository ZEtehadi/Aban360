﻿namespace Aban360.ReportPool.Domain.Features.BuiltIns.CustomersTransactions.Outputs
{
    public record NonPermanentBranchHeaderOutputDto
    {
        public string FromDateJalali { get; set; }
        public string ToDateJalali { get; set; }

        public string ReportDate { get; set; }
        public int RecordCount { get; set; }
    }
}
