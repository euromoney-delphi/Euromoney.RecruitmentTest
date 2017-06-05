using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentConsole.Words
{
    public class WordsFactory:IWordsFactory
    {
        private WordResponse _wordResponse;
        private List<string> _wordsFound;


        public IWordsFactory Init(string phrase)
        {
            if (phrase == null) throw new ArgumentNullException(nameof(phrase));

            _wordResponse = new WordResponse() {Phrase = phrase};
            _wordsFound = new List<string>();
            return this;
        }

        public IWordsFactory WithWordFound(string wordFound)
        {
            if (wordFound == null) throw new ArgumentNullException(nameof(wordFound));

            _wordsFound.Add(wordFound);
            _wordResponse.WordsFound++;

            return this;
        }

        public IWordsFactory WithPretify(char replacement)
        {
            foreach (var word in _wordsFound)
            {
                if (word.Length > 1)
                {
                    _wordResponse.Phrase = _wordResponse.Phrase.Replace(word, string.Format("{0}{1}{2}",
                        word.Substring(0, 1),
                        HideCharacters(replacement, word.Length - 2),
                        word.Substring(word.Length - 1, 1)));
                }
            }

            return this;
        }

        private string HideCharacters(char replacement, int number)
        {
            var hidden = string.Empty;
            for (int i = 0; i < number; i++)
            {
                hidden = string.Concat(hidden, replacement);
            }
            return hidden;
        }

        public WordResponse Create()
        {
            return _wordResponse;
        }
    }
}
