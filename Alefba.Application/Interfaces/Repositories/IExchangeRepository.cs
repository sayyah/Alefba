using Alefba.Domain.Entities;

namespace Alefba.Application.Interfaces
{
    public interface IExchangeRepository : IGenericRepository<Exchange>
    {
        Task<double> GetAverageInSpecificDate(DateTime startDateTime, DateTime endDateTime);
    }
}
