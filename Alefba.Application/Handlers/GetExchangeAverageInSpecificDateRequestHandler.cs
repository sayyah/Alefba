using Alefba.Application.Exceptions;
using Alefba.Application.Queries;
using Alefba.Application.Validators;
using Alefba.Domain.Entities;
using Alefba.Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Alefba.Application.Handlers
{
    public class GetExchangeAverageInSpecificDateRequestHandler : IRequestHandler<GetExchangeAverageInSpecificDateRequest, double>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetExchangeAverageInSpecificDateRequestHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<double> Handle(GetExchangeAverageInSpecificDateRequest request, CancellationToken cancellationToken)
        {
            var validator = new GetExchangeAverageInSpecificDateRequestValidator();
            var validatorResult = await validator.ValidateAsync(request);

            if (validatorResult.IsValid == false)
                throw new ValidationException(validatorResult);

            var average = await _unitOfWork.ExchangeRepository.GetAverageInSpecificDate(request.startDateTime, request.endDateTime);

            if (average == 0.0)
                throw new NotFoundException(nameof(Exchange), request.startDateTime, request.endDateTime);

            return average;
        }
    }
}
