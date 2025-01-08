using System.Reflection;
using DomainDriventDesign.Domain.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DomainDriventDesign.Application
{
    public static class DependencyInjection
    {
        public static void AddApplicationServices(this IHostApplicationBuilder builder) {

            builder.Services.AddMediatR(cfr =>
            {
                cfr.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly(),
                    typeof(Entity).Assembly);
            });
        }
    }
}
