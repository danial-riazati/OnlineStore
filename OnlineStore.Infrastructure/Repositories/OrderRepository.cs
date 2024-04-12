using System;
using OnlineStore.Application.Repositories;
using OnlineStore.Domain.Entities;
using OnlineStore.Infrastructure.Context;

namespace OnlineStore.Infrastructure.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(DataContext context) : base(context)
        {
        }

    }
}

