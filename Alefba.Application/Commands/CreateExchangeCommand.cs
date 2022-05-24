using MediatR;

namespace Alefba.Application.Commands
{
    public class CreateExchangeCommand : IRequest<Guid>
    {
        public int Rate { get; set; }
        public DateTime DateTime { get; set; }
        public string Symbol { get; set; }
    }
}
