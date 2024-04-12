using System;
using MediatR;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Application.Features.OrderFeatures.CreateOrder

{
    public sealed class CreateOrderRequest : IRequest<CreateOrderResponse>
    {
        public Guid ProductId { get; set; }
        public Guid BuyerId { get; set; }
    }
}

