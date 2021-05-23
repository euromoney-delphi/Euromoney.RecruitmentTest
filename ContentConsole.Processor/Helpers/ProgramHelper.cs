using System;
using ContentConsole.Service;

namespace ContentConsole.Processor
{
    public static class ProgramHelper
    {
        public static void RunContentCuratorPath(IUserInputProcessor userInputProcessor)
        {
            Console.WriteLine($"Would you like to display filtered output? Type Y for yes or N for no.");
            var filter = Console.ReadLine();

            switch (filter.ToUpper())
            {
                case "Y":
                    {
                        GetUserInputWithFilter(userInputProcessor);
                        break;
                    }

                case "N":
                    {
                        GetUserInputWithoutFilter(userInputProcessor);
                        break;
                    }
                default:
                    break;
            }
        }

        public static void RunAdminPath(INegativeWordsApiService apiService, IUserInputProcessor userInputProcessor)
        {

            Console.WriteLine($"Please select action - R - to read current negative word, A to add new negative words or D to remove existing negative word.");
            var action = Console.ReadLine();

            switch (action.ToUpper())
            {
                case "A":
                    {
                        Console.WriteLine($"Please type in new word.");
                        var newWord = Console.ReadLine();
                        apiService.AddNegativeWords(newWord.ToLower());

                        Console.WriteLine($"Current words library: ");
                        var words = apiService.GetNegativeWordsAsync();
                        words.ForEach(x => Console.WriteLine($"{x}"));

                        break;
                    }
                case "D":
                    {
                        var currentWords = apiService.GetNegativeWordsAsync();
                        Console.WriteLine($"You can remove words from below list of {currentWords.Count}: ");
                        currentWords.ForEach(x => Console.WriteLine($"{x}"));

                        Console.WriteLine($"Please type word to remove.");
                        var word = Console.ReadLine();
                        apiService.RemoveNegativeWords(word.ToLower());

                        var words = apiService.GetNegativeWordsAsync();
                        Console.WriteLine($"Current words library cointains {words.Count} words: ");
                        words.ForEach(x => Console.WriteLine($"{x}"));
                        break;
                    }
                case "R":
                    {
                        var words = apiService.GetNegativeWordsAsync();
                        words.ForEach(x => Console.WriteLine($"{x}"));
                        break;
                    }
                default:
                    break;
            }

            GetUserInputWithoutFilter(userInputProcessor);

        }


        public static void GetUserInputWithFilter(IUserInputProcessor userInputProcessor)
        {
            Console.WriteLine($"Input text to scan:");

            var input = Console.ReadLine();
            var content = userInputProcessor.ProcessUserInput(input);
            Console.WriteLine($"Scanned the text:");
            Console.WriteLine($"{content.InputFiltered}");
            Console.WriteLine($"Total Number of negative words: {content.BadWordsCount}");

            Console.WriteLine("Press ANY key to exit.");
            Console.ReadKey();
        }

        public static void GetUserInputWithoutFilter(IUserInputProcessor userInputProcessor)
        {
            Console.WriteLine($"Input text to scan:");

            var input = Console.ReadLine();
            var content = userInputProcessor.ProcessUserInput(input);
            Console.WriteLine($"Scanned the text:");
            Console.WriteLine($"{content.InputFormatted}");
            Console.WriteLine($"Total Number of negative words: {content.BadWordsCount}");

            Console.WriteLine("Press ANY key to exit.");
            Console.ReadKey();
        }
    }
}
