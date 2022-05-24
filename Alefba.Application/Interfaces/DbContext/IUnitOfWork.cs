namespace Alefba.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IExchangeRepository ExchangeRepository { get; }
        Task Commit();
    }
}
