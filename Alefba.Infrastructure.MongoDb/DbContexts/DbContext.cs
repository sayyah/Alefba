using Alefba.Application.Interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace Alefba.Infrastructure.MongoDb.DbContexts
{
    public class DbContext : IDbContext
    {

        private IMongoDatabase Database { get; set; }
        public MongoClient MongoClient { get; set; }

        public DbContext(IOptions<DbConfiguration> configurations, IHostEnvironment webHostEnvironment)
        {
            BsonDefaults.GuidRepresentation = GuidRepresentation.CSharpLegacy;



            var databaseName = $"{configurations.Value.DbName}_{webHostEnvironment.EnvironmentName}".ToLower();

            MongoClient = new MongoClient(configurations.Value.ConnectionString);
            Database = MongoClient.GetDatabase(databaseName);
        }



        public object GetCollection<T>(string name)
        {
            return Database.GetCollection<T>(name);
        }

    }       
}
