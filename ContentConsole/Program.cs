using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using ContentConsole.Processor;

namespace ContentConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Content content;
            var userInputProcessor = new UserInputProcessor();

            var input = Console.ReadLine();
            content = userInputProcessor.ProcessUserInput(input);
            Console.WriteLine($"Scanned the text:");
            Console.WriteLine($"{content.InputUnformatted}");
            Console.WriteLine($"Total Number of negative words: {content.BadWordsCount}" );

            Console.WriteLine("Press ANY key to exit.");
            Console.ReadKey();
        }
    }
}
