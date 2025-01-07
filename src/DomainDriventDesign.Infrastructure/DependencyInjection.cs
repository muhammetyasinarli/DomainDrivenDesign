using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainDriventDesign.Domain.Abstractions;
using DomainDriventDesign.Domain.Categories;
using DomainDriventDesign.Domain.Orders;
using DomainDriventDesign.Domain.Products;
using DomainDriventDesign.Domain.Users;
using DomainDriventDesign.Infrastructure.Context;
using DomainDriventDesign.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DomainDriventDesign.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services) 
        {
            services.AddScoped<ApplicationDbContext>();
            services.AddScoped<IUnitOfWork>(opt => opt.GetRequiredService<ApplicationDbContext>());

            services.AddScoped<IUserRepository, UserRepository>(); 
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}
