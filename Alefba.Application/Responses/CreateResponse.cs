using Alefba.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alefba.Application.Responses
{
    public class CreateResponse:BaseResponse
    {
        public Guid Id { get; set; }
    }
}
