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
        private readonly IConfiguration _configuration;

        public ScopedProcessingService(IWebScraper webScraper, IMediator mediator, IConfiguration configuration)
        {
            _webScraper = webScraper;
            _mediator = mediator;
            _configuration = configuration;
        }


        public async Task DoWork(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var createExchangeCommand = await _webScraper.GetDate();

                var delay = Convert.ToInt32(_configuration.GetSection("RetryTimeSpan").Value);
                await _mediator.Send(createExchangeCommand);
                await Task.Delay(delay, cancellationToken);
            }
        }

    }


}
