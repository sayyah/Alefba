namespace Alefba.Application.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity?> GetById(Guid id, CancellationToken cancellationToke);
        Task Add(TEntity entity, CancellationToken cancellationToke);
        Task<TEntity> Update(TEntity entity, CancellationToken cancellationToke);
        Task Delete(TEntity entity, CancellationToken cancellationToke);
    }
}
