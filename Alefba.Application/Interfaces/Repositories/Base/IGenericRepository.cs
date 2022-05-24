namespace Alefba.Application.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity?> GetById(Guid id, CancellationToken cancellationToke);
        void Add(TEntity entity, CancellationToken cancellationToke);
        Task<TEntity> Update(TEntity entity, CancellationToken cancellationToke);
        void Delete(TEntity entity, CancellationToken cancellationToke);
    }
}
