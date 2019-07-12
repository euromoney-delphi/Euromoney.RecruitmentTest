using System;
using System.Collections.Generic;
using System.Linq;

namespace ContentConsole.Data
{
    public class BannedWordsRepository : IBannedWordsRepository
    {
        private readonly List<string> _bannedWords = new List<string> { "swine", "bad", "nasty", "horrible" };
        public IReadOnlyCollection<string> Get() => _bannedWords.AsReadOnly();

        public void Add(params string[] bannedWords)
        {
            foreach (var bannedWord in bannedWords)
            {
                if (string.IsNullOrWhiteSpace(bannedWord))
                    continue;

                var trimmedWord = bannedWord.Trim();

                if (!_bannedWords.Any(word => string.Equals(word, trimmedWord, StringComparison.OrdinalIgnoreCase)))
                    _bannedWords.Add(trimmedWord);
            }
        }
    }
}
