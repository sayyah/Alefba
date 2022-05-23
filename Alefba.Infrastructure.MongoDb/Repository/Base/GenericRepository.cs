using Alefba.Domain.Interfaces;
using Alefba.Infrastructure.MongoDb.DbContexts;
using Alefba.Infrastructure.MongoDb.Utilities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alefba.Infrastructure.MongoDb.Repository.Base
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly IDbContext _context;
        protected readonly IMongoCollection<TEntity> DbSet;

        protected GenericRepository(IDbContext context)
        {
            _context = context;
            DbSet = _context.GetCollection<TEntity>(typeof(TEntity).GetName());
        }

        public Task<TEntity> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<TEntity>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
