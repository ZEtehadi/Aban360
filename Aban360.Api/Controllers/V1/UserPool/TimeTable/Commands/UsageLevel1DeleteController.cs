﻿using Aban360.Common.Categories.ApiResponse;
using Aban360.Common.Extensions;
using Aban360.UserPool.Application.Features.TimeTable.Handlers.Commands.Delete.Contracts;
using Aban360.UserPool.Domain.Features.TimeTable.Dto.Commands;
using Aban360.UserPool.Persistence.Contexts.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Aban360.Api.Controllers.V1.UserPool.TimeTable.Commands
{
    [Route("v1/usage-level-1")]
    public class UsageLevel1DeleteController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IUsageLevel1DeleteHandler _usageLevel1DeleteHandler;
        public UsageLevel1DeleteController(
            IUnitOfWork uow,
            IUsageLevel1DeleteHandler usageLevel1DeleteHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _usageLevel1DeleteHandler = usageLevel1DeleteHandler;
            _usageLevel1DeleteHandler.NotNull(nameof(usageLevel1DeleteHandler));
        }

        [HttpPost, HttpDelete]
        [Route("delete")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<UsageLevel1DeleteDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromBody] UsageLevel1DeleteDto deleteDto, CancellationToken cancellationToken)
        {
            await _usageLevel1DeleteHandler.Handle(deleteDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);

            return Ok(deleteDto);
        }
    }
}
