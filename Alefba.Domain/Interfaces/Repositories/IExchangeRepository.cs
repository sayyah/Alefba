using Alefba.Domain.Entities;

namespace Alefba.Domain.Interfaces
{
    public interface IExchangeRepository : IGenericRepository<Exchange>
    {
        Task<double> GetAverageInSpecificDate(DateTime startDateTime, DateTime endDateTime);
    }
}
