using System;
using System.Linq;
using ContentConsole.Libraries;
using ContentConsole.Models;

namespace ContentConsole
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var badWordLibrary = InitializeBadWordsLibrary();
            

            const string content = "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";

            var contentList = content.ToLower().Split(' ').ToList();

            var count = badWordLibrary.BadWords.Select(
                        word => contentList.Where(x => x.Contains(word.Value.ToLower())))
                        .Select(res => res.Count())
                        .Sum();

            Console.WriteLine("Scanned the text:");
            Console.WriteLine(content);
            Console.WriteLine("Total Number of negative words: " + count);

            Console.WriteLine("Press ANY key to exit.");
            Console.ReadKey();
        }

        private static BadWordLibrary InitializeBadWordsLibrary()
        {
            var badWordLibrary = new BadWordLibrary();
            badWordLibrary.BadWords.Add(new BadWord {Value = "swine"});
            badWordLibrary.BadWords.Add(new BadWord {Value = "bad"});
            badWordLibrary.BadWords.Add(new BadWord {Value = "nasty"});
            badWordLibrary.BadWords.Add(new BadWord {Value = "horrible"});
            return badWordLibrary;
        }
    }
}
