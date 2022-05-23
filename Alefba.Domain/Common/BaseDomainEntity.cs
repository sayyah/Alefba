using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alefba.Domain
{
    public abstract class BaseDomainEntity
    {
        public Guid  Id { get; set; }
    }
}
