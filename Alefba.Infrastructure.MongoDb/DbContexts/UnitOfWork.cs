using Alefba.Application.Exceptions;
using Alefba.Application.Interfaces;
using Alefba.Infrastructure.MongoDb.Repository;
using System.Net;

namespace Alefba.Infrastructure.MongoDb.DbContexts
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContext _context;
        private IExchangeRepository _exchangeRepository;

        public UnitOfWork(IDbContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            return;
        }

        public IExchangeRepository ExchangeRepository => _exchangeRepository ??= new ExchangeRepository(_context);

    
    }
}
