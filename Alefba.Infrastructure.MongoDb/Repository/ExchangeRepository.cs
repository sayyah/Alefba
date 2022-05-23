using Alefba.Domain.Entities;
using Alefba.Domain.Interfaces;
using Alefba.Infrastructure.MongoDb.DbContexts;
using Alefba.Infrastructure.MongoDb.Repository.Base;
using MongoDB.Driver;

namespace Alefba.Infrastructure.MongoDb.Repository
{
    public class ExchangeRepository : GenericRepository<Exchange>, IExchangeRepository
    {
        public ExchangeRepository(IDbContext context) : base(context)
        {
        }

        public async Task<double> GetAverageInSpecificDate(DateTime startDateTime, DateTime endDateTime)
        {
            var average = DbSet.AsQueryable().Where(d => d.DateTime >= startDateTime && d.DateTime <= endDateTime).Average(a => a.Rate);
           
            return average;
        }
    }
}
