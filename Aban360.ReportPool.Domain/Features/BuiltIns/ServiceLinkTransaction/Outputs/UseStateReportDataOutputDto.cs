﻿namespace Aban360.ReportPool.Domain.Features.BuiltIns.ServiceLinkTransaction.Outputs
{
    public record UseStateReportDataOutputDto
    {
        public int CustomerNumber { get; set; }
        public string ReadingNumber { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string Surname { get; set; } = default!;
        public string UsageTitle { get; set; } = default!;
        public string MeterDiameterTitle { get; set; } = default!;
        public string EventDateJalali { get; set; } = default!;
        public long DebtAmount { get; set; }
        public string Address { get; set; } = default!;
        public string ZoneTitle { get; set; } = default!;
        public string DeletionStateTitle { get; set; } = default!;
        public int DomesticUnit { get; set; }
        public int CommercialUnit { get; set; }
        public int OtherUnit { get; set; }
        public string BillId { get; set; } = default!;
    }
}