using System;
using OnlineStore.Domain.Common;

namespace OnlineStore.Domain.Entities
{
    public sealed class Product : BaseEntity
    {
        public string Title { get; set; }
        public int InventoryCount { get; set; }
        public int Price { get; set; }
        public double Discount { get; set; }
    }
}

