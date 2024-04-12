using System;
using OnlineStore.Domain;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Application.Repositories
{
    public interface IProductRepository : IBaseRepository<Domain.Entities.Product>
    {
        Task<Product> GetByTitle(string title, CancellationToken cancellationToken);

    }
}

