using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ContentConsole
{
    public class TextCleanser
    {
        private readonly List<string> disallowedWords;

        public TextCleanser(List<string> disallowedWords)
        {
            this.disallowedWords = disallowedWords;
        }

        /// <summary>
        /// Count the number of disallowed words in the text.
        /// </summary>
        /// <param name="text">Text top clean.</param>
        /// <returns>Number of disallowed words.</returns>
        public int CountDisallowedWords(string text)
        {
            var count = 0;

            // Remove puntuation.
            var newText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());

            foreach (var word in disallowedWords)
            {
                if (newText.StartsWith(word + " ", StringComparison.OrdinalIgnoreCase)) count++;
                if (newText.EndsWith(" " + word, StringComparison.OrdinalIgnoreCase)) count++;
                count += Regex.Matches(newText, " " + word + " ", RegexOptions.IgnoreCase).Count;
            }

            return count;
        }

        /// <summary>
        /// Redact disallowed words in the text, leaving the first and last letters.
        /// </summary>
        /// <param name="text">Text to redact.</param>
        /// <returns>Redacted text.</returns>
        public string RedactDisallowedWords(string text)
        {
            var words = text.Split(' ');

            for (var i = 0; i < words.Length; i++)
            {
                var word = words[i];
                var hasPunctuation = false;

                // Remove puntuation.
                var tempWord = "";
                var strippedWord = new string(word.Where(c => !char.IsPunctuation(c)).ToArray());

                if (string.IsNullOrWhiteSpace(strippedWord))
                    continue;

                if (word != strippedWord)
                {
                    hasPunctuation = true;
                    tempWord = word.Replace(strippedWord, "{{xxx}}");
                    word = strippedWord;
                }

                if (!disallowedWords.Contains(word.ToLower()))
                    continue;

                var redacted = RedactWord(word);
                if (hasPunctuation)
                    words[i] = tempWord.Replace("{{xxx}}", redacted); // Add the original punctuation.
                else
                    words[i] = redacted;
            }

            return string.Join(" ", words);
        }

        /// <summary>
        /// Redact a single word, leaving first and last letters.
        /// </summary>
        /// <param name="word">Word to redact</param>
        /// <returns>Redacted word</returns>
        private string RedactWord(string word)
        {
            var length = word.Length - 2;
            var replace = word.Substring(1, length);
            return word.Replace(replace, new string('#', length));
        }
    }
}
