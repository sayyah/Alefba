namespace Alefba.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IExchangeRepository ExchangeRepository { get; }
        Task Commit();
    }
}
