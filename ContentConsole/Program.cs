using ContentConsole.Data;
using System;

namespace ContentConsole
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var content = "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";

            // would inject ITextStripper here
            var strippedContent = new TextStripper().StripText(content);

            int badWords = new WordScanner(new BannedWordsRepository()).CountBannedWords(strippedContent);

            Console.WriteLine("Scanned the text:");
            Console.WriteLine(content);
            Console.WriteLine("Total Number of negative words: " + badWords);

            Console.WriteLine("Press ANY key to exit.");
            Console.ReadKey();
        }
    }

}
