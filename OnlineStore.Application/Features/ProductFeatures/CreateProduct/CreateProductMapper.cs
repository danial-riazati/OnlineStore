using System;
using AutoMapper;
using OnlineStore.Application.Features.OrderFeatures.CreateOrder;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Application.Features.ProductFeatures.CreateProduct
{
    public class CreateProductMapper : Profile
    {
        public CreateProductMapper()
        {
            CreateMap<CreateProductRequest, Product>();
            CreateMap<Product, CreateProductResponse>();
        }
    }
}

