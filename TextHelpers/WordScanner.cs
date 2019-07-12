using ContentConsole.Data;
using System;
using System.Linq;

namespace ContentConsole
{
    public class WordScanner : IWordScanner
    {
        private readonly IBannedWordsRepository _bannedWordsRepository;

        public WordScanner(IBannedWordsRepository repository) => _bannedWordsRepository = repository;

        public int CountBannedWords(string text)
        {
            var bannedWords = _bannedWordsRepository.Get();

            return text.ToUpperInvariant()
                .Split(' ')
                .Count(word => bannedWords.Any(banned => string.Equals(word, banned, StringComparison.OrdinalIgnoreCase)));
        }
    }
}
