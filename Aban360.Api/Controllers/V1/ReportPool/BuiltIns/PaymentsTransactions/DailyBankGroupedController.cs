﻿using Aban360.Api.Cronjobs;
using Aban360.Common.Categories.ApiResponse;
using Aban360.Common.Extensions;
using Aban360.ReportPool.Application.Features.BuiltsIns.PaymentTransacionts.Handlers.Contracts;
using Aban360.ReportPool.Domain.Base;
using Aban360.ReportPool.Domain.Features.BuiltIns.PaymentsTransactions.Inputs;
using Aban360.ReportPool.Domain.Features.BuiltIns.PaymentsTransactions.Outputs;
using Microsoft.AspNetCore.Mvc;

namespace Aban360.Api.Controllers.V1.ReportPool.BuiltIns.PaymentsTransactions
{
    [Route("v1/daily-bank-grouped")]
    public class DailyBankGroupedController : BaseController
    {
        private readonly IDailyBankGroupedHandler _dailyBankGrouped;
        private readonly IReportGenerator _reportGenerator;
        public DailyBankGroupedController(
            IDailyBankGroupedHandler dailyBankGrouped,
            IReportGenerator reportGenerator)
        {
            _dailyBankGrouped = dailyBankGrouped;
            _dailyBankGrouped.NotNull(nameof(_dailyBankGrouped));

            _reportGenerator = reportGenerator;
            _reportGenerator.NotNull(nameof(_reportGenerator));
        }

        [HttpPost, HttpGet]
        [Route("raw")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<ReportOutput<DailyBankGroupedHeaderOutputDto, DailyBankGroupedDataOutputDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetRaw(DailyBankGroupedInputDto inputDto, CancellationToken cancellationToken)
        {
            ReportOutput<DailyBankGroupedHeaderOutputDto, DailyBankGroupedDataOutputDto> dailyBankGrouped = await _dailyBankGrouped.Handle(inputDto, cancellationToken);
            return Ok(dailyBankGrouped);
        }

        [HttpPost, HttpGet]
        [Route("excel/{connectionId}")]
        public async Task<IActionResult> GetExcel(string connectionId, DailyBankGroupedInputDto inputDto, CancellationToken cancellationToken)
        {
            await _reportGenerator.FireAndInform(inputDto, cancellationToken, _dailyBankGrouped.Handle, CurrentUser, ReportLiterals.DailyBankGrouped, connectionId);
            return Ok(inputDto);
        }
    }
}
