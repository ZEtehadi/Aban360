﻿using Aban360.ClaimPool.Application.Features.Land.Handlers.Queries.Contracts;
using Aban360.ClaimPool.Domain.Features.Land.Dto.Commands;
using Aban360.ClaimPool.Domain.Features.Land.Entities;
using Aban360.ClaimPool.Persistence.Features.Land.Queries.Contracts;
using Aban360.Common.Extensions;
using AutoMapper;

namespace Aban360.ClaimPool.Application.Features.Land.Handlers.Queries.Implemntations
{
    internal sealed class EstateBoundTypeGetAllHandler : IEstateBoundTypeGetAllHandler
    {
        private readonly IMapper _mapper;
        private readonly IEstateBoundTypeQueryService _queryService;
        public EstateBoundTypeGetAllHandler(
            IMapper mapper,
           IEstateBoundTypeQueryService queryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _queryService = queryService;
            _queryService.NotNull(nameof(queryService));
        }

        public async Task<ICollection<EstateBoundTypeGetDto>> Handle(CancellationToken cancellationToken)
        {
            ICollection<EstateBoundType> estateBoundType = await _queryService.Get();
            if (estateBoundType == null)
            {
                throw new InvalidDataException();
            }
            return _mapper.Map<ICollection<EstateBoundTypeGetDto>>(estateBoundType);
        }
    }
}
