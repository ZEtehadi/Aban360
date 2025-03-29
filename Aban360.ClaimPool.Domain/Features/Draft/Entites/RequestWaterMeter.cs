﻿using Aban360.ClaimPool.Domain.Features._Base;
using Aban360.ClaimPool.Domain.Features.Metering.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aban360.ClaimPool.Domain.Features.Draft.Entites
{
    public class RequestWaterMeter: WaterMeterBase
    {
        public virtual RequestEstate RequestEstate { get; set; } = null!;
        public virtual ICollection<RequestWaterMeter> InverseParent { get; set; } = new List<RequestWaterMeter>();

        public virtual MeterDiameter MeterDiameter { get; set; } = null!;

        public virtual MeterMaterial MeterMaterial { get; set; } = null!;

        public virtual MeterProducer MeterProducer { get; set; } = null!;

        public virtual MeterType MeterType { get; set; } = null!;

        public virtual MeterUseType MeterUseType { get; set; } = null!;

        [ForeignKey(nameof(ParentId))]
        public virtual RequestWaterMeter? Parent { get; set; }

        public virtual UseState UseState { get; set; } = null!;
        public virtual SubscriptionType SubscriptionType { get; set; } = null!;

        public virtual ICollection<RequestWaterMeterSiphon> RequestWaterMeterSiphons { get; set; } = new List<RequestWaterMeterSiphon>();
        public virtual ICollection<RequestWaterMeterTag> RequestWaterMeterTags { get; set; } = new List<RequestWaterMeterTag>();
    }
}
