﻿using Aban360.CalculationPool.Domain.Features.Bill.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aban360.CalculationPool.Domain.Features.Rule.Entties;

[Table(nameof(Tariff))]
public class Tariff
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public short LineItemTypeId { get; set; }

    public short OfferingId { get; set; }

    public string Condition { get; set; } = null!;

    public string Formula { get; set; } = null!;

    public string FromDateJalali { get; set; } = null!;

    public string ToDateJalali { get; set; } = null!;

    public string? Description { get; set; }

    public virtual LineItemType LineItemType { get; set; } = null!;

    public virtual Offering Offering { get; set; } = null!;

    [NotMapped]
    public double Consumption { get; set; }

    [NotMapped]
    public int Duration { get; set; }
}
