using Alefba.Domain;
using Alefba.Application.Interfaces;
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

        public async Task Add(TEntity entity, CancellationToken cancellationToken)
        {
            await DbSet.InsertOneAsync(entity, cancellationToken: cancellationToken);
        }

        public async Task<TEntity> Update(TEntity entity, CancellationToken cancellationToken)
        {
            var filter = Builders<TEntity>.Filter.Eq(f => f.Id, entity.Id);

            await DbSet.ReplaceOneAsync(filter, entity, cancellationToken: cancellationToken);

            return (await GetById(entity.Id, cancellationToken))!;
        }

        public async Task Delete(TEntity entity, CancellationToken cancellationToken)
        {
             await DbSet.DeleteOneAsync(f => f.Id.Equals(entity.Id), cancellationToken: cancellationToken);
        }
    }
}
