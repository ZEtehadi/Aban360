﻿using Aban360.Common.Extensions;
using Aban360.UserPool.Application.Features.AccessTree.Handlers.Commands.Update.Contracts;
using Aban360.UserPool.Domain.Features.AceessTree.Dto.Commands;
using Aban360.UserPool.Domain.Features.AceessTree.Entites;
using Aban360.UserPool.Persistence.Features.UiElement.Queries.Contracts;
using AutoMapper;

namespace Aban360.UserPool.Application.Features.AccessTree.Handlers.Commands.Update.Implementations
{
    internal sealed class AppUpdateHandler : IAppUpdateHandler
    {
        private readonly IMapper _mapper;
        private readonly IAppQueryService _appQueryService;
        public AppUpdateHandler(
            IMapper mapper,
            IAppQueryService appQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _appQueryService = appQueryService;
            _appQueryService.NotNull(nameof(appQueryService));
        }

        public async Task Handle(AppUpdateDto updateDto, CancellationToken cancellationToken)
        {
            App app = await _appQueryService.Get(updateDto.Id);
            _mapper.Map(updateDto, app);
        }
    }
}
