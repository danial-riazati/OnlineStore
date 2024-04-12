using System;
using OnlineStore.Domain;
namespace OnlineStore.Application.Repositories
{
    public interface IProductRepository : IBaseRepository<Domain.Entities.Product>
    {
    }
}

