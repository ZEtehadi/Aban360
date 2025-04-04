﻿using Aban360.MeterPool.Domain.Features.Management.Dtos.Commands;

namespace Aban360.MeterPool.Application.Features.Management.Handlers.Commands.Update.Contracts
{
    public interface IReadingConfigDefaultUpdateHandler
    {
        Task Handle(ReadingConfigDefaultUpdateDto updateDto, CancellationToken cancellationToken);
    }
}
