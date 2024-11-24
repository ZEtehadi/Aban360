﻿namespace Aban360.UserPool.Domain.Features.Auth.Entities;

public class Role
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string? DefaultClaims { get; set; }
    public int? PreviousId { get; set; }
    public DateTime ValidFrom { get; set; }
    public DateTime? ValidTo { get; set; }
    public string InsertLogInfo { get; set; } = null!;
    public string? RemoveLogInfo { get; set; }
    public string Hash { get; set; } = null!;

    public virtual ICollection<Role> InversePrevious { get; set; } = new List<Role>();
    public virtual Role? Previous { get; set; }
    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
