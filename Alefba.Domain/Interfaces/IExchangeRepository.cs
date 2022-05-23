using Alefba.Application.Persistence.Contracts;
using Alefba.Domain.Entities;

namespace Alefba.Domain.Interfaces
{
    public interface IExchangeRepository : IGenericRepository<Exchange>
    {
        Task<IReadOnlyList<Exchange>> GetInSpecificDate(DateTime startDateTime, DateTime endDateTime);
    }
}
