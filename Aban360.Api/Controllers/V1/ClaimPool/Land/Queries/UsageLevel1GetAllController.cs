﻿using Aban360.ClaimPool.Application.Features.Land.Handlers.Queries.Contracts;
using Aban360.ClaimPool.Domain.Features.Land.Dto.Queries;
using Aban360.Common.Categories.ApiResponse;
using Aban360.Common.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Aban360.Api.Controllers.V1.ClaimPool.Land.Queries
{
    [Route("v1/usage-level-1")]
    public class UsageLevel1GetAllController : BaseController
    {
        private readonly IUsageLevel1GetAllHandler _usageLevel1GetAllHandler;
        public UsageLevel1GetAllController(IUsageLevel1GetAllHandler usageLevel1GetAllHandler)
        {
            _usageLevel1GetAllHandler = usageLevel1GetAllHandler;
            _usageLevel1GetAllHandler.NotNull(nameof(usageLevel1GetAllHandler));
        }

        [HttpPost, HttpGet]
        [Route("all")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<ICollection<UsageLevel1GetDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var usageLevel1s = await _usageLevel1GetAllHandler.Handle(cancellationToken);
            return Ok(usageLevel1s);
        }
    }
}
