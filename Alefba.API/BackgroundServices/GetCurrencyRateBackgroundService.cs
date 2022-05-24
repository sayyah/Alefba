using Alefba.Application.Interfaces;

namespace Alefba.API.BackgroundServices
{
    public class GetCurrencyRateBackgroundService:BackgroundService
    {

        public IServiceProvider Services { get; }
        public GetCurrencyRateBackgroundService(IServiceProvider services)
        {
            Services = services;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            await DoWork(cancellationToken);
        }

        private async Task DoWork(CancellationToken stoppingToken)
        {
            using (var scope = Services.CreateScope())
            {
                var scopedProcessingService =
                    scope.ServiceProvider
                        .GetRequiredService<IScopedProcessingService>();

                await scopedProcessingService.DoWork(stoppingToken);
            }
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            await base.StopAsync(stoppingToken);
        }

    }
}
