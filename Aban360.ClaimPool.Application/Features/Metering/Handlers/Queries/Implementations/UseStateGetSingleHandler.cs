﻿using Aban360.ClaimPool.Application.Features.Metering.Handlers.Queries.Contracts;
using Aban360.ClaimPool.Domain.Constants;
using Aban360.ClaimPool.Domain.Features.Metering.Dto.Queries;
using Aban360.ClaimPool.Persistence.Features.Metering.Queries.Contracts;
using Aban360.Common.Extensions;
using AutoMapper;

namespace Aban360.ClaimPool.Application.Features.Metering.Handlers.Queries.Implementations
{
    public class UseStateGetSingleHandler : IUseStateGetSingleHandler
    {
        private readonly IMapper _mapper;
        private readonly IUseStateQueryService _useStateQueryService;
        public UseStateGetSingleHandler(
            IMapper mapper,
            IUseStateQueryService useStateQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _useStateQueryService = useStateQueryService;
            _useStateQueryService.NotNull(nameof(useStateQueryService));
        }

        public async Task<UseStateGetDto> Handle(UseStateEnum id, CancellationToken cancellationToken)
        {
            var useState = await _useStateQueryService.Get(id);
            if (useState == null)
            {
                throw new InvalidDataException();
            }
            return _mapper.Map<UseStateGetDto>(useState);
        }
    }
}
