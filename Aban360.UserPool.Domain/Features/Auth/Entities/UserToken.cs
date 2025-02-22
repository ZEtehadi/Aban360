﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Aban360.UserPool.Domain.Features.Auth.Entities;

[Table(nameof(UserToken))]
public class UserToken
{
    public long Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime AccessTokenExpiresDateTime { get; set; }
    public string AccessTokenHash { get; set; } = null!;
    public DateTime RefreshTokenExpiresDateTime { get; set; }
    public string RefreshTokenIdHash { get; set; } = null!;
    public string? RefreshTokenIdHashSource { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}