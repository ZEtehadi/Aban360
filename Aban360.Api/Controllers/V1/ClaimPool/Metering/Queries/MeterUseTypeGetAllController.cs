﻿using Aban360.ClaimPool.Application.Features.Metering.Handlers.Queries.Contracts;
using Aban360.ClaimPool.Domain.Features.Metering.Dto.Queries;
using Aban360.ClaimPool.Persistence.Contexts.Contracts;
using Aban360.Common.Categories.ApiResponse;
using Aban360.Common.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Aban360.Api.Controllers.V1.ClaimPool.Metering.Commands
{
    [Route("v1/meter-use-type")]
    public class MeterUseTypeGetAllController:BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IMeterUseTypeGetAllHandler _meterUseTypeHandler;
        public MeterUseTypeGetAllController(
            IUnitOfWork uow,
            IMeterUseTypeGetAllHandler meterUseTypeHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _meterUseTypeHandler = meterUseTypeHandler;
            _meterUseTypeHandler.NotNull(nameof(meterUseTypeHandler));
        }

        [HttpGet, HttpPost]
        [Route("all")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<ICollection<MeterUseTypeGetDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            ICollection<MeterUseTypeGetDto> meterUseTypes = await _meterUseTypeHandler.Handle(cancellationToken);
            return Ok(meterUseTypes);
        }
    }
}
