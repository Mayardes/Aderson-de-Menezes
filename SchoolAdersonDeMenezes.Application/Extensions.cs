using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace SchoolAdersonDeMenezes.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            return services;
        }
    }
}