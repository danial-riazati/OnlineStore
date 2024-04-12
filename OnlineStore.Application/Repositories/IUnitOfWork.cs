using System;
namespace OnlineStore.Application.Repositories
{
    public interface IUnitOfWork
    {
        Task SaveChanges(CancellationToken cancellationToken);
    }
}

