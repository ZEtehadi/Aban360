﻿using Aban360.CalculationPool.Application.Features.Bill.Handlers.Commands.Update.Contracts;
using Aban360.CalculationPool.Domain.Features.Bill.Dtos.Commands;
using Aban360.CalculationPool.Domain.Features.Bill.Entities;
using Aban360.CalculationPool.Persistence.Features.Bill.Queries.Contracts;
using Aban360.Common.Extensions;
using AutoMapper;

namespace Aban360.CalculationPool.Application.Features.Bill.Handlers.Commands.Update.Implementation
{
    internal sealed class CompanyServiceOfferingUpdateHandler : ICompanyServiceOfferingUpdateHandler
    {
        private readonly IMapper _mapper;
        private readonly ICompanyServiceOfferingQueryService _companyServiceOfferingQueryService;
        public CompanyServiceOfferingUpdateHandler(
            IMapper mapper,
            ICompanyServiceOfferingQueryService companyServiceOfferingQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _companyServiceOfferingQueryService = companyServiceOfferingQueryService;
            _companyServiceOfferingQueryService.NotNull(nameof(companyServiceOfferingQueryService));
        }

        public async Task Handle(CompanyServiceOfferingUpdateDto updateDto, CancellationToken cancellationToken)
        {
            CompanyServiceOffering companyServiceOffering = await _companyServiceOfferingQueryService.Get(updateDto.Id);
            _mapper.Map(updateDto, companyServiceOffering);
        }
    }
}
