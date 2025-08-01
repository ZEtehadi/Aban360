﻿using Aban360.Common.Categories.ApiResponse;
using Aban360.Common.Extensions;
using Aban360.OldCalcPool.Application.Features.Rules.Handlers.Commands.Create.Contracts;
using Aban360.OldCalcPool.Domain.Features.Rules.Dto.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Aban360.Api.Controllers.V1.OldCalcPool.Rule.Commands
{
    [Route("v1/nerkh-14")]
    public class Nerkh14CreateController : BaseController
    {
        private readonly INerkhCreateHandler _nerkhCreateHandler;
        public Nerkh14CreateController(INerkhCreateHandler nerkhCreateHandler)
        {
            _nerkhCreateHandler = nerkhCreateHandler;
            _nerkhCreateHandler.NotNull(nameof(nerkhCreateHandler));
        }

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<NerkhCreateDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create( NerkhCreateDto createDto, CancellationToken cancellationToken)
        {
            await _nerkhCreateHandler.Handle(createDto, 14, cancellationToken);
            return Ok(createDto);
        }
    }
}
