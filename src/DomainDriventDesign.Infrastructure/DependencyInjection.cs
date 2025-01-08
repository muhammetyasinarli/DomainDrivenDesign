using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using DomainDriventDesign.Domain.Abstractions;
using DomainDriventDesign.Domain.Categories;
using DomainDriventDesign.Domain.Orders;
using DomainDriventDesign.Domain.Products;
using DomainDriventDesign.Domain.Users;
using DomainDriventDesign.Infrastructure.Context;
using DomainDriventDesign.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DomainDriventDesign.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructureServices(this IHostApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            Guard.Against.Null(connectionString, message: "Connection string 'DefaultConnection' not found.");

            builder.Services.AddDbContext<ApplicationDbContext>
                (options => options.UseSqlServer(connectionString));

            builder.Services.AddScoped<IUnitOfWork>(opt => opt.GetRequiredService<ApplicationDbContext>());

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
        }
    }
}
