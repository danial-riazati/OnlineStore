using System;
using MediatR;

namespace OnlineStore.Application.Features.ProductFeatures.CreateProduct
{
    public class CreateProductRequest : IRequest<CreateProductResponse>
    {
        public string Title { get; set; }
        public int InventoryCount { get; set; }
        public int Price { get; set; }
        public double Discount { get; set; }
    }
}

