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
    }
}
