﻿using Aban360.CalculationPool.Application.Features.Bill.Handlers.Queries.Contracts;
using Aban360.CalculationPool.Domain.Features.Bill.Dtos.Queries;
using Aban360.CalculationPool.Domain.Features.Bill.Entities;
using Aban360.CalculationPool.Persistence.Features.Bill.Queries.Contracts;
using Aban360.Common.Extensions;
using AutoMapper;

namespace Aban360.CalculationPool.Application.Features.Bill.Handlers.Queries.Implementation
{
    internal sealed class InvoiceTypeGetSingleHandler : IInvoiceTypeGetSingleHandler
    {
        private readonly IMapper _mapper;
        private readonly IInvoiceTypeQueryService _invoiceTypeQueryService;
        public InvoiceTypeGetSingleHandler(
            IMapper mapper,
            IInvoiceTypeQueryService invoiceTypeQueryService)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _invoiceTypeQueryService = invoiceTypeQueryService;
            _invoiceTypeQueryService.NotNull(nameof(invoiceTypeQueryService));
        }

        public async Task<InvoiceTypeGetDto> Handle(short id, CancellationToken cancellationToken)
        {
            InvoiceType invoiceType = await _invoiceTypeQueryService.Get(id);
            return _mapper.Map<InvoiceTypeGetDto>(invoiceType);
        }
    }
}
