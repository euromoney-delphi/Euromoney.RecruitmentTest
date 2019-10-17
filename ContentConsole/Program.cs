using EuroMoney.Core.Text;
using EuroMoney.Data;
using EuroMoney.Service;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace ContentConsole
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            // Note: This should be read from the configuration not done due to time constraint
            bool isFilteringEnabled = true;

            // Note : This should be done using DI Container
            ITextParser textParser = new TextParser();
            ITextRepository textRepository = new TextRepository();
            ITextService textService = new TextService(textParser, textRepository);

            string choice;

            do
            {
                Console.WriteLine("1. Text Analyser Mode");
                Console.WriteLine("2. Admin Mode");
                Console.WriteLine("3. Content Curator Mode");
                Console.WriteLine("0. To Exit Menue ");

                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": 
                        HandleUserMode(isFilteringEnabled, textService);
                        break;
                    case "2": 
                        HandleAdminMode(textRepository);
                        break;
                    case "3": 
                        isFilteringEnabled = HandleContentCuratorMode();
                        break;
                }

            } while (choice != "0");           

            Console.WriteLine("Press ANY key to exit.");
            Console.ReadKey();
        }

        private static bool HandleContentCuratorMode()
        {
            bool isFilteringEnabled;
            Console.WriteLine("Content Curator Mode ***************");
            Console.WriteLine("Press 1 to disable or press 0 to enable negative fitlering ");
            string filtering = Console.ReadLine();
            isFilteringEnabled = (filtering == "1") ? false : true;
            return isFilteringEnabled;
        }

        private static void HandleAdminMode(ITextRepository textRepository)
        {
            Console.WriteLine("Admin Mode ***************");
            Console.WriteLine("Please Specify the banned words(comma seperated like word1,word2");
            string bannedWords = Console.ReadLine();           
            var result = textRepository.SaveBannedWords(bannedWords.Split(',').ToList());
        }

        private static void HandleUserMode(bool isFilteringEnabled, ITextService textService)
        {
            Console.WriteLine("Text Analyser Mode ***************");
            Console.WriteLine("Please Specify the text which you want to analysed");
            string content = Console.ReadLine();

            var serviceResult = textService.FilterBannedWords(content, isFilteringEnabled);
            Console.WriteLine("Scanned the text:");
            Console.WriteLine(serviceResult.DisplayText);
            Console.WriteLine("Total Number of negative words: " + serviceResult.BadWordsCount);
        }
    }

}
