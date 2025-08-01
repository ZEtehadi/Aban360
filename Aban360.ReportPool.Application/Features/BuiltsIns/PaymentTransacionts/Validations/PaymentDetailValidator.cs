﻿using Aban360.Common.Literals;
using Aban360.ReportPool.Application.Features.Base.Validations;
using Aban360.ReportPool.Domain.Features.BuiltIns.PaymentsTransactions.Inputs;
using FluentValidation;

namespace Aban360.ReportPool.Application.Features.BuiltsIns.PaymentTransacionts.Validations
{
    public class PaymentDetailValidator : BaseValidator<PaymentDetailInputDto>
    {
        public PaymentDetailValidator()
        {
            RuleFor(customer => customer.FromDateJalali)
          .NotEmpty().WithMessage(ExceptionLiterals.NotNull)
          .NotNull().WithMessage(ExceptionLiterals.NotNull);

            RuleFor(customer => customer.ToDateJalali)
           .NotEmpty().WithMessage(ExceptionLiterals.NotNull)
           .NotNull().WithMessage(ExceptionLiterals.NotNull);

            RuleFor(customer => customer.FromAmount)
           .NotEmpty().WithMessage(ExceptionLiterals.NotNull)
           .NotNull().WithMessage(ExceptionLiterals.NotNull);

            RuleFor(customer => customer.ToAmount)
           .NotEmpty().WithMessage(ExceptionLiterals.NotNull)
           .NotNull().WithMessage(ExceptionLiterals.NotNull);

            RuleFor(input => input)
               .Must(input => FromToDateJalaliValidation.DateValidation(new FromToDateJalaliDto(input.FromDateJalali,
                                                                                               input.ToDateJalali)).IsValid)
               .WithMessage(input => FromToDateJalaliValidation.DateValidation(new FromToDateJalaliDto(input.FromDateJalali,
                                                                                               input.ToDateJalali)).ErrorMessage);
        }
    }
}
