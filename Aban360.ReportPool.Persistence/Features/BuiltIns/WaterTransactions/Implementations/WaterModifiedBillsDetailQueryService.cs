﻿using Aban360.ReportPool.Domain.Base;
using Aban360.ReportPool.Domain.Features.BuiltIns.WaterTransactions.Inputs;
using Aban360.ReportPool.Domain.Features.BuiltIns.WaterTransactions.Outputs;
using Aban360.ReportPool.Persistence.Base;
using Aban360.ReportPool.Persistence.Features.BuiltIns.WaterTransactions.Contracts;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace Aban360.ReportPool.Persistence.Features.BuiltIns.WaterTransactions.Implementations
{
    internal sealed class WaterModifiedBillsDetailQueryService : AbstractBaseConnection, IWaterModifiedBillsDetailQueryService
    {
        public WaterModifiedBillsDetailQueryService(IConfiguration configuration)
            : base(configuration)
        { }

        public async Task<ReportOutput<WaterModifiedBillsHeaderOutputDto, WaterModifiedBillsDetailDataOutputDto>> GetInfo(WaterModifiedBillsInputDto input)
        {
            string modifiedBills = GetWaterModifiedBillsQuery();
            var @params = new
            {
                fromDate = input.FromDateJalali,
                toDate = input.ToDateJalali,
                typeCode = input.TypeIds//ZoneId?
            };
            IEnumerable<WaterModifiedBillsDetailDataOutputDto> modifiedBillsData = await _sqlReportConnection.QueryAsync<WaterModifiedBillsDetailDataOutputDto>(modifiedBills,@params);
            WaterModifiedBillsHeaderOutputDto modifiedBillsHeader = new WaterModifiedBillsHeaderOutputDto()
            {
                FromDateJalali = input.FromDateJalali,
                ToDateJalali = input.ToDateJalali,
                ReportDateJalali = DateTime.Now.ToShortDateString(),
                RecordCount = modifiedBillsData.Count(),
                Payable = modifiedBillsData.Sum(x => x.Payable),
                SumItems = modifiedBillsData.Sum(x => x.SumItems),
            };

            var result = new ReportOutput<WaterModifiedBillsHeaderOutputDto, WaterModifiedBillsDetailDataOutputDto>(ReportLiterals.WaterModifiedBillsDetail, modifiedBillsHeader, modifiedBillsData);
            return result;
        }

        private string GetWaterModifiedBillsQuery()
        {
            return @"Select
                    	b.ZoneTitle,
	                    b.CustomerNumber,
	                    b.UsageTitle AS UsageSellTitle,
	                    b.RegisterDay AS Date,
	                    b.Payable,
	                    b.SumItems
                    From [CustomerWarehouse].dbo.Bills b
                    Where	
                    	b.RegisterDay BETWEEN @fromDate AND @toDate AND
                    	b.TypeCode IN @typeCode";
        }
    }
}
