using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainDriventDesign.Domain.Abstractions;
using DomainDriventDesign.Domain.Categories;
using DomainDriventDesign.Domain.Orders;
using DomainDriventDesign.Domain.Products;
using DomainDriventDesign.Domain.Shared;
using DomainDriventDesign.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace DomainDriventDesign.Infrastructure.Context
{
    internal sealed class ApplicationDbContext : DbContext, IUnitOfWork
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=DDD2;User ID=sa;Password=Password1;Pooling=False;Encrypt=True;Trust Server Certificate=True");
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(p => p.Name)
                .HasConversion(name => name.Value, value => new(value));

            modelBuilder.Entity<User>()
                .Property(p => p.Email)
                .HasConversion(email => email.Value, value => new(value));

            modelBuilder.Entity<User>()
                .Property(p => p.Password)
                .HasConversion(password => password.Value, value => new(value));

            modelBuilder.Entity<User>()
                .OwnsOne(p => p.Address);

            modelBuilder.Entity<Category>()
                .Property(p => p.Name)
                .HasConversion(name => name.Value, value => new(value));

            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .HasConversion(name => name.Value, value => new(value));

            modelBuilder.Entity<Product>()
                .OwnsOne(p => p.Price, priceBuilder =>
                {
                    priceBuilder
                    .Property(p => p.Currency)
                    .HasConversion(currency => currency.Code, code => Currency.FromCode(code));

                    priceBuilder.Property(p => p.Amount)
                    .HasColumnType("money");
                });

            modelBuilder.Entity<OrderLine>()
    .OwnsOne(p => p.Price, priceBuilder =>
    {
        priceBuilder
        .Property(p => p.Currency)
        .HasConversion(currency => currency.Code, code => Currency.FromCode(code));

        priceBuilder.Property(p => p.Amount)
        .HasColumnType("money");
    });

        }
    }
}
