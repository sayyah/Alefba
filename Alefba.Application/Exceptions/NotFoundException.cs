using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alefba.Application.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string name,DateTime startDateTime,DateTime endDateTime) :base($"{name}  between {startDateTime} and {endDateTime} was not found")
        {

        }
        public NotFoundException(string name, object key) : base($"{name} ({key}) was not found")
        {

        }
    }
}
