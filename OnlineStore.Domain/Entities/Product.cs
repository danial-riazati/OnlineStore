using System;
using System.ComponentModel.DataAnnotations;
using OnlineStore.Domain.Common;

namespace OnlineStore.Domain.Entities
{
    public sealed class Product : BaseEntity
    {
        public string Title { get; set; }
        [Range(0, int.MaxValue)]
        public int InventoryCount { get; set; }
        public int Price { get; set; }
        public double Discount { get; set; }
    }
}

