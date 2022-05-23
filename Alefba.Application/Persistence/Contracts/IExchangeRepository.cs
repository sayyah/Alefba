using Alefba.Domain;

namespace Alefba.Application.Persistence.Contracts
{
    public interface IExchangeRepository : IGenericRepository<Exchange>
    {
        Task<IReadOnlyList<Exchange>> GetInSpecificDate(DateTime startDateTime, DateTime endDateTime);
    }
}
