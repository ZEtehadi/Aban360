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
    [Route("v1/sewage-water-distance-request-installation-summary")]
    public class SewageWaterDistanceofRequestAndInstallationSummaryController : BaseController
    {
        private readonly ISewageWaterDistanceofRequestAndInstallationSummaryHandler _sewageWaterDistanceofRequestAndInstallationSummaryHandler;
        private readonly IReportGenerator _reportGenerator;
        public SewageWaterDistanceofRequestAndInstallationSummaryController(
            ISewageWaterDistanceofRequestAndInstallationSummaryHandler sewageWaterDistanceofRequestAndInstallationSummaryHandler,
            IReportGenerator reportGenerator)
        {
            _sewageWaterDistanceofRequestAndInstallationSummaryHandler = sewageWaterDistanceofRequestAndInstallationSummaryHandler;
            _sewageWaterDistanceofRequestAndInstallationSummaryHandler.NotNull(nameof(sewageWaterDistanceofRequestAndInstallationSummaryHandler));

            _reportGenerator = reportGenerator;
            _reportGenerator.NotNull(nameof(_reportGenerator));
        }

        [HttpPost, HttpGet]
        [Route("raw")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<ReportOutput<SewageWaterDistanceofRequestAndInstallationHeaderOutputDto, SewageWaterDistanceofRequestAndInstallationSummaryDataOutputDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetRaw(SewageWaterDistanceofRequestAndInstallationInputDto input, CancellationToken cancellationToken)
        {
            var result = await _sewageWaterDistanceofRequestAndInstallationSummaryHandler.Handle(input, cancellationToken);
            return Ok(result);
        }

        [HttpPost, HttpGet]
        [Route("excel/{connectionId}")]
        public async Task<IActionResult> GetExcel(string connectionId, SewageWaterDistanceofRequestAndInstallationInputDto inputDto, CancellationToken cancellationToken)
        {
            string reportName = inputDto.IsWater ? ReportLiterals.WaterDistanceRequestInstallationSummary : ReportLiterals.SewageDistanceRequesteInstallationSummary;
            await _reportGenerator.FireAndInform(inputDto, cancellationToken, _sewageWaterDistanceofRequestAndInstallationSummaryHandler.Handle, CurrentUser, reportName, connectionId);
            return Ok(inputDto);
        }
    }
}
