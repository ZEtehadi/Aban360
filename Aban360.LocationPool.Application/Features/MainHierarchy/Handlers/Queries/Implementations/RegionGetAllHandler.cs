﻿using Aban360.Common.Extensions;
using Aban360.LocationPool.Application.Features.MainHierarchy.Handlers.Queries.Contracts;
using Aban360.LocationPool.Domain.Features.MainHierarchy.Dto.Queries;
using Aban360.LocationPool.Persistence.Features.MainHierarchy.Queries.Contracts;
using AutoMapper;

namespace Aban360.LocationPool.Application.Features.MainHierarchy.Handlers.Queries.Implementations
{
    public class RegionGetAllHandler : IRegionGetAllHandler
    {
        private readonly IRegionQueryService _regionQueryService;
        private readonly IMapper _mapper;
        public RegionGetAllHandler(
             IMapper mapper,
            IRegionQueryService regionQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _regionQueryService = regionQueryService;
            _regionQueryService.NotNull(nameof(regionQueryService));
        }

        public async Task<ICollection<RegionGetDto>> Handle(CancellationToken cancellationToken)
        {
            var region = await _regionQueryService.Get();
            return _mapper.Map<ICollection<RegionGetDto>>(region);
        }
    }
}
