using Alefba.Domain.Entities;
using MediatR;

namespace Alefba.Application.Commands
{
    public class CreateExchangeCommand : IRequest<Guid>
    {
        public CreateExchangeCommand(int rate, string symbol)
        {
            Rate = rate;
            Symbol = symbol;
            DateTime = DateTime.UtcNow;
        }
        public int Rate { get; set; }
        public DateTime DateTime { get; set; }
        public string Symbol { get; set; }
    }
}
