namespace Alefba.Domain.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IExchangeRepository ExchangeRepository { get; }
        Task Commit();
    }
}
