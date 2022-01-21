using System;
using System.Threading;
using Microsoft.Extensions.Logging;

namespace ADHService.Services
{
    public class ETLService
    {
        private readonly ILogger<ETLService> _logger;

        public ETLService(ILogger<ETLService> logger)
        {
            _logger = logger;
        }
        
        public bool DoItAsync() {
            _logger.LogInformation("About to Do IT !!");
            Thread.Sleep(5000);
            _logger.LogInformation("Done doing it!");
            return true;
        }
    }
}
