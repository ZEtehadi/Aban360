﻿namespace Aban360.ClaimPool.Domain.Features._Base.Entities;

public class FlatBase
{
    public int Id { get; set; }

    public int EstateId { get; set; }

    public string? PostalCode { get; set; }

    public short Storey { get; set; }

    public string? Description { get; set; }
}
