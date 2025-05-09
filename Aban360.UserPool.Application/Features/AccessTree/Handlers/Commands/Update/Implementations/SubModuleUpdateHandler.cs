﻿using Aban360.Common.Extensions;
using Aban360.UserPool.Application.Features.AccessTree.Handlers.Commands.Update.Contracts;
using Aban360.UserPool.Domain.Features.AceessTree.Dto.Commands;
using Aban360.UserPool.Domain.Features.AceessTree.Entites;
using Aban360.UserPool.Persistence.Features.UiElement.Queries.Contracts;
using AutoMapper;

namespace Aban360.UserPool.Application.Features.AccessTree.Handlers.Commands.Update.Implementations
{
    internal sealed class SubModuleUpdateHandler : ISubModuleUpdateHandler
    {
        private readonly IMapper _mapper;
        private readonly ISubModuleQueryService _subModuleQueryService;
        public SubModuleUpdateHandler(
            IMapper mapper,
            ISubModuleQueryService subModuleQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _subModuleQueryService = subModuleQueryService;
            _subModuleQueryService.NotNull(nameof(subModuleQueryService));
        }

        public async Task Handle(SubModuleUpdateDto updateDto, CancellationToken cancellationToken)
        {
            SubModule subModule = await _subModuleQueryService.Get(updateDto.Id);
            _mapper.Map(updateDto, subModule);
        }
    }
}