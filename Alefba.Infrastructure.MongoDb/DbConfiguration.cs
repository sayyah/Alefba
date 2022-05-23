using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alefba.Infrastructure.MongoDb
{
    public class DbConfiguration
    {
        public string ConnectionString { get; set; }
        public string DbName { get; set; }
    }
}
