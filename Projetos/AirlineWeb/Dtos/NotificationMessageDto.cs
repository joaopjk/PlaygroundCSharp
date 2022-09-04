﻿using System;

namespace AirlineWeb.Dtos
{
    public class NotificationMessageDto
    {
        public string Id { get; }
        public string WebhookType { get; set; }
        public string FlightCode { get; set; }
        public decimal OldPrice { get; set; }
        public decimal NewPrice { get; set; }

        public NotificationMessageDto()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
