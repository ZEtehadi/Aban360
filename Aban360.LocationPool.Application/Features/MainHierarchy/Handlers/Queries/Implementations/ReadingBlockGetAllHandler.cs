﻿using Aban360.Common.Extensions;
using Aban360.LocationPool.Application.Features.MainHierarchy.Handlers.Queries.Contracts;
using Aban360.LocationPool.Domain.Features.MainHierarchy.Dto.Queries;
using Aban360.LocationPool.Persistence.Features.MainHierarchy.Queries.Contracts;
using AutoMapper;

namespace Aban360.LocationPool.Application.Features.MainHierarchy.Handlers.Queries.Implementations
{
    public class ReadingBlockGetAllHandler : IReadingBlockGetAllHandler
    {
        private readonly IMapper _mapper;
        private readonly IReadingBlockQeryService _readingBlockQeryService;
        public ReadingBlockGetAllHandler(
            IMapper mapper,
            IReadingBlockQeryService readingBlockQeryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _readingBlockQeryService = readingBlockQeryService;
            _readingBlockQeryService.NotNull(nameof(readingBlockQeryService));
        }

        public async Task<ICollection<ReadingBlockGetDto>> Handle(CancellationToken cancellationToken)
        {
            var readingBound = await _readingBlockQeryService.Get();
            return _mapper.Map<ICollection<ReadingBlockGetDto>>(readingBound);
        }
    }
}
