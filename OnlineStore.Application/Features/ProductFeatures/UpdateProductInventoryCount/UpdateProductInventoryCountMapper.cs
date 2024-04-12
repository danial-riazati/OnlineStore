using System;
using AutoMapper;
using OnlineStore.Application.Features.OrderFeatures.CreateOrder;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Application.Features.ProductFeatures.UpdateProductInventoryCount
{
    public class UpdateProductInventoryCountMapper : Profile
    {
        public UpdateProductInventoryCountMapper()
        {
            CreateMap<UpdateProductInventoryCountRequest, Product>();
            CreateMap<Product, UpdateProductInventoryCountResponse>();
        }
    }
}

