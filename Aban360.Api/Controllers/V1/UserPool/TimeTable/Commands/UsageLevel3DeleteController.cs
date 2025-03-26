﻿using Aban360.Api.Controllers.V1;
using Aban360.Common.Categories.ApiResponse;
using Aban360.Common.Extensions;
using Aban360.UserPool.Application.Features.TimeTable.Handlers.Commands.Delete.Contracts;
using Aban360.UserPool.Domain.Features.TimeTable.Dto.Commands;
using Aban360.UserPool.Persistence.Contexts.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Aban360.Api.Controllers.V3.UserPool.TimeTable.Commands
{
    [Route("v3/usage-level-3")]
    public class UsageLevel3DeleteController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IUsageLevel3DeleteHandler _usageLevel3DeleteHandler;
        public UsageLevel3DeleteController(
            IUnitOfWork uow,
            IUsageLevel3DeleteHandler usageLevel3DeleteHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _usageLevel3DeleteHandler = usageLevel3DeleteHandler;
            _usageLevel3DeleteHandler.NotNull(nameof(usageLevel3DeleteHandler));
        }

        [HttpPost, HttpDelete]
        [Route("delete")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<UsageLevel3DeleteDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromBody] UsageLevel3DeleteDto deleteDto, CancellationToken cancellationToken)
        {
            await _usageLevel3DeleteHandler.Handle(deleteDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);

            return Ok(deleteDto);
        }
    }
}
