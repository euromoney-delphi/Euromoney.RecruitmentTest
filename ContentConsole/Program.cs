using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace ContentConsole
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            List<string> badWords = new List<string>()
            {
                "swine", "bad", "nasty", "horrible"
            };

            string content =
                "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";

            int badWordCount = WordAnalizer.CountBadWords(content, badWords);

            Console.WriteLine("Scanned the text:");
            Console.WriteLine(content);
            Console.WriteLine($"Total Number of negative words: {badWordCount}");

            Console.WriteLine("Press ANY key to exit.");
            Console.ReadKey();
        }

        
    }

}
