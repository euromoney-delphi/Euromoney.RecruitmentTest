using Application.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Application.Greet
{
    public class GreetingService : IGreetingService
    {
        private readonly IConsoleIOManager _consoleIOManager;
        private readonly IConfiguration _configuration;

        public GreetingService(
            IConsoleIOManager consoleIOManager,
            IConfiguration configuration
            )
        {
            _consoleIOManager = consoleIOManager;
            _configuration = configuration;
        }
        public void Greet()
        {
            var greetingMessageText = _configuration["GreetingMessage"];
            _consoleIOManager.OutputTextToConsole(greetingMessageText);
        }
    }
}
