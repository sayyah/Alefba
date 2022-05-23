using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alefba.Domain
{
    public class Exchange: BaseDomainEntity
    {
        public int Rate { get; set; }
        public DateTime DateTime { get; set; }
        public string Symbol { get; set; }
    }
}
