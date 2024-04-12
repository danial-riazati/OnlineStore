using System;
using AutoMapper;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Application.Features.OrderFeatures.CreateOrder
{
    public class CreateOrderMapper : Profile
    {
        public CreateOrderMapper()
        {
            CreateMap<CreateOrderRequest, Order>();
            CreateMap<Order, CreateOrderResponse>();
        }

    }
}

