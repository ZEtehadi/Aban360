﻿using Aban360.Api.Cronjobs;
using Aban360.Common.Categories.ApiResponse;
using Aban360.Common.Extensions;
using Aban360.ReportPool.Application.Features.BuiltsIns.ServiceLinkTransactions.Handlers.Contracts;
using Aban360.ReportPool.Domain.Base;
using Aban360.ReportPool.Domain.Features.BuiltIns.ServiceLinkTransaction.Inputs;
using Aban360.ReportPool.Domain.Features.BuiltIns.ServiceLinkTransaction.Outputs;
using Microsoft.AspNetCore.Mvc;

namespace Aban360.Api.Controllers.V1.ReportPool.BuiltIns.ServiceLinkTransactions
{
    [Route("v1/deductions-and-discounts-summary-report")]
    public class DeductionsAndDiscountsSummaryReportController : BaseController
    {
        private readonly IDeductionsAndDiscountsSummaryReportHandler _deductionsAndDiscountsSummaryReportHandler;
        private readonly IReportGenerator _reportGenerator;
        public DeductionsAndDiscountsSummaryReportController(
            IDeductionsAndDiscountsSummaryReportHandler deductionsAndDiscountsSummaryReportHandler,
            IReportGenerator reportGenerator)
        {
            _deductionsAndDiscountsSummaryReportHandler = deductionsAndDiscountsSummaryReportHandler;
            _deductionsAndDiscountsSummaryReportHandler.NotNull(nameof(_deductionsAndDiscountsSummaryReportHandler));

            _reportGenerator = reportGenerator;
            _reportGenerator.NotNull(nameof(_reportGenerator));
        }

        [HttpPost, HttpGet]
        [Route("raw")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<ReportOutput<DeductionsAndDiscountsReportHeaderOutputDto, DeductionsAndDiscountsReportSummaryDataOutputDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetRaw(DeductionsAndDiscountsReportInputDto inputDto, CancellationToken cancellationToken)
        {
            ReportOutput<DeductionsAndDiscountsReportHeaderOutputDto, DeductionsAndDiscountsReportSummaryDataOutputDto> deductionsAndDiscountsSummaryReport = await _deductionsAndDiscountsSummaryReportHandler.Handle(inputDto, cancellationToken);
            return Ok(deductionsAndDiscountsSummaryReport);
        }

        [HttpPost, HttpGet]
        [Route("eDeductionsAndDiscountcel/{connectionId}")]
        public async Task<IActionResult> GetEDeductionsAndDiscountcel(string connectionId, DeductionsAndDiscountsReportInputDto inputDto, CancellationToken cancellationToken)
        {
            await _reportGenerator.FireAndInform(inputDto, cancellationToken, _deductionsAndDiscountsSummaryReportHandler.Handle, CurrentUser, ReportLiterals.DeductionsAndDiscountsReport, connectionId);
            return Ok(inputDto);
        }
    }
}
