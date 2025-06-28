﻿namespace Aban360.ClaimPool.Domain.Features.Land.Dto.Commands
{
    public record SubscriptionAssignmentUpdateDto
    {
        public string BillId { get; set; }
        public string X { get; set; }
        public string Y { get; set; }
        public string ReadingNumber { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string Address { get; set; }
    }
}
