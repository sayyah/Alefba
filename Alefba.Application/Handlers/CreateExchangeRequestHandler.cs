using Alefba.Application.Features.Exchange.Requests.Commands;
using Alefba.Domain.Entities;
using Alefba.Domain.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alefba.Application.Handlers
{
    public class CreateExchangeRequestHandler : IRequestHandler<CreateExchangeCommand, Guid>
    {
        private readonly IExchangeRepository _exchangeRepository;
        private readonly IMapper _mapper;

        public CreateExchangeRequestHandler(IExchangeRepository exchangeRepository, IMapper mapper)
        {
            _exchangeRepository = exchangeRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateExchangeCommand request, CancellationToken cancellationToken)
        {
            var exchange = _mapper.Map<Exchange>(request.ExchangeDto);
            exchange = await _exchangeRepository.Add(exchange);
            return exchange.Id;
        }

    }
}
