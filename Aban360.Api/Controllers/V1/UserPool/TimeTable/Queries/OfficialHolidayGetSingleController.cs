﻿using Aban360.Common.Categories.ApiResponse;
using Aban360.Common.Extensions;
using Aban360.UserPool.Application.Features.TimeTable.Handlers.Queries.Contracts;
using Aban360.UserPool.Domain.Features.TimeTable.Dto.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Aban360.Api.Controllers.V1.UserPool.TimeTable.Queries
{
    [Route("v4/official-holiday")]
    public class OfficialHolidayGetSingleController : BaseController
    {
        private readonly IOfficialHolidayGetSingleHandler officialHolidayGetSingleHandler;
        public OfficialHolidayGetSingleController(IOfficialHolidayGetSingleHandler officialHolidayGetSingleHandler)
        {
            this.officialHolidayGetSingleHandler = officialHolidayGetSingleHandler;
            this.officialHolidayGetSingleHandler.NotNull(nameof(officialHolidayGetSingleHandler));
        }

        [HttpPost, HttpGet]
        [Route("single/{id}")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<OfficialHolidayGetDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSingle(short id, CancellationToken cancellationToken)
        {
            var officialHolidays = await officialHolidayGetSingleHandler.Handle(id, cancellationToken);
            return Ok(officialHolidays);
        }
    }
}
