﻿using Alefba.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alefba.Infrastructure
{
    public class WebScraper: IWebScraper<CreateEchangeCommand>
    {
        public Task<CreateEchangeCommand> GetDate()
        {
            throw new NotImplementedException();
        }
    }
}