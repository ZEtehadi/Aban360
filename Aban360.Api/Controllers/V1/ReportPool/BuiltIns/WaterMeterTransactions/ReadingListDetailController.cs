﻿using Aban360.Api.Cronjobs;
using Aban360.Common.Categories.ApiResponse;
using Aban360.Common.Extensions;
using Aban360.ReportPool.Application.Features.BuiltsIns.WaterTransactions.Handlers.Contracts;
using Aban360.ReportPool.Domain.Base;
using Aban360.ReportPool.Domain.Features.BuiltIns.WaterTransactions.Inputs;
using Aban360.ReportPool.Domain.Features.BuiltIns.WaterTransactions.Outputs;
using Microsoft.AspNetCore.Mvc;

namespace Aban360.Api.Controllers.V1.ReportPool.BuiltIns.WaterMeterTransactions
{
    [Route("v1/reading-list-detail")]
    public class ReadingListDetailController : BaseController
    {
        private readonly IReadingListDetailHandler _readingListDetail;
        private readonly IReportGenerator _reportGenerator;
        public ReadingListDetailController(
            IReadingListDetailHandler readingListDetail,
            IReportGenerator reportGenerator)
        {
            _readingListDetail = readingListDetail;
            _readingListDetail.NotNull(nameof(_readingListDetail));
        }

        [HttpPost]
        [Route("raw")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<ReportOutput<ReadingListHeaderOutputDto, ReadingListDetailDataOutputDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetRaw(ReadingListInputDto inputDto, CancellationToken cancellationToken)
        {
            ReportOutput<ReadingListHeaderOutputDto, ReadingListDetailDataOutputDto> waterSales = await _readingListDetail.Handle(inputDto, cancellationToken);
            return Ok(waterSales);
        }

        [HttpPost, HttpGet]
        [Route("excel/{connectionId}")]
        public async Task<IActionResult> GetExcel(string connectionId, ReadingListInputDto inputDto, CancellationToken cancellationToken)
        {
            await _reportGenerator.FireAndInform(inputDto, cancellationToken, _readingListDetail.Handle, CurrentUser, ReportLiterals.ReadingListDetail, connectionId);
            return Ok(inputDto);
        }
    }
}
