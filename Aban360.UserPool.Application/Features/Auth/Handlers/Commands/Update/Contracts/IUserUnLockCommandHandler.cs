﻿using Aban360.UserPool.Domain.Features.Auth.Dto.Base;

namespace Aban360.UserPool.Application.Features.Auth.Handlers.Commands.Update.Contracts
{
    public interface IUserUnLockCommandHandler
    {
        Task Handle(UserIdDto userId, CancellationToken cancellationToken);
    }
}
