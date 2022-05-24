using Alefba.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Alefba.Infrastructure
{
    public static class InfrastructureServicesRegisteration
    {
        public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services)
        {
            services.AddTransient<IWebScraper, WebScraper>();

            return services;
        }
    }
}
