using Alefba.Application.Exceptions;
using Alefba.Application.Features.Exchange.Requests.Commands;
using Alefba.Application.Responses;
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
    public class CreateExchangeRequestHandler : IRequestHandler<CreateExchangeCommand, CreateResponse>
    {
        private readonly IExchangeRepository _exchangeRepository;
        private readonly IMapper _mapper;

        public CreateExchangeRequestHandler(IExchangeRepository exchangeRepository, IMapper mapper)
        {
            _exchangeRepository = exchangeRepository;
            _mapper = mapper;
        }

        public async Task<CreateResponse> Handle(CreateExchangeCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateResponse();

            var validator = new CreateExchangeCommandValidator();
            var validatorResult = await validator.ValidateAsync(request);

            if (validatorResult.IsValid == false)
            {
                //throw new ValidationException(validatorResult);

                response.Success = false;
                response.Message = "Creation failed";
                response.Errors = validatorResult.Errors.Select(q=>q.ErrorMessage).ToList();
            }

            var exchange = _mapper.Map<Exchange>(request);
            exchange = await _exchangeRepository.Add(exchange);

            response.Success = true;
            response.Message = "Creation successful";
            response.Id= exchange.Id;
            return response;
        }

    }
}
