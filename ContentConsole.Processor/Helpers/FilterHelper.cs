using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ContentConsole.Processor
{
    public static class FilterHelper
    {

        public static string FilterOutString(string input, string filter, List<string> bannedwords)
        {

            List<string> filteredInput = new List<string>();
            input = Regex.Replace(input, @"[^\w\s]", "");
            string[] wordArr = input.Split(" ");

            foreach (var word in wordArr)
            {
                if (bannedwords.Contains(word.ToLower()))
                {
                    var firstChar = word[0];
                    var lastChar = word[word.Length - 1];
                    var filteredOutString = String.Concat(Enumerable.Repeat(filter, word.Length - 2));

                    var value = $"{firstChar}{filteredOutString}{lastChar}";
                    filteredInput.Add(value);
                }
                else
                {
                    filteredInput.Add(word);
                }
            }
            return string.Join(" ", filteredInput); ;
        }
    }
}
