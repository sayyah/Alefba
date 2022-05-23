using Alefba.Application.DTOs;
using MediatR;

namespace Alefba.Application.Features.Exchange.Requests.Commands
{
    public class CreateExchangeCommand : IRequest<Guid>
    {
        public int Rate { get; set; }
        public DateTime DateTime { get; set; }
        public string Symbol { get; set; }
    }
}
