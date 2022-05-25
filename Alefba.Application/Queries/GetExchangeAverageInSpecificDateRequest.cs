using MediatR;

namespace Alefba.Application.Queries
{
    public class GetExchangeAverageInSpecificDateRequest : IRequest<double>
    {
        public GetExchangeAverageInSpecificDateRequest(DateTime startDateTime, DateTime endDateTime)
        {
            this.startDateTime = startDateTime;
            this.endDateTime = endDateTime;
        }

        public DateTime startDateTime { get; set; }
        public DateTime endDateTime { get; set; }
    }
}
