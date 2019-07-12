using ContentConsole.Data;
using System;
using System.Linq;

namespace ContentConsole
{
    public class WordScanner : IWordScanner
    {
        private readonly IBannedWordsRepository _bannedWordsRepository;
        private readonly IPunctuationStripper _textStripper;

        public WordScanner(IBannedWordsRepository repository, IPunctuationStripper textStripper)
        {
            _bannedWordsRepository = repository;
            _textStripper = textStripper;
        }

        public int CountBannedWords(string text)
        {
            var bannedWords = _bannedWordsRepository.Get();

            return _textStripper
                .StripPunctuation(text)
                .Split(' ')
                .Count(word => bannedWords.Any(banned => string.Equals(word, banned, StringComparison.OrdinalIgnoreCase)));
        }

        public int FilterBannedWords(string text, bool filterWords, out string filteredText)
        {
            filteredText = text;

            var bannedWords = _bannedWordsRepository.Get();

            var words = _textStripper.StripPunctuation(text).Split(' ');

            var count = 0;
            foreach (var bannedWord in bannedWords)
            {
                var idx = filteredText.IndexOf(bannedWord, StringComparison.OrdinalIgnoreCase);
                var wordLength = bannedWord.Length;
                while (idx > -1)
                {
                    count++;
                    if (filterWords)
                        filteredText = string.Concat(filteredText.Substring(0, idx + 1), new string('#', wordLength - 2), filteredText.Substring(idx + wordLength - 1));
                    idx = filteredText.IndexOf(bannedWord, idx + wordLength, StringComparison.OrdinalIgnoreCase);
                }
            }

            return count;
        }
    }
}
