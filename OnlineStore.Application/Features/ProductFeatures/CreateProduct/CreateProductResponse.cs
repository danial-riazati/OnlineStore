using System;
namespace OnlineStore.Application.Features.ProductFeatures.CreateProduct
{
    public class CreateProductResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int InventoryCount { get; set; }
        public int Price { get; set; }
        public double Discount { get; set; }
        public DateTimeOffset DateCreated { get; set; }
    }
}

