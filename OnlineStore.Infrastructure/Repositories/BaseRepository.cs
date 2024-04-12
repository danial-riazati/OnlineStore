using System;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Application.Repositories;
using OnlineStore.Domain.Common;
using OnlineStore.Infrastructure.Context;

namespace OnlineStore.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly DataContext Context;

        public BaseRepository(DataContext context)
        {
            Context = context;
        }

        public void Create(T entity)
        {
            entity.DateCreated = DateTimeOffset.UtcNow;
            Context.Add(entity);
        }

        public void Delete(T entity)
        {
            entity.DateDeleted = DateTimeOffset.UtcNow;
            Context.Remove(entity);
        }

        public Task<T> Get(Guid Id, CancellationToken cancellationToken)
        {
            return Context.Set<T>().FirstOrDefaultAsync(x => x.Id == Id, cancellationToken);
        }

        public Task<List<T>> GetAll(CancellationToken cancellationToken)
        {
            return Context.Set<T>().ToListAsync(cancellationToken);
        }

        public void Update(T entity)
        {
            entity.DateUpdated = DateTimeOffset.UtcNow;
            Context.Update(entity);
        }
    }
}

