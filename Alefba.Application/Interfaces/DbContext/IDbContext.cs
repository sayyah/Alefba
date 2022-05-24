namespace Alefba.Application.Interfaces
{
    public interface IDbContext
    {
        object GetCollection<T>(string name);
    }
}
