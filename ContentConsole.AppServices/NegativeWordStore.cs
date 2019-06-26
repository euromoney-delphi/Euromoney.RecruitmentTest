using System.Collections.Generic;
using ContentConsole.AppInterfaces;

namespace ContentConsole.AppServices
{
    public class NegativeWordStore : INegativeWordStore
    {
        private readonly List<string> _negativeWords = new List<string> { "swine", "bad", "nasty", "horrible" };

        public IList<string> GetAll()
        {
            return _negativeWords;
        }

        public void Add(string negativeWord)
        {
            _negativeWords.Add(negativeWord);
        }

        public char[] GetSeparators()
        {
            return new[] {' ', ',', '.'};
        }
    }
}