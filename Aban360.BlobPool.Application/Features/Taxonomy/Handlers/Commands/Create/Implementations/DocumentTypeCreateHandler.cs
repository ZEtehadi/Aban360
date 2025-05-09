﻿using Aban360.BlobPool.Application.Features.Taxonomy.Handlers.Commands.Create.Contracts;
using Aban360.BlobPool.Domain.Features.Taxonomy.Dto.Commands;
using Aban360.BlobPool.Domain.Features.Taxonomy.Entities;
using Aban360.BlobPool.Persistence.Features.Taxonomy.Commands.Contracts;
using Aban360.Common.Exceptions;
using Aban360.Common.Extensions;
using AutoMapper;
using FluentValidation;

namespace Aban360.BlobPool.Application.Features.Taxonomy.Handlers.Commands.Create.Implementations
{
    internal sealed class DocumentTypeCreateHandler : IDocumentTypeCreateHandler
    {
        private readonly IMapper _mapper;
        private readonly IDocumentTypeCommandService _documentTypeCommandService;
        private readonly IValidator<DocumentTypeCreateDto> _validator;

        public DocumentTypeCreateHandler(
            IMapper mapper,
            IDocumentTypeCommandService documentTypeCommandService,
            IValidator<DocumentTypeCreateDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));

            _documentTypeCommandService = documentTypeCommandService;
            _documentTypeCommandService.NotNull(nameof(_documentTypeCommandService));

            _validator = validator;
            _validator.NotNull(nameof(validator));

        }

        public async Task Handle(DocumentTypeCreateDto createDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(createDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                var message = string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage));
                throw new CustomeValidationException(message);
            }

            var documentType = _mapper.Map<DocumentType>(createDto);

            MemoryStream memoryStream = new MemoryStream();
            await (createDto.Icon).CopyToAsync(memoryStream);
            string base64String = Convert.ToBase64String(memoryStream.ToArray());
            documentType.Icon = base64String;

            await _documentTypeCommandService.Add(documentType);
        }
    }
}
