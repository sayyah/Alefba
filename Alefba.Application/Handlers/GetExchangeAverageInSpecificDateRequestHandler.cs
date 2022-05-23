using Alefba.Application.DTOs;
using Alefba.Application.Exceptions;
using Alefba.Application.Queries;
using Alefba.Application.Validators;
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
    public class GetExchangeAverageInSpecificDateRequestHandler : IRequestHandler<GetExchangeAverageInSpecificDateRequest, double>
    {
        private readonly IExchangeRepository _exchangeRepository;
        private readonly IMapper _mapper;

        public GetExchangeAverageInSpecificDateRequestHandler(IExchangeRepository exchangeRepository, IMapper mapper)
        {
            _exchangeRepository = exchangeRepository;
            _mapper = mapper;
        }

        public async Task<double> Handle(GetExchangeAverageInSpecificDateRequest request, CancellationToken cancellationToken)
        {
            var validator = new GetExchangeAverageInSpecificDateRequestValidator();
            var validatorResult = await validator.ValidateAsync(request);

            if (validatorResult.IsValid == false)
                throw new ValidationException(validatorResult);

            var average = await _exchangeRepository.GetAverageInSpecificDate(request.startDateTime, request.endDateTime);

            if (average == 0.0)
                throw new NotFoundException(nameof(Exchange), request.startDateTime, request.endDateTime);

            return average;
        }
    }
}
