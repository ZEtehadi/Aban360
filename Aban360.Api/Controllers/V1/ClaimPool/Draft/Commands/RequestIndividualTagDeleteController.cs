﻿using Aban360.ClaimPool.Application.Features.Draft.Handlers.Commands.Delete.Contracts;
using Aban360.ClaimPool.Domain.Features.Draft.Dto.Commands;
using Aban360.ClaimPool.Persistence.Contexts.Contracts;
using Aban360.Common.Categories.ApiResponse;
using Aban360.Common.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Aban360.Api.Controllers.V1.ClaimPool.Draft.Commands
{
    [Route("v1/request_individual_tag")]
    public class RequestIndividualTagDeleteController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IRequestIndividualTagDeleteHandler _requestIndividualTagDeleteHandler;
        public RequestIndividualTagDeleteController(
            IUnitOfWork uow,
            IRequestIndividualTagDeleteHandler requestIndividualTagDeleteHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _requestIndividualTagDeleteHandler = requestIndividualTagDeleteHandler;
            _requestIndividualTagDeleteHandler.NotNull(nameof(requestIndividualTagDeleteHandler));
        }

        [HttpPost, HttpDelete]
        [Route("delete")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<IndividualTagRequestDeleteDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromBody] IndividualTagRequestDeleteDto deleteDto, CancellationToken cancellationToken)
        {
            await _requestIndividualTagDeleteHandler.Handle(deleteDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);

            return Ok(deleteDto);
        }
    }
}
