using System;
namespace OnlineStore.Application.Features.OrderFeatures.CreateOrder
{
    public sealed class CreateOrderResponse
    {
        public Guid Id { get; set; }
        public DateTimeOffset DateCreated { get; set; }
    }
}

