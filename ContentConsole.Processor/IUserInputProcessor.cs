using System;
using System.Collections.Generic;

namespace ContentConsole.Processor
{
    public interface IUserInputProcessor
    {
        Content ProcessUserInput(string input);
        Content GetUserInput(string userInput);
        Content AnalyseNegativeWords(Content content);
        List<string> GetBannedWords();
    }
}
