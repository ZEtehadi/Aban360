﻿using Aban360.Common.Exceptions;
using Aban360.Common.Extensions;
using Aban360.Common.Literals;
using Aban360.SystemPool.Application.Features.Logging.Handlers.Queries.Conracts;
using Aban360.SystemPool.Domain.Features.Logging.Dto.Input;
using Aban360.SystemPool.Domain.Features.Logging.Dto.Output;
using Aban360.SystemPool.Persistence.Features.Logging.Queries.Contracts;
using DNTPersianUtils.Core;
using System.Globalization;

namespace Aban360.SystemPool.Application.Features.Logging.Handlers.Queries.Implementations
{
    internal sealed class LoggingGetyDateTimeHandler : ILoggingGetyDateTimeHandler
    {
        private readonly ILoggingGetByDateTimeQueryService _loggingGetByDateTimeService;
        public LoggingGetyDateTimeHandler(ILoggingGetByDateTimeQueryService loggingGetByDateTimeService)
        {
            _loggingGetByDateTimeService = loggingGetByDateTimeService;
            _loggingGetByDateTimeService.NotNull(nameof(loggingGetByDateTimeService));
        }

        public async Task<IEnumerable<LoggingOutputDto>> Handle(LoggingInputByStringDto inputDto, CancellationToken cancellationToken)
        {
            DateOnly? from = inputDto.FromDate.ToGregorianDateOnly();
            DateOnly? to = inputDto.ToDate.ToGregorianDateOnly();
            if (!from.HasValue || !to.HasValue)
            {
                throw new InvalidDateException(ExceptionLiterals.InvalidDate);
            }

            string fromDateTimeString = $"{from.Value:yyyy/MM/dd} {inputDto.FromTime}";
            string toDateTimeString = $"{to.Value:yyyy/MM/dd} {inputDto.ToTime}";

            DateTime fromDateTime = DateTime.ParseExact(fromDateTimeString, "yyyy/MM/dd HH:mm", CultureInfo.InvariantCulture);
            DateTime toDateTime = DateTime.ParseExact(toDateTimeString, "yyyy/MM/dd HH:mm", CultureInfo.InvariantCulture);

            IEnumerable<LoggingOutputDto> result = await _loggingGetByDateTimeService.Get(new LoggingInputByDateTimeDto(fromDateTime, toDateTime, inputDto.LogLevel));
            return result;
        }
    }
}
