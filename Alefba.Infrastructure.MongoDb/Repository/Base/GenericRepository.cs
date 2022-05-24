using Alefba.Domain;
using Alefba.Domain.Interfaces;
using Alefba.Infrastructure.MongoDb.Utilities;
using MongoDB.Driver;

namespace Alefba.Infrastructure.MongoDb.Repository.Base
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseDomainEntity
    {
        private readonly IDbContext _context;
        protected readonly IMongoCollection<TEntity> DbSet;

        protected GenericRepository(IDbContext context)
        {
            _context = context;
            DbSet = (IMongoCollection<TEntity>)_context.GetCollection<TEntity>(typeof(TEntity).GetName());
        }

        public async Task<TEntity?> GetById(Guid id, CancellationToken cancellationToken)
        {
            var data = await DbSet.FindAsync(Builders<TEntity>.Filter.Eq(f => f.Id, id), cancellationToken: cancellationToken);

            return data.SingleOrDefault();
        }

        public void Add(TEntity entity, CancellationToken cancellationToken)
        {
            _context.AddCommand(async () => await DbSet.InsertOneAsync(entity, cancellationToken: cancellationToken));
        }

        public async Task<TEntity> Update(TEntity entity, CancellationToken cancellationToken)
        {
            var filter = Builders<TEntity>.Filter.Eq(f => f.Id, entity.Id);

            _context.AddCommand(async () =>
            {
                await DbSet.ReplaceOneAsync(filter, entity, cancellationToken: cancellationToken);
            });

            return (await GetById(entity.Id, cancellationToken))!;
        }

        public virtual void Delete(TEntity entity, CancellationToken cancellationToken)
        {
            _context.AddCommand(async () =>
             await DbSet.DeleteOneAsync(f => f.Id.Equals(entity.Id), cancellationToken: cancellationToken));
        }
    }
}
