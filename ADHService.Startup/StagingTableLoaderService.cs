using System.Threading;
using System.Threading.Tasks;
using ADHService.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ADHService
{
    public class StagingTableLoaderService
        : IHostedService
    {
        private readonly ILogger<StagingTableLoaderService> _logger;
        private readonly ETLService _eTLService;

        public StagingTableLoaderService(
            ILogger<StagingTableLoaderService> logger,
            IHostApplicationLifetime appLifetime,
            ETLService eTLService)
        {
            _logger = logger;
            _eTLService = eTLService;
            appLifetime.ApplicationStarted.Register(OnStarted);
            appLifetime.ApplicationStopping.Register(OnStopping);
            appLifetime.ApplicationStopped.Register(OnStopped);
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("StartAsync has been called.");
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("StopAsync has been called.");
            return Task.CompletedTask;
        }

        private void OnStarted()
        {
            _logger.LogInformation("OnStarted has been called.");
            _eTLService.DoItAsync();
        }

        private void OnStopping()
        {
            _logger.LogInformation("OnStopping has been called.");
        }

        private void OnStopped()
        {
            _logger.LogInformation("OnStopped has been called.");
        }
    }
}