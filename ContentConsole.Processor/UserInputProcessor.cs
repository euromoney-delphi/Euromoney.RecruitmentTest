using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using ContentConsole.Service;

namespace ContentConsole.Processor
{

    public class UserInputProcessor : IUserInputProcessor
    {
        private readonly INegativeWordsApiService _apiService;

        public UserInputProcessor(INegativeWordsApiService apiService)
        {
            _apiService = apiService;
        }

        public Content GetUserInput(string userInput)
        {
            var content = new Content();
            List<string> bannedWords = _apiService.GetNegativeWordsAsync();
            content.InputUnformatted = userInput;
            content.InputFormatted = Regex.Replace(userInput, @"[^\w\s]", "");
            content.InputFiltered = FilterHelper.FilterOutString(userInput, "#", bannedWords);
            
            return content;
        }


        public Content ProcessUserInput(string input)
        {
            var content = GetUserInput(input);
            AnalyseNegativeWords(content);

            return content;
        }

        public Content AnalyseNegativeWords(Content content)
        {
            if (content.InputFormatted == string.Empty)
            {
                Console.WriteLine("Please enter valid input.");
                throw new Exception("Incorrect input.");
            }
            {

                List<string> bannedWords = _apiService.GetNegativeWordsAsync();
                var inputToArray = content.InputFormatted.Split(' ');
                List<string> inputToList = new List<string>(inputToArray);

                content.BadWordsCount = inputToList.Where(x => bannedWords.Contains(x.ToLower())).Count();
                content.BadWords = inputToList.Where(x => bannedWords.Contains(x.ToLower())).ToList();

                return content;
            }
        }
    }
}
