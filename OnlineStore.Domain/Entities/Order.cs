using System;
using OnlineStore.Domain.Common;

namespace OnlineStore.Domain.Entities
{
    public sealed class Order : BaseEntity
    {
        public Product Product { get; set; }
        public User Buyer { get; set; }
    }
}

