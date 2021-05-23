using ContentConsole.Processor;
using ContentConsole.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ContentConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context,services) =>
                {
                    services.AddScoped<IContentConsoleProcessor, ContentConsoleProcessor>();
                    services.AddScoped<IUserInputProcessor, UserInputProcessor>();
                    services.AddScoped<INegativeWordsApiService, NegativeWordsApiService>();
                })
                .Build();

            var service = ActivatorUtilities.CreateInstance<ContentConsoleProcessor>(host.Services);
            service.Run();
        }

    }
}

