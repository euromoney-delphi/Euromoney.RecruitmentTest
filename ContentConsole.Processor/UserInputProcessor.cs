using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using ContentConsole.Model;

namespace ContentConsole.Processor
{
    public class UserInputProcessor : IUserInputProcessor
    {

        public Content GetUserInput(string userInput)
        {
            var content = new Content();
            content.InputUnformatted = userInput;
            content.InputFormatted = Regex.Replace(userInput, @"[^\w\s]", "");
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

                List<string> bannedWords = GetBannedWords();
                var inputToArray = content.InputFormatted.Split(' ');
                List<string> inputToList = new List<string>(inputToArray);

                content.BadWordsCount = inputToList.Where(x => bannedWords.Contains(x)).Distinct().Count();
                content.BadWords = inputToList.Where(x => bannedWords.Contains(x)).Distinct().ToList();

                return content;
            }
        }



        public List<string> GetBannedWords()
        {
            return new List<string> { "swine", "bad", "nasty", "horrible" };
        }
    }
}
