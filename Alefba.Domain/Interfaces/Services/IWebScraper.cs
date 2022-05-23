using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alefba.Domain.Interfaces
{
    public interface IWebScraper<TEntity>
    {
        Task<TEntity> GetDate();
    }
}
