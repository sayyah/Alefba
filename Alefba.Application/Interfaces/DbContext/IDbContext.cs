namespace Alefba.Application.Interfaces
{
    public interface IDbContext
    {
        object GetCollection<T>(string name);
        void AddCommand(Func<Task> func);
        Task<int> SaveChanges();
        void Dispose();
    }
}
