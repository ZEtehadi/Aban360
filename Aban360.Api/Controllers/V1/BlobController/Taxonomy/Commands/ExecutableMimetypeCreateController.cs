﻿using Aban360.BlobPool.Application.Features.Taxonomy.Handlers.Commands.Create.Contracts;
using Aban360.BlobPool.Domain.Features.Taxonomy.Dto.Commands;
using Aban360.BlobPool.Persistence.Contexts.Contracts;
using Aban360.Common.Categories.ApiResponse;
using Aban360.Common.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Aban360.Api.Controllers.V1.BlobController.Taxonomy.Commands
{
    [Route("v1/executable-mimetype")]
    public class ExecutableMimetypeCreateController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IExecutableMimetypeCreateHandler _executableMimetypeCreateHandler;
        public ExecutableMimetypeCreateController(
            IUnitOfWork uow,
            IExecutableMimetypeCreateHandler executableMimetypeCreateHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _executableMimetypeCreateHandler = executableMimetypeCreateHandler;
            _executableMimetypeCreateHandler.NotNull(nameof(executableMimetypeCreateHandler));
        }

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<ExecutableMimetypeCreateDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create([FromBody] ExecutableMimetypeCreateDto createDto, CancellationToken cancellationToken)
        {
            await _executableMimetypeCreateHandler.Handle(createDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);

            return Ok(createDto);
        }
    }
}
