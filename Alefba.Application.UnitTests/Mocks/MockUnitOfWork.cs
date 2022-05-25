using Alefba.Application.Interfaces;

namespace Alefba.Application.UnitTests.Mocks
{
    public  class MockUnitOfWork:IUnitOfWork
    {
        public MockUnitOfWork(IExchangeRepository exchangeRepository)
        {
            ExchangeRepository = exchangeRepository;
        }

        public IExchangeRepository ExchangeRepository { get; }

        public async Task Commit()
        {
            return;
        }
    }
}
