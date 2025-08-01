﻿using Aban360.Common.Db.Dapper;
using Aban360.OldCalcPool.Domain.Features.Rules.Dto.Commands;
using Aban360.OldCalcPool.Persistence.Features.Rules.Commands.Contracts;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace Aban360.OldCalcPool.Persistence.Features.Rules.Commands.Implementations
{
    internal sealed class Table1CreateService : AbstractBaseConnection, ITable1CreateService
    {
        public Table1CreateService(IConfiguration configuration)
            : base(configuration)
        { }

        public async Task Create(Table1CreateDto input)
        {
            string Table1CreateQueryString = GetTable1CreateQuery();
            var @params = new
            {
                date1 = input.Date1,
                date2 = input.Date2,
                ebt = input.Ebt,
                ent = input.Ent,
                vaj = input.Vaj,
                code = input.Cod,
                olgo = input.Olgo,
                desc = input.Desc,
                oVaj = input.OVaj,
                oVajFaz = input.OVajFaz,
            };
            await _sqlReportConnection.ExecuteAsync(Table1CreateQueryString, @params);
        }

        private string GetTable1CreateQuery()
        {
            return @$"use [OldCalc]
                     Insert Into table1(date1,date2,ebt,ent,vaj,cod,olgo,[desc],o_vaj,o_vaj_faz)
                     Values(@date1,@date2,@ebt,@ent,@vaj,@code,@olgo,@desc,@oVaj,@oVajFaz)";
        }


    }
}
