using Core.Domain.Services.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Core.Domain.Services
{
    public class BackgroundServices : IHostedService, IDisposable
    {
        private readonly ILogger<BackgroundServices> logger;
        private Timer timer;

        private readonly IGameResultServices gameResult;
        private readonly IConfiguration Configuration;
        private readonly IJsonDataServices jsonData;

        public BackgroundServices(ILogger<BackgroundServices> logger, IConfiguration configuration, IGameResultServices _gameResult, IJsonDataServices _jsonData)
        {
            this.logger = logger;
            Configuration = configuration;
            gameResult = _gameResult;
            jsonData = _jsonData;
        }

        public void Dispose()
        {
            timer?.Dispose();
        }

        public Task StartAsync(CancellationToken cancelationToken)
        {
            timer = new Timer(o =>
            {
                var lstGameResult = gameResult.GetMemory();

                //Save before clear memory
                if (lstGameResult != null && lstGameResult.Count() > 0)
                {
                    jsonData.SaveInDataJson(lstGameResult);
                }
                
                //Clean Memory
                gameResult.ClearMemory();


            }, null, TimeSpan.Zero, TimeSpan.FromSeconds(Int32.Parse(Configuration["SaveConfiguration:Timer"])));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancelationToken)
        {
            logger.LogInformation("Stopping");
            return Task.CompletedTask;
        }



    }
}
