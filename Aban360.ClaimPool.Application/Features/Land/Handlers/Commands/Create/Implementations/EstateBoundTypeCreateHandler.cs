﻿using Aban360.ClaimPool.Application.Features.Land.Handlers.Commands.Create.Contracts;
using Aban360.ClaimPool.Domain.Features.Land.Dto.Commands;
using Aban360.ClaimPool.Domain.Features.Land.Entities;
using Aban360.ClaimPool.Persistence.Features.Land.Commands.Contracts;
using Aban360.Common.Exceptions;
using Aban360.Common.Extensions;
using AutoMapper;
using FluentValidation;

namespace Aban360.ClaimPool.Application.Features.Land.Handlers.Commands.Create.Implementations
{
    internal sealed class EstateBoundTypeCreateHandler : IEstateBoundTypeCreateHandler
    {
        private readonly IMapper _mapper;
        private readonly IEstateBoundTypeCommandService _commandService;
        private readonly IValidator<EstateBoundTypeCreateDto> _validator;

        public EstateBoundTypeCreateHandler(
            IMapper mapper,
            IEstateBoundTypeCommandService commandService,
            IValidator<EstateBoundTypeCreateDto> validator )
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));

            _commandService = commandService;
            _commandService.NotNull(nameof(_commandService));

            _validator = validator;
            _validator.NotNull(nameof(validator));

        }

        public async Task Handle(EstateBoundTypeCreateDto createDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(createDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                var message = string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage));
                throw new CustomeValidationException(message);
            }

            EstateBoundType estateBoundType = _mapper.Map<EstateBoundType>(createDto);
            await _commandService.Add(estateBoundType);
        }
    }
}
