﻿using Aban360.ClaimPool.Application.Features.Draft.Handlers.Commands.Update.Contracts;
using Aban360.ClaimPool.Domain.Features.Draft.Dto.Commands;
using Aban360.ClaimPool.Persistence.Contexts.Contracts;
using Aban360.Common.Categories.ApiResponse;
using Aban360.Common.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Aban360.Api.Controllers.V1.ClaimPool.Draft.Commands
{
    [Route("v1/request_water_meter_tag")]
    public class RequestWaterMeterTagUpdateController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IRequestWaterMeterTagUpdateHandler _requestWaterMeterTagUpdateHandler;
        public RequestWaterMeterTagUpdateController(
            IUnitOfWork uow,
            IRequestWaterMeterTagUpdateHandler requestWaterMeterTagUpdateHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _requestWaterMeterTagUpdateHandler = requestWaterMeterTagUpdateHandler;
            _requestWaterMeterTagUpdateHandler.NotNull(nameof(requestWaterMeterTagUpdateHandler));
        }

        [HttpPost, HttpPatch]
        [Route("update")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<WaterMeterTagRequestUpdateDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody] WaterMeterTagRequestUpdateDto updateDto, CancellationToken cancellationToken)
        {
            await _requestWaterMeterTagUpdateHandler.Handle(updateDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);

            return Ok(updateDto);
        }
    }
}
