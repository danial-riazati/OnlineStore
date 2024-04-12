using System;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Application.Repositories;
using OnlineStore.Domain.Entities;
using OnlineStore.Infrastructure.Context;

namespace OnlineStore.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public Task<User> GetByName(string name, CancellationToken cancellationToken)
        {
            return _context.Users.FirstOrDefaultAsync(x => x.Name == name, cancellationToken);
        }
    }
}

