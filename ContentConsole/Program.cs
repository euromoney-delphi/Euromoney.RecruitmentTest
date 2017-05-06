using System;
using ContentConsole.Repository;

namespace ContentConsole
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            string content =
                "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";

            IRepository<string> bannedWordRepository = new BannedWordRepository();
            IWordFilter wordFilter = new BannedWordFilter(bannedWordRepository.GetAll());
            wordFilter.EnableClean = true;

            int badWords = wordFilter.Scan(content);

            Console.WriteLine("Scanned the text:");
            Console.WriteLine(wordFilter.Clean(content, '#'));
            Console.WriteLine(string.Format("Total Number of negative words: {0}", badWords));

            Console.WriteLine("Press ANY key to exit.");
            Console.ReadKey();
        }
    }

}
