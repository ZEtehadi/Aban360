﻿using Aban360.Common.Extensions;
using Aban360.WorkflowPool.Application.Features.Assignment.Handlers.Commands.Delete.Contracts;
using Aban360.WorkflowPool.Domain.Features.Assignment.Dto.Commands;
using Aban360.WorkflowPool.Persistence.Features.Assignment.Commands.Contracts;
using Aban360.WorkflowPool.Persistence.Features.Assignment.Queries.Contracts;

namespace Aban360.WorkflowPool.Application.Features.Assignment.Handlers.Commands.Delete.Implementations
{
    internal sealed class WorkflowDeleteHandler : IWorkflowDeleteHandler
    {
        private readonly IWorkflowCommandService _workflowCommandService;
        private readonly IWorkflowQueryService _workflowQueryService;
        public WorkflowDeleteHandler(
            IWorkflowCommandService workflowCommandService,
            IWorkflowQueryService workflowQueryService)
        {
            _workflowCommandService = workflowCommandService;
            _workflowCommandService.NotNull(nameof(_workflowCommandService));

            _workflowQueryService = workflowQueryService;
            _workflowQueryService.NotNull(nameof(_workflowQueryService));
        }

        public async Task Handle(WorkflowDeleteDto deleteDto, CancellationToken cancellationToken)
        {
            var workflow = await _workflowQueryService.Get(deleteDto.Id);
            await _workflowCommandService.Remove(workflow);
        }
    }
}
