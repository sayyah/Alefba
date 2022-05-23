using Alefba.Domain.Entities;
using Alefba.Domain.Interfaces.Repository;
using Alefba.Infrastructure.MongoDb.DbContexts;
using Alefba.Infrastructure.MongoDb.Repository.Base;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
