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
    [Route("v1/sewage-water-request-noninstalled-detail")]
    public class SewageWaterRequestNonInstalledDetailController : BaseController
    {
        private readonly ISewageWaterRequestNonInstalledDetailHandler _sewageWaterRequestNonInstalledDetailHandler;
        private readonly IReportGenerator _reportGenerator;
        public SewageWaterRequestNonInstalledDetailController(
            ISewageWaterRequestNonInstalledDetailHandler sewageWaterRequestNonInstalledDetailHandler,
            IReportGenerator reportGenerator)
        {
            _sewageWaterRequestNonInstalledDetailHandler = sewageWaterRequestNonInstalledDetailHandler;
            _sewageWaterRequestNonInstalledDetailHandler.NotNull(nameof(sewageWaterRequestNonInstalledDetailHandler));

            _reportGenerator = reportGenerator;
            _reportGenerator.NotNull(nameof(_reportGenerator));
        }

        [HttpPost, HttpGet]
        [Route("raw")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<ReportOutput<SewageWaterRequestNonInstalledHeaderOutputDto, SewageWaterRequestNonInstalledDetailDataOutputDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetRaw(SewageWaterRequestNonInstalledInputDto input,CancellationToken cancellationToken)
        {
            var result=await _sewageWaterRequestNonInstalledDetailHandler.Handle(input, cancellationToken);
            return Ok(result);
        }

        [HttpPost, HttpGet]
        [Route("excel/{connectionId}")]
        public async Task<IActionResult> GetExcel(string connectionId, SewageWaterRequestNonInstalledInputDto inputDto, CancellationToken cancellationToken)
        {
            string reportName = inputDto.IsWater ? ReportLiterals.WaterRequestNonInstalledDetail: ReportLiterals.SewageRequestNonInstalledDetail;
            await _reportGenerator.FireAndInform(inputDto, cancellationToken, _sewageWaterRequestNonInstalledDetailHandler.Handle, CurrentUser, reportName, connectionId);
            return Ok(inputDto);
        }
    }
}
