﻿using Aban360.Common.Categories.ApiResponse;
using Aban360.Common.Extensions;
using Aban360.LocationPool.Application.Features.MainHierarchy.Handlers.Queries.Contracts;
using Aban360.LocationPool.Domain.Features.MainHierarchy.Dto.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Aban360.Api.Controllers.V1.LocationPool.MainHierarchy.Queries
{
    [Route("v1/country")]
    public class CountryGetSingleController:BaseController
    {
        private readonly ICountryGetSingleHandler _countryGetSingleHandler;
        public CountryGetSingleController(ICountryGetSingleHandler countryGetSingleHandler)
        {
            _countryGetSingleHandler=countryGetSingleHandler;
            _countryGetSingleHandler.NotNull(nameof(countryGetSingleHandler));
        }

        [HttpGet, HttpPost]
        [Route("single/{id}")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<CountryGetDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSingle(short id,CancellationToken cancellationToken)
        {
            CountryGetDto result = await _countryGetSingleHandler.Handle(id, cancellationToken);
            return Ok(result);
        }
    }
}
