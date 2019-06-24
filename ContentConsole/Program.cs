using System;
using System.Linq;

namespace ContentConsole
{
    public static class Program
    {
        public static void Main(string[] args)
        {


            string content =
                "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";

            DataStore dtStore = new DataStore();

            if (args.Count() > 0)
            {
                switch (args[0])
                {
                    case "setBannedWords":
                        dtStore.BannedWords = args[1].Split(',').ToList();
                        ShowResult(content, dtStore, true);
                        break;

                    case "unfiltered":
                        ShowResult(content, dtStore, false);
                        break;

                    case "filtered":
                        ShowResult(content, dtStore, true);
                        break;

                    case "/help":
                    case "/?":
                        DisplayHelp();
                        break;
                }
            }
            else
            {
                DisplayHelp();
            }

            Console.WriteLine("Press ANY key to exit.");
            Console.ReadKey();
        }

        private static void ShowResult(string content, DataStore dtStore, bool filtered)
        {
            ContentFilter contentFilter = new ContentFilter(dtStore.BannedWords); ;
            if (filtered)
            {
                string filteredContent = contentFilter.FilterContent(content);
                Console.WriteLine(filteredContent);
            }
            else
            {
                Console.WriteLine(content);
            }

            int badWordsCount = contentFilter.GetBadWordsCount(content);
            Console.WriteLine("Total Number of negative words: " + badWordsCount);
        }

        public static void DisplayHelp()
        {
            Console.WriteLine("");
            Console.WriteLine("Content Filter");
            Console.WriteLine("----------------------------");
            Console.WriteLine("");
            Console.WriteLine("Use below arguments:");
            Console.WriteLine("  setBannedWords : resets the banned word list. Please enter comma seperated list of words in quotes");
            Console.WriteLine("  filtered : resets the filtered content");
            Console.WriteLine("  unfiltered : Shows the unfiltered text, with the word count");
            Console.WriteLine("");
        }

    }

}
