using System;
using System.Linq;

namespace ContentConsole
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var bannedWords = new[] { "swine", "bad", "nasty", "horrible" };

            var content = "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";

            var strippedContent = new string(content.Where(c => !char.IsPunctuation(c)).ToArray());

            int badWords = strippedContent.Split(' ').Count(x => bannedWords.Contains(x));

            Console.WriteLine("Scanned the text:");
            Console.WriteLine(content);
            Console.WriteLine("Total Number of negative words: " + badWords);

            Console.WriteLine("Press ANY key to exit.");
            Console.ReadKey();
        }
    }

}
