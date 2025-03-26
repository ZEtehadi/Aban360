﻿using Aban360.Common.Extensions;
using Aban360.UserPool.Application.Features.TimeTable.Handlers.Commands.Update.Contracts;
using Aban360.UserPool.Domain.Features.TimeTable.Dto.Commands;
using Aban360.UserPool.Persistence.Contexts.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Aban360.Api.Controllers.V1.UserPool.TimeTable.Commands
{
    [Route("v1/usage-level-1")]
    public class UsageLevel1UpdateController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IUsageLevel1UpdateHandler _usageLevel1UpdateHandler;
        public UsageLevel1UpdateController(
            IUnitOfWork uow,
            IUsageLevel1UpdateHandler usageLevel1UpdateHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _usageLevel1UpdateHandler = usageLevel1UpdateHandler;
            _usageLevel1UpdateHandler.NotNull(nameof(usageLevel1UpdateHandler));
        }

        [HttpPost, HttpPatch]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] UsageLevel1UpdateDto updateDto, CancellationToken cancellationToken)
        {
            await _usageLevel1UpdateHandler.Handle(updateDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);

            return Ok(updateDto);
        }
    }
}
