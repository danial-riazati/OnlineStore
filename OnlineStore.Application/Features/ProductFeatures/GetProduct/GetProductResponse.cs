using System;
using MediatR;
namespace OnlineStore.Application.Features.ProductFeatures.GetProduct
{
    public sealed class GetProductResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int InventoryCount { get; set; }
        public int Price { get; set; }
        public double Discount { get; set; }
        public int FinalPrice { get; set; }
        public DateTimeOffset DateCreated { get; set; }
    }
}

