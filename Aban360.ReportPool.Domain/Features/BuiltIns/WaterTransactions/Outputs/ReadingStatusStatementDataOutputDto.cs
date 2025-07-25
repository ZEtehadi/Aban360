﻿namespace Aban360.ReportPool.Domain.Features.BuiltIns.WaterTransactions.Outputs
{
    public record ReadingStatusStatementDataOutputDto
    {
        public string ZoneTitle { get; set; }
        public string EventDateJalali { get; set; }
        public int ReadingNet { get; set; }
        public int Closed { get; set; }
        public int Obstacle { get; set; }
        public int Temporarily{ get; set; }
        public int AllCount { get; set; }
        public int Ruined { get; set; }
        //public int Settlement { get; set; }
    }
}