using System;
using System.Collections.Generic;
using ContentConsole.Model;
using ContentConsole.Processor;
using ContentConsole.Service;

namespace ContentConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Content content;
            var apiService = new NegativeWordsApiService();
            var userInputProcessor = new UserInputProcessor(apiService);

            Console.WriteLine($"Please select your role. Type A for Admin Role or U for user:");

            var role = Console.ReadLine();
            if (role == Constants.ADMIN_ROLE)
            {
                RunAdminPath(apiService, userInputProcessor);
                return;
            }

            GetUserInput(userInputProcessor);
        }

        private static void RunAdminPath(NegativeWordsApiService apiService, UserInputProcessor userInputProcessor)
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
                        Console.WriteLine($"Please type word to remove.");
                        var word = Console.ReadLine();
                        apiService.RemoveNegativeWords(word.ToLower());

                        Console.WriteLine($"Current words library: ");
                        var words = apiService.GetNegativeWordsAsync();
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

            GetUserInput(userInputProcessor);

        }

        private static void GetUserInput(UserInputProcessor userInputProcessor)
        {
            Console.WriteLine($"Input text to scan:");

            var input = Console.ReadLine();
            var content = userInputProcessor.GetUserInput(input);
            Console.WriteLine($"Scanned the text:");
            Console.WriteLine($"{content.InputFiltered}");
            Console.WriteLine($"Total Number of negative words: {content.BadWordsCount}");

            Console.WriteLine("Press ANY key to exit.");
            Console.ReadKey();
        }
    }
}

