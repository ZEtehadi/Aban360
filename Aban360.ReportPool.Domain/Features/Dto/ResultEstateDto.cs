﻿namespace Aban360.ReportPool.Persistence.Queries.Implementations
{
    public record ResultEstateDto
    {
        public int Premises { get; set; }
        public string X { get; set; }
        public string Y { get; set; }
        public int ImprovementsCommercial { get; set; }
        public int ImprovementsDomestic { get; set; }
        public int ImprovementsOther { get; set; }
        public int ImprovementsOverall { get; set; }
    }
}
