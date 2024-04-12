using System;
using MediatR;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Application.Features.OrderFeatures.CreateOrder

{
    public sealed class CreateOrderRequest : IRequest<CreateOrderResponse>
    {
        public string ProductTitle { get; set; }
        public string UserName { get; set; }
    }
}

