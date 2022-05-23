﻿using Alefba.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alefba.Application.Queries
{
    public class GetExchangeAverageInSpecificDateRequest : IRequest<double>
    {
        public DateTime startDateTime { get; set; }
        public DateTime endDateTime { get; set; }
    }
}