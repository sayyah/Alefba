using Alefba.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alefba.Application.Persistence.Contracts
{
    public interface IExchangeRepository:IGenericRepository<Exchange>
    {
        Task<IReadOnlyList<Exchange>> Get();
    }
}
