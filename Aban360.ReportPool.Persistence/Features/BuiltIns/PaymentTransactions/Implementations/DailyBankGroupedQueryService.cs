﻿using Aban360.ReportPool.Domain.Base;
using Aban360.ReportPool.Domain.Features.BuiltIns.PaymentsTransactions.Inputs;
using Aban360.ReportPool.Domain.Features.BuiltIns.PaymentsTransactions.Outputs;
using Aban360.ReportPool.Persistence.Base;
using Aban360.ReportPool.Persistence.Features.BuiltIns.PaymentTransactions.Contracts;
using Dapper;
using DNTPersianUtils.Core;
using Microsoft.Extensions.Configuration;

namespace Aban360.ReportPool.Persistence.Features.BuiltIns.PaymentTransactions.Implementations
{
    internal sealed class DailyBankGroupedQueryService : AbstractBaseConnection, IDailyBankGroupedQueryService
    {
        public DailyBankGroupedQueryService(IConfiguration configuration)
            : base(configuration)
        { }

        public async Task<ReportOutput<DailyBankGroupedHeaderOutputDto, DailyBankGroupedDataOutputDto>> GetInfo(DailyBankGroupedInputDto input)
        {
            string dailyBankGroupeds = GetDailyBankGroupedQuery(input.ZoneIds?.Any()==true);
            var @params = new
            { 
                FromDate=input.FromDateJalali,
                ToDate=input.ToDateJalali,
                FromAmount=input.FromAmount,
                ToAmount=input.ToAmount,
                ZoneIds=input.ZoneIds
            };
            IEnumerable<DailyBankGroupedDataOutputDto> dailyBankGroupedData = await _sqlReportConnection.QueryAsync<DailyBankGroupedDataOutputDto>(dailyBankGroupeds,@params);
            DailyBankGroupedHeaderOutputDto dailyBankGroupedHeader = new DailyBankGroupedHeaderOutputDto()
            {
                FromDateJalali=input.FromDateJalali,
                ToDateJalali=input.ToDateJalali,
                FromAmount=input.FromAmount,
                ToAmount=input.ToAmount,
                ReportDateJalali=DateTime.Now.ToShortPersianDateString(),
                RecordCount= (dailyBankGroupedData is not null && dailyBankGroupedData.Any()) ? dailyBankGroupedData.Count() : 0,
            };

            var result = new ReportOutput<DailyBankGroupedHeaderOutputDto, DailyBankGroupedDataOutputDto>(ReportLiterals.DailyBankGrouped, dailyBankGroupedHeader, dailyBankGroupedData);
            return result;
        }

        private string GetDailyBankGroupedQuery(bool hasZone)
        {
            string zoneQuery = hasZone ? "AND p.ZoneId IN @ZoneIds" : string.Empty;

            return @$"Select 
                    	p.RegisterDay AS RegisterDate, 
                    	p.RegisterDay AS BankDate,
                        p.ZoneTitle AS ZoneTitle,
                        p.BankName AS BankName,
                    	COUNT(p.RegisterDay) AS WaterCount,
                    	SUM(p.Amount) AS WaterAmount,
                    	COUNT(p.RegisterDay) AS ServiceLinkCount,
                    	SUM(p.Amount) AS ServiceLinkAmount,
                    	COUNT(p.RegisterDay) AS TotalCount,
                    	SUM(p.Amount) AS TotalAmount
                    From [CustomerWarehouse].dbo.Payments p
                    WHERE 
                    	(
                            (@FromDate IS NOT NULL AND @ToDate IS NOT NULL AND p.RegisterDay BETWEEN @FromDate AND @ToDate)
                            OR (@FromDate IS NULL AND @ToDate IS NULL)
                        )
                        AND 
                        (
                            (@FromAmount IS NOT NULL AND @ToAmount IS NOT NULL AND p.Amount BETWEEN @FromAmount AND @ToAmount)
                            OR (@FromAmount IS NULL AND @ToAmount IS NULL)
                        )
                    {zoneQuery}
                    GROUP BY p.RegisterDay,
                             p.BankName,
                             p.ZoneTitle";
        }
    }
}
