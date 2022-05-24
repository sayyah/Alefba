namespace Alefba.Domain.Interfaces
{
    public interface IWebScraper<TEntity>
    {
        Task<TEntity> GetDate();
    }
}
