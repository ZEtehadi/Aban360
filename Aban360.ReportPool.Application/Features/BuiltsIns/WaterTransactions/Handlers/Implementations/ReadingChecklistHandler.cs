﻿using Aban360.Common.Exceptions;
using Aban360.Common.Extensions;
using Aban360.ReportPool.Application.Features.BuiltsIns.WaterTransactions.Handlers.Contracts;
using Aban360.ReportPool.Domain.Base;
using Aban360.ReportPool.Domain.Features.BuiltIns.WaterTransactions.Inputs;
using Aban360.ReportPool.Domain.Features.BuiltIns.WaterTransactions.Outputs;
using Aban360.ReportPool.Persistence.Features.BuiltIns.WaterTransactions.Contracts;
using FluentValidation;

namespace Aban360.ReportPool.Application.Features.BuiltsIns.WaterTransactions.Handlers.Implementations
{
    internal sealed class ReadingChecklistHandler : IReadingChecklistHandler
    {
        private readonly IReadingChecklistQueryService _readingChecklistQueryService;
        private readonly IValidator<ReadingChecklistInputDto> _validator;
        public ReadingChecklistHandler(
            IReadingChecklistQueryService readingChecklistQueryService,
            IValidator<ReadingChecklistInputDto> validator)
        {
            _readingChecklistQueryService = readingChecklistQueryService;
            _readingChecklistQueryService.NotNull(nameof(readingChecklistQueryService));

            _validator = validator;
            _validator.NotNull(nameof(validator));
        }

        public async Task<ReportOutput<ReadingChecklistHeaderOutputDto, ReadingChecklistDataOutputDto>> Handle(ReadingChecklistInputDto input, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(input, cancellationToken);
            if (!validationResult.IsValid)
            {
                var message = string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage));
                throw new CustomeValidationException(message);
            }

            ReportOutput<ReadingChecklistHeaderOutputDto, ReadingChecklistDataOutputDto> ReadingChecklist = await _readingChecklistQueryService.Get(input);
            return ReadingChecklist;
        }
    }
}
