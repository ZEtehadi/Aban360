﻿using Aban360.ClaimPool.Domain.Features.Metering.Entities;
using Aban360.ClaimPool.Persistence.Contexts.Contracts;
using Aban360.ClaimPool.Persistence.Features.Metering.Commands.Contracts;
using Aban360.Common.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Aban360.ClaimPool.Persistence.Features.Metering.Commands.Implementations
{
    internal sealed class UseStateCommandService : IUseStateCommandService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<UseState> _useState;
        public UseStateCommandService(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _useState = _uow.Set<UseState>();
            _useState.NotNull(nameof(_useState));
        }

        public async Task Add(UseState useState)
        {
            await _useState.AddAsync(useState);
        }

        public async Task Remove(UseState useState)
        {
            _useState.Remove(useState);
        }
    }
}
