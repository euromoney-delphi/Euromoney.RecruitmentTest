using System;
using System.Collections.Generic;
using System.Linq;

namespace ContentConsole
{
    /// <summary>
    /// This is a fake
    /// </summary>
    public class DisallowedWordRepo
    {

        private readonly List<string> _disallowedWords;

        public DisallowedWordRepo()
        {
            _disallowedWords = new List<string> { "swine", "bad", "nasty", "horrible" };
        }

        public List<string> GetDisallowedWords()
        {
            return _disallowedWords;
        }

        /// <summary>
        /// Add a new word if not in the list.
        /// </summary>
        /// <param name="newWord">New word to add</param>
        /// <returns>True if added, otherwise false</returns>
        public bool AddDisallowedWord(string newWord)
        {
            if (_disallowedWords.Any(s => s.Equals(newWord, StringComparison.OrdinalIgnoreCase)))
                return false;

            _disallowedWords.Add(newWord.ToLower());

            return true;
        }

        /// <summary>
        /// Remove a word if it exists in the list.
        /// </summary>
        /// <param name="word">Remove a word to remove</param>
        /// <returns>True if removed, otherwise false</returns>
        public bool RemoveDisallowedWord(string word)
        {
            var item = _disallowedWords.FirstOrDefault(s => s.Equals(word, StringComparison.OrdinalIgnoreCase));

            if (item == null)
                return false;

            _disallowedWords.Remove(item);

            return true;

        }
    }
}
