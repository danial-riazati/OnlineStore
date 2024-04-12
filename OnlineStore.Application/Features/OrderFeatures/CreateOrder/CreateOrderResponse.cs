using System;
namespace OnlineStore.Application.Features.OrderFeatures.CreateOrder
{
    public sealed class CreateOrderResponse
    {
        public Guid Id { get; set; }
        public ProductOfOrder Product { get; set; }
        public UserOfOrder User { get; set; }
    }

    public sealed class ProductOfOrder
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int InventoryCount { get; set; }
        public int Price { get; set; }
        public double Discount { get; set; }
        public int FinalPrice { get; set; }
        public DateTimeOffset DateCreated { get; set; }
    }
    public sealed class UserOfOrder
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}

