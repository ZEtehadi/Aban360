﻿using Aban360.BlobPool.Application.Features.Taxonomy.Handlers.Queries.Contracts;
using Aban360.BlobPool.Domain.Features.Taxonomy.Dto.Queries;
using Aban360.BlobPool.Persistence.Features.DMS.Queries.Contracts;
using Aban360.BlobPool.Persistence.Features.Taxonomy.Queries.Contracts;
using Aban360.Common.Extensions;
using AutoMapper;

namespace Aban360.BlobPool.Application.Features.Taxonomy.Handlers.Queries.Implementations
{
    internal sealed class DocumentCategoryGetByBillIdHandler : IDocumentCategoryGetByBillIdHandler
    {
        private readonly IMapper _mapper;
        private readonly IDocumentEntityQueryService _documentEntityQueryService;
        private readonly IDocumentQueryService _documentQueryService;
        public DocumentCategoryGetByBillIdHandler(
            IMapper mapper,
            IDocumentEntityQueryService documentEntityQueryService,
            IDocumentQueryService documentQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));

            _documentEntityQueryService = documentEntityQueryService;
            _documentEntityQueryService.NotNull(nameof(_documentEntityQueryService));

            _documentQueryService = documentQueryService;
            _documentQueryService.NotNull(nameof(_documentEntityQueryService));
        }

        public async Task<ICollection<DocumentCategoryGetDto>> Handle(string billId, CancellationToken cancellationToken)
        {
            var documentEntities = await _documentEntityQueryService.Get(billId);
            var documentCategories = await _documentQueryService.GetDocoumentCategory(documentEntities.Select(d => d.DocumentId).ToList());
            
            return _mapper.Map<ICollection<DocumentCategoryGetDto>>(documentCategories);
        }
    }
}
