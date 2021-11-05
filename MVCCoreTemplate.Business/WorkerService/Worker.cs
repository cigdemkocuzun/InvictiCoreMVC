using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MVCCoreTemplate.Business.Abstract;
using MVCCoreTemplate.DataAccess.Concrete.EntityFramework;
using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace MVCCoreTemplate.Business.WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        private readonly IEmailSender _emailSender;

        private readonly IServiceProvider _services;

        public Worker(ILogger<Worker> logger, IServiceProvider services, IEmailSender emailSender)
        {
            _logger = logger;
            _services = services;
            _emailSender = emailSender;

    }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                //Create the scope
                using (var scope = _services.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

                    var applications = context.Applications.ToList();

                    foreach (var item in applications)
                    {
                        await ChekServiceAsync(item.Url);
                        await Task.Delay(item.MonitoringInterval, stoppingToken);
                    }
                }
            }
        }

        public async Task ChekServiceAsync(string urlAdress)
        {
            try
            {
                // try accessing the web service directly via it's URL
                HttpWebRequest request = WebRequest.Create(urlAdress) as HttpWebRequest;
                request.Timeout = 30000;

                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        await _emailSender.SendEmailAsync("", urlAdress + "is down !", $"Error! App can not be reached at the moment!");

                        _logger.LogError("Url is down");
                    }
                }
            }
            catch (WebException ex)
            {
                // decompose 400- codes here if you like
                _logger.LogError(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
    }
}
