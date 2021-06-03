using Application.Greet;
using Application.Prompt;
using Application.Report;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace KinderConsole.HostedServices
{
    public class ContentCleanerHostedService : IHostedService
    {
        private readonly IGreetingService _greetingService;
        private readonly IHostApplicationLifetime _hostApplicationLifetime;
        private readonly IContentPromptingService _contentPromptingService;
        private readonly IUnkindContentReporterService _unkindContentReporterService;

        public ContentCleanerHostedService(
            IGreetingService greetingService,
            IHostApplicationLifetime hostApplicationLifetime,
            IContentPromptingService contentPromptingService,
            IUnkindContentReporterService unkindContentReporterService
            )
        {
            _greetingService = greetingService;
            _hostApplicationLifetime = hostApplicationLifetime;
            _contentPromptingService = contentPromptingService;
            _unkindContentReporterService = unkindContentReporterService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _greetingService.Greet();

            //UserService class calls would go here to determine user type and then provide features available to each user type, respectively.

            var content = _contentPromptingService.PromptForContent();
            var report = _unkindContentReporterService.ProduceReport(content);

            //with more time I would factor this into a UnkindContentReportDisplayService
            Console.WriteLine("Scanned the text:");
            Console.WriteLine(content);
            Console.WriteLine("Total Number of negative words: " + report.NegativeWordCount);

            Console.WriteLine("Press ANY key to exit.");

            _hostApplicationLifetime.StopApplication();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
