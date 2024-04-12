using System;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Application.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByName(string name, CancellationToken cancellationToken);
    }
}

