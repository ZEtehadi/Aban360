﻿using Aban360.ReportPool.Domain.Features.ConsumersInfo.Dto;
using Aban360.ReportPool.Persistence.Base;
using Dapper;
using Microsoft.Extensions.Configuration;
using Aban360.Common.Db.Exceptions;

namespace Aban360.ReportPool.Persistence.Queries.Implementations
{
    internal class WaterMeterSummeryQueryService : AbstractBaseConnection, IWaterMeterSummeryQueryService
    {
        public WaterMeterSummeryQueryService(IConfiguration configuration)
            :base(configuration)
        {
        }
        public async Task<IEnumerable<WaterMeterSummaryDto>> GetInfo(string billId, short meterUseTypeId)
        {
            string estateQuery = GetWaterMetereSummeryDtoQuery();
            IEnumerable<WaterMeterSummaryDto> result = await _sqlConnection.QueryAsync<WaterMeterSummaryDto>(estateQuery , new { billId = billId, meterUseTypeId = meterUseTypeId });
            if (!result.Any())
                throw new InvalidIdException();
            return result;
        }

        private string GetWaterMetereSummeryDtoQuery()
        {
            return @"SELECT 
                      W.Id,
                      W.BodySerial,
                      W.InstallationDate,
                      MUT.Title as MeterUseTypeTitle,
                      MD.Title as MeterDiameterTitle
                    FROM [ClaimPool].WaterMeter W
                    JOIN [ClaimPool].MeterUseType MUT on W.MeterUseTypeId=MUT.Id
                    JOIN [ClaimPool].MeterDiameter MD on W.MeterDiameterId=MD.Id
                    WHERE W.BillId=@billId and MUT.Id=@meterUseTypeId";
        }
    }
}
