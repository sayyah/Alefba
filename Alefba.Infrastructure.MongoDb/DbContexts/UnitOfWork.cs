﻿using Alefba.Application.Exceptions;
using Alefba.Domain.Interfaces;
using Alefba.Infrastructure.MongoDb.Repository;
using System.Net;

namespace Alefba.Infrastructure.MongoDb.DbContexts
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContext _context;
        private  IExchangeRepository _exchangeRepository;

        public UnitOfWork(IDbContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            if (await _context.SaveChanges() == 0)
                throw new CustomException(HttpStatusCode.InternalServerError);
        }

        public IExchangeRepository ExchangeRepository => _exchangeRepository ??= new ExchangeRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
