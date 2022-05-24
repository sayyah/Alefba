using Alefba.Domain.Interfaces;

namespace Alefba.Infrastructure
{
    public class WebScraper<CreateEchangeCommand> : IWebScraper<CreateEchangeCommand>
    {
        public Task<CreateEchangeCommand> GetDate()
        {
            throw new NotImplementedException();
        }
    }
}
