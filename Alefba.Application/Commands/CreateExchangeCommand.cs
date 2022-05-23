using Alefba.Application.DTOs;
using MediatR;

namespace Alefba.Application.Features.Exchange.Requests.Commands
{
    public class CreateExchangeCommand : IRequest<Guid>
    {
        public ExchangeDto ExchangeDto { get; set; }
    }
}
