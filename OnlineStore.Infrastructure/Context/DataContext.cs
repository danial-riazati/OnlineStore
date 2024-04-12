using System;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Infrastructure.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .HasIndex(e => e.Title)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(e => e.Name)
                .IsUnique();
        }
    }
}

