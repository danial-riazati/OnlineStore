using System;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Application.Repositories;
using OnlineStore.Domain.Entities;
using OnlineStore.Infrastructure.Context;

namespace OnlineStore.Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public Task<Product> GetByTitle(string title, CancellationToken cancellationToken)
        {
            return _context.Products.FirstOrDefaultAsync(x => x.Title == title, cancellationToken);

        }
    }
}

