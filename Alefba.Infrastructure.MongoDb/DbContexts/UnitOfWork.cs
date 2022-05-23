using Alefba.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Alefba.Infrastructure.MongoDb.DbContexts
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContext _context;

        public UnitOfWork(IDbContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            if (await _context.SaveChanges() == 0)
                throw new CustomException(HttpStatusCode.InternalServerError);
        }

    }
}
