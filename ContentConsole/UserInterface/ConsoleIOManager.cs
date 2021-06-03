using Application.Interfaces;
using System;

namespace KinderConsole
{
    public class ConsoleIOManager : IConsoleIOManager
    {
        public void OutputTextToConsole(string textToOutput)
        {
            Console.WriteLine(textToOutput);
        }

        public string ReadConsoleTextEntry()
        {
            return Console.ReadLine();
        }
    }
}
