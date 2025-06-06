﻿using Aban360.Common.Extensions;
using Aban360.WorkflowPool.Domain.Features.Design.Entities;
using Aban360.WorkflowPool.Persistence.Contexts.Contracts;
using Aban360.WorkflowPool.Persistence.Features.Design.Commands.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Aban360.WorkflowPool.Persistence.Features.Design.Commands.Implementations
{
    internal sealed class WorkflowCommandService : IWorkflowCommandService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Workflow> _workflow;
        public WorkflowCommandService(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.NotNull(nameof(_uow));

            _workflow = _uow.Set<Workflow>();
            _workflow.NotNull(nameof(_workflow));
        }

        public async Task Add(Workflow Workflow)
        {
            await _workflow.AddAsync(Workflow);
        }

        public void Remove(Workflow Workflow)
        {
            _workflow.Remove(Workflow);
        }
    }
}
