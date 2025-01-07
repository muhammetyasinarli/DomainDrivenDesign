using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DomainDriventDesign.Domain.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace DomainDriventDesign.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services) {

            services.AddMediatR(cfr =>
            {
                cfr.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly(),
                    typeof(Entity).Assembly);
            });

            return services;
        
        }
    }
}
