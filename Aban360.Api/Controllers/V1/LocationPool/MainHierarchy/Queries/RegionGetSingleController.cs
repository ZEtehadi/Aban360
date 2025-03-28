﻿using Aban360.Common.Categories.ApiResponse;
using Aban360.Common.Extensions;
using Aban360.LocationPool.Application.Features.MainHierarchy.Handlers.Queries.Contracts;
using Aban360.LocationPool.Domain.Features.MainHierarchy.Dto.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Aban360.Api.Controllers.V1.LocationPool.MainHierarchy.Queries
{
    [Route("v1/region")]
    public class RegionGetSingleController : BaseController
    {
        private readonly IRegionGetSingleHandler _regionGetSingleHandler;
        public RegionGetSingleController(IRegionGetSingleHandler regionGetSingleHandler)
        {
            _regionGetSingleHandler = regionGetSingleHandler;
            _regionGetSingleHandler.NotNull(nameof(regionGetSingleHandler));
        }

        [HttpGet, HttpPost]
        [Route("single/{id}")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<RegionGetDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(int id, CancellationToken cancellationToken)
        {
            RegionGetDto region = await _regionGetSingleHandler.Handle(id, cancellationToken);
            return Ok(region);
        }
    }
}
