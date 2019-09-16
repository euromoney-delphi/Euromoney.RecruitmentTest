using System;
using System.Collections.Generic;

namespace ContentConsole
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            List<string> bannedWords = new List<string>();
            bannedWords.Add("swine");
            bannedWords.Add("bad");
            bannedWords.Add("nasty");
            bannedWords.Add("horrible");

            string content =
                "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";

            Console.WriteLine("Enable negative word filtering? y/n");
            string key = Console.ReadLine();

            Console.WriteLine("Scanned the text");

            if (key == "y")
            {
                Console.WriteLine("Fixed string: " + BannedTextHandler.WordFilter(bannedWords, content));
            }
            else Console.WriteLine(content);

            Console.WriteLine("Total Number of negative words: " + BannedTextHandler.WordCount(bannedWords, content));

            Console.WriteLine("Press ANY key to exit.");
            Console.ReadKey();
        }
    }

}
