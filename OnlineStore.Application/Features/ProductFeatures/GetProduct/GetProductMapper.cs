using System;
using AutoMapper;
using OnlineStore.Application.Features.ProductFeatures.CreateProduct;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Application.Features.ProductFeatures.GetProduct
{
    public class GetProductMapper : Profile
    {
        public GetProductMapper()
        {
            CreateMap<Product, GetProductResponse>()
                .ForMember(d => d.FinalPrice, o => o.MapFrom(s => s.Price * ((100 - s.Discount) / 100)));

        }
    }
}

