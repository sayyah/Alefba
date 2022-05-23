using Alefba.Application.DTOs;
using Alefba.Application.Persistence.Contracts;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alefba.Application.Features.Exchange.Handlers.Queries
{
    public class GetExchangeListInSpecificDateRequestHandler:IRequestHandler<GetExchangeListRequest,List<ExchangeDto>>
    {
        private readonly IExchangeRepository _exchangeRepository;
        private readonly IMapper _mapper;

        public GetExchangeListInSpecificDateRequestHandler(IExchangeRepository exchangeRepository, IMapper mapper)
        {
            _exchangeRepository = exchangeRepository;
            _mapper = mapper;
        }

        public async Task<List<ExchangeDto>> Handle(GetExchangeListRequest request, CancellationToken cancellationToken)
        {
            var exchanges = await _exchangeRepository.GetInSpecificDate(request.startDateTime, request.endDateTime);
            return _mapper.Map<List<ExchangeDto>>(exchanges);
        }
    }
}
