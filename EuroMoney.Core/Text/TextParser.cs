using EuroMoney.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace EuroMoney.Core.Text
{
    public class TextParser : ITextParser
    {
        private const char Hasher = '#';

        public TextResult Filter(string inputData, IList<string> bannedWords)
        {
            if (string.IsNullOrEmpty(inputData))
                return new TextResult { BadWordsCount = 0, OriginalText = inputData };

            if (bannedWords == null || !bannedWords.Any())
                return new TextResult { BadWordsCount = 0, OriginalText = inputData };

            var filteredText = FilterText(inputData, bannedWords);

            return new TextResult { BadWordsCount = filteredText.Item1, BannedWords = bannedWords, OriginalText = inputData, DisplayText = filteredText.Item2 };
        }
       
        public string GetHashedString(string data, char hasher)
        {
            if (string.IsNullOrEmpty(data))
                return data;
            string middle = data.Substring(1, data.Length - 2);
            string middleHashed = new string(hasher, middle.Length);
            string result = data.Substring(0, 1) + middleHashed + data.Substring(data.Length - 1);
            return result;
        }

        private Tuple<int,string> FilterText(string inputData, IList<string> bannedWords)
        {
            int count = 0;
            string convertedText = inputData;
            foreach (var word in bannedWords)
            {
                Regex wordMatcher = new Regex(@"(?<Pre>\s+)(?<Word>" + word + @")(?<Post>\s+|\!\?|\.|\-)", RegexOptions.IgnoreCase);
                var wordMatches = wordMatcher.Matches(inputData);
                foreach (Match match in wordMatches)
                {
                    string pre = match.Groups["Pre"].Value;
                    string post = match.Groups["Post"].Value;
                    string output = pre + GetHashedString(word, Hasher) + post;
                    convertedText = convertedText.Replace(match.Value, output);
                    count++;
                }
            }

            return new Tuple<int, string>(count, convertedText);
        }

    }
}
