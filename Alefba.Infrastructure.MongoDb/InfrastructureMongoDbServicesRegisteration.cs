using Alefba.Application.Interfaces;
using Alefba.Infrastructure.MongoDb.DbContexts;
using Alefba.Infrastructure.MongoDb.Repository;
using Alefba.Infrastructure.MongoDb.Repository.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Alefba.Infrastructure.MongoDb
{
    public static class InfrastructureMongoDbServicesRegisteration
    {
        public static IServiceCollection ConfigureInfrastructureMongoDbServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DbConfiguration>(configuration.GetSection("DbConfiguration"));

            //services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IDbContext, DbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IExchangeRepository, ExchangeRepository>();
            return services;
        }
    }
}
