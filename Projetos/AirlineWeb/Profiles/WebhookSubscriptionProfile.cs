﻿using AirlineWeb.Dtos;
using AirlineWeb.Models;
using AutoMapper;

namespace AirlineWeb.Profiles
{
    public class WebhookSubscriptionProfile : Profile
    {
        public WebhookSubscriptionProfile()
        {
            CreateMap<WebhookSubscription, WebhookSubscriptionReadDto>();
            CreateMap<WebhookSubscriptionCreateDto, WebhookSubscription>();
        }
    }
}
