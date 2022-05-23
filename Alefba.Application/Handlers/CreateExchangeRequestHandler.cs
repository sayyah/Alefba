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
    public class CreateExchangeRequestHandler : IRequestHandler<CreateExchangeCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateExchangeRequestHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateExchangeCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateExchangeCommandValidator();
            var validatorResult = await validator.ValidateAsync(request);

            if (validatorResult.IsValid == false)
                throw new ValidationException(validatorResult);

            var exchange = _mapper.Map<Exchange>(request);
            _unitOfWork.ExchangeRepository.Add(exchange, cancellationToken);
            await _unitOfWork.Commit();

            return exchange.Id;
        }

    }
}
