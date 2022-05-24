using Alefba.Application.Commands;

namespace Alefba.Application.Interfaces
{
    public interface IWebScraper
    {
        Task<CreateExchangeCommand> GetDate();
    }
}
