using MongoDB.Driver;

namespace Alefba.Infrastructure.MongoDb.DbContexts
{
    public interface IDbContext
    {
        IMongoCollection<T> GetCollection<T>(string name);
        void AddCommand(Func<Task> func);
        Task<int> SaveChanges();
        void Dispose();
    }
}
