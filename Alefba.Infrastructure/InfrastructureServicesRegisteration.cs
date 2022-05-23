using Alefba.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alefba.Infrastructure
{
    public static class InfrastructureServicesRegisteration
    {
        public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IWebScraper<>),typeof(WebScraper<>));

            return services;
        }
    }
}
