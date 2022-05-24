using MediatR;

namespace Alefba.Application.Queries
{
    public class GetExchangeAverageInSpecificDateRequest : IRequest<double>
    {
        public DateTime startDateTime { get; set; }
        public DateTime endDateTime { get; set; }
    }
}
