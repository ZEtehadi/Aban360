﻿using Aban360.ReportPool.Domain.Base;
using Aban360.ReportPool.Domain.Features.BuiltIns.PaymentsTransactions.Inputs;
using Aban360.ReportPool.Domain.Features.BuiltIns.PaymentsTransactions.Outputs;

namespace Aban360.ReportPool.Persistence.Features.BuiltIns.PaymentTransactions.Contracts
{
    public interface IDebtorByDayDetailQueryService
    {
        Task<ReportOutput<DebtorByDayHeaderOutputDto, DebtorByDayDetailDataOutputDto>> GetInfo(DebtorByDayInputDto input);
    }
}
