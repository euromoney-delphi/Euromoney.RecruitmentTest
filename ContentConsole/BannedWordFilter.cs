using System;
using System.Collections.Generic;
using System.Linq;

namespace ContentConsole
{
    public class BannedWordFilter : IWordFilter
    {
        private readonly IList<string> _bannedWords;

        public BannedWordFilter(IList<string> bannedWords)
        {
            if (bannedWords == null)
            {
                throw new ArgumentNullException(nameof(bannedWords));
            }

            this._bannedWords = bannedWords;
        }

        public bool EnableClean { get; set; }

        public int Scan(string contentToScan)
        {
            if (string.IsNullOrWhiteSpace(contentToScan))
            {
                throw new ArgumentNullException(nameof(contentToScan));
            }

            int count = 0;
            foreach (var bannedWord in this._bannedWords)
            {
                if (contentToScan.Contains(bannedWord))
                {
                    count++;
                }
            }
            return count;
        }

        public string Clean(string contentToClean, char maskChar)
        {
            if (string.IsNullOrWhiteSpace(contentToClean))
            {
                throw new ArgumentNullException(nameof(contentToClean));
            }

            if (!this.EnableClean)
            {
                return contentToClean;
            }

            var cleanContent = contentToClean;
            foreach (var bannedWord in this._bannedWords)
            {
                var cleanWord = this.CleanWord(bannedWord, maskChar);
                cleanContent = cleanContent.Replace(bannedWord, cleanWord);
            }

            return cleanContent;
        }

        private string CleanWord(string bannedWord, char maskChar)
        {
            int midLength = bannedWord.Length - 2;
            var cleanPart = new string(maskChar, midLength);
            var cleanWord = string.Format("{0}{1}{2}", bannedWord[0], cleanPart, bannedWord[bannedWord.Length - 1]);
            return cleanWord;
        }
    }
}