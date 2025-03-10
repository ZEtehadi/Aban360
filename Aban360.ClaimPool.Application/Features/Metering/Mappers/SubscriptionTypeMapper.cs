﻿using Aban360.ClaimPool.Domain.Features.Metering.Dto.Commands;
using Aban360.ClaimPool.Domain.Features.Metering.Dto.Queries;
using Aban360.ClaimPool.Domain.Features.Metering.Entities;
using AutoMapper;

namespace Aban360.ClaimPool.Application.Features.Metering.Mappers
{
    public class SubscriptionTypeMapper : Profile
    {
        public SubscriptionTypeMapper()
        {
            CreateMap<SubscriptionTypeCreateDto, SubscriptionType>().ReverseMap();
            CreateMap<SubscriptionTypeDeleteDto, SubscriptionType>().ReverseMap();
            CreateMap<SubscriptionTypeUpdateDto, SubscriptionType>().ReverseMap();
            CreateMap<SubscriptionTypeGetDto, SubscriptionType>().ReverseMap();
        }
    }
}
