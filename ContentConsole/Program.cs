using Application.Greet;
using Application.Interfaces;
using Application.Prompt;
using Application.Report;
using KinderConsole.HostedServices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistence;
using System.Threading.Tasks;

namespace KinderConsole
{
    public static class Program
    {
        static async Task Main(string[] args)
        {
            await CreateHostBuilder(args).Build().RunAsync();
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureServices((_, services) =>
            {
                services.AddHostedService<ContentCleanerHostedService>()
                    .AddTransient<IGreetingService, GreetingService>()
                    .AddTransient<IConsoleIOManager, ConsoleIOManager>()
                    .AddTransient<IContentPromptingService, ContentPromptingService>()
                    .AddTransient<IUnkindContentReporterService, UnkindContentReporterService>()
                    .AddTransient<IBannedWordRepository, BannedWordRepository>();
            });
    }
}
