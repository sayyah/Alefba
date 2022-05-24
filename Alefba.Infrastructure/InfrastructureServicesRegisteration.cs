using Alefba.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Alefba.Infrastructure
{
    public static class InfrastructureServicesRegisteration
    {
        public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IWebScraper<>), typeof(WebScraper<>));

            return services;
        }
    }
}
