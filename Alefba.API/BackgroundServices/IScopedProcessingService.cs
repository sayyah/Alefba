using Alefba.Application.Interfaces;
using MediatR;

namespace Alefba.API.BackgroundServices
{
    internal interface IScopedProcessingService
    {
        Task DoWork(CancellationToken cancellationToken);
    }
    internal class ScopedProcessingService : IScopedProcessingService
    {
        private readonly IWebScraper _webScraper;
        private readonly IMediator _mediator;

        public ScopedProcessingService(IWebScraper webScraper, IMediator mediator)
        {
            _webScraper = webScraper;
            _mediator = mediator;
        }


        public async Task DoWork(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var createExchangeCommand = await _webScraper.GetDate();

                await _mediator.Send(createExchangeCommand);
                await Task.Delay(3000, cancellationToken);
            }
        }

    }


}
