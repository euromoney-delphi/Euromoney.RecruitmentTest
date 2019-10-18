using System;
using ContentConsole.Configuration;
using ContentConsole.DataAccess;
using ContentConsole.Services;

namespace ContentConsole
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            const string content = "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";
            Console.WriteLine("Scanned the text:");
          

            if (args.Length == 0 || args[0].ToLower() != "-disablefilter")
            {
                var badWordsRepository = new FilterWordsRepository();
                var textAnalysisService = new TextFilterService(new FilterWordsProvider(badWordsRepository.LoadBadWordsFromRepo(ConfigSettings.FilterBadWordsRepoFilePath)));
                var result = textAnalysisService.AnalyseText(content);
                Console.WriteLine(result.FilteredContent);
                Console.WriteLine("Total Number of negative words: " + result.NumberOfFilteredWordsFound);
            }
            else
            {
                Console.WriteLine(content);
            }

            Console.WriteLine("Press ANY key to exit.");
            Console.ReadKey();
        }
    }
}
