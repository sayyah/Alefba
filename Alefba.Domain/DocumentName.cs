using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alefba.Domain
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DocumentName : Attribute
    {
        public string Name { get; set; }
    }
}
