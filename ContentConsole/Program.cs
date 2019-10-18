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

            var badWordsRepository = new FilterWordsRepository();
            var textAnalysisService = new TextFilterService(new FilterWordsProvider(badWordsRepository.LoadBadWordsFromRepo(ConfigSettings.FilterBadWordsRepoFilePath)));
            var result = textAnalysisService.AnalyseText(content);


            Console.WriteLine(args.Length == 0 || args[0].ToLower() != "-disablefilter" ? result.FilteredContent : content);

            Console.WriteLine("Total Number of negative words: " + result.NumberOfFilteredWordsFound);

            Console.WriteLine("Press ANY key to exit.");
            Console.ReadKey();
        }
    }
}
