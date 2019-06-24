using System;
using System.Collections.Generic;
using System.Linq;

namespace ContentConsole
{
    public class ContentFilter : IContentFilter
    {
        private List<string> _bannedWords;

        public ContentFilter(List<string> bannedWords)
        {
            _bannedWords = bannedWords;
        }

        public int GetBadWordsCount(string content)
        {
            return _bannedWords.Count(w => content.ToLower().Contains(w.ToLower()));
        }

        public string FilterContent(string content)
        {
            string copyContent = content;
            var words = content.Split(' ');
            for (var i = 0; i < words.Length; i++)
            {
                var word = words[i];
                var wordWithoutPuctuation = string.Concat(word.Where(c => !char.IsPunctuation(c)).ToList());

                if (_bannedWords.Contains(wordWithoutPuctuation.ToLower()))
                {
                    string alteredWord = GetReplacementForBannedWord(word);
                    copyContent = copyContent.Replace(word, alteredWord);

                }
            }

            return copyContent;
        }

        private string GetReplacementForBannedWord(string word)
        {
            // before replacing check if word start with punctuation and if word ends with punctuation
            char[] wordArray = word.ToCharArray();
            if (char.IsPunctuation(wordArray[0]) && char.IsPunctuation(wordArray[word.Length - 1])) // start and end with punctuation
            {
               
                return String.Concat(new String[] { word.Substring(0, 2), new String('#', word.Length - 4), word.Substring(word.Length - 2, 2) });
            }
            else if (char.IsPunctuation(wordArray[wordArray.Length - 1])) // only ending with punctuation
            {
                //string only ends with punctuation
                return String.Concat(new String[] { word.Substring(0, 1), new String('#', word.Length - 3), word.Substring(word.Length - 2, 2) });
            }
            else if (char.IsPunctuation(wordArray[0])) // if only start with ounctuation
            {
                return String.Concat(new String[] { word.Substring(0, 2), new String('#', word.Length - 3), word.Substring(word.Length - 1, 1) });
            }
            else
            {
                //no punctuation in word
                return String.Concat(new String[] { word.Substring(0, 1), new String('#', word.Length - 2), word.Substring(word.Length - 1, 1) });
            }
        }
    }
}
