using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Prompt
{
    public class ContentPromptingService : IContentPromptingService
    {
        private const string promptTextForContentEntry = "Please enter content to make more kind:";
        private readonly IConsoleIOManager _consoleIOManager;

        public ContentPromptingService(IConsoleIOManager consoleIOManager)
        {
            _consoleIOManager = consoleIOManager;
        }
        public string PromptForContent()
        {
            _consoleIOManager.OutputTextToConsole(promptTextForContentEntry);
            return _consoleIOManager.ReadConsoleTextEntry();
        }
    }
}
