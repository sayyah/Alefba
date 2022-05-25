using Alefba.Application.Interfaces;
using Alefba.Domain.Entities;

namespace Alefba.Application.UnitTests.Mocks
{
    public class MockExchangeRepository:IExchangeRepository
    {
        private readonly List<Exchange> _exchanges;
        public MockExchangeRepository()
        {
            _exchanges = new List<Exchange>
            {
                new Exchange(255000,"USD"),
                new Exchange(250000,"USD")
            };
        }
        public async Task<double> GetAverageInSpecificDate(DateTime startDateTime, DateTime endDateTime)
        {
            var average = _exchanges.Where(d => d.DateTime >= startDateTime && d.DateTime <= endDateTime)
                .Average(g => g.Rate);
            return average;
        }

        public async Task<Exchange?> GetById(Guid id, CancellationToken cancellationToke)
        {
            return _exchanges.FirstOrDefault(x => x.Id == id);
        }

        public async Task Add(Exchange entity, CancellationToken cancellationToke)
        {
            _exchanges.Add(entity);
        }

        public Task<Exchange> Update(Exchange entity, CancellationToken cancellationToke)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Exchange entity, CancellationToken cancellationToke)
        {
            throw new NotImplementedException();
        }
    }
}
