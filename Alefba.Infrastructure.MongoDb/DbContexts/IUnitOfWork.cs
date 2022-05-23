using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alefba.Infrastructure.MongoDb.DbContexts
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
