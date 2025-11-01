﻿using Aban360.Common.BaseEntities;
using Aban360.Common.Db.Dapper;
using Aban360.TaxPool.Domain.Features.MaaherSTP.Dto.RecieveDto;
using Aban360.TaxPool.Persistence.Features.MaaherTSP.Query.Contracts;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace Aban360.TaxPool.Persistence.Features.MaaherTSP.Query.Implementations
{
    internal sealed class MaaherQueryService : AbstractBaseConnection, IMaaherQueryService
    {
        public MaaherQueryService(IConfiguration configuration) :
            base(configuration)
        { }

        public async Task<MaaherErrorsDto> GetErrors(int errorCode)
        {
            string MaaherQuery = GetMaaherErrorsQuery();
            MaaherErrorsDto maaherErrors = await _sqlReportConnection.QueryFirstOrDefaultAsync<MaaherErrorsDto>(MaaherQuery, new { ErrorCode = errorCode });

            return maaherErrors;
        }

        private string GetMaaherErrorsQuery()
        {
            return @"Select *
                 From Aban360.TaxPool.MaaherErrors
                 Where ErrorCode=@ErrorCode";
        }
    }
}
