﻿using Aban360.Common.Literals;
using Aban360.InstallationPool.Application.Features.Base;
using Aban360.InstallationPool.Domain.Features.Definition.Dto.Commands;
using FluentValidation;

namespace Aban360.InstallationPool.Application.Features.Definition.Validations
{
    public class EquipmentBrokerZoneCreateValidator : BaseValidator<EquipmentBrokerZoneCreateDto>
    {
        public EquipmentBrokerZoneCreateValidator()
        {
            RuleFor(f => f.ZoneId)
              .NotEmpty().WithMessage(ExceptionLiterals.NotNull)
              .NotNull().WithMessage(ExceptionLiterals.NotNull);

            RuleFor(f => f.EquipmentBrokerId)
              .NotEmpty().WithMessage(ExceptionLiterals.NotNull)
              .NotNull().WithMessage(ExceptionLiterals.NotNull);
        }
    }
}
