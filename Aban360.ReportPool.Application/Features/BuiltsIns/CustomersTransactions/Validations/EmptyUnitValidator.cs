﻿using Aban360.Common.Literals;
using Aban360.ReportPool.Application.Features.Base.Validations;
using Aban360.ReportPool.Domain.Features.BuiltIns.CustomersTransactions.Inputs;
using FluentValidation;

namespace Aban360.ReportPool.Application.Features.BuiltsIns.CustomersTransactions.Validations
{
    public class EmptyUnitValidator : BaseValidator<EmptyUnitInputDto>
    {
        public EmptyUnitValidator()
        {
            RuleFor(customer => customer.FromEmptyUnit)
         .NotEmpty().WithMessage(ExceptionLiterals.NotNull)
         .NotNull().WithMessage(ExceptionLiterals.NotNull);

            RuleFor(customer => customer.ToEmptyUnit)
           .NotEmpty().WithMessage(ExceptionLiterals.NotNull)
           .NotNull().WithMessage(ExceptionLiterals.NotNull);
        }
    }
}
