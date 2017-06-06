using NUnit.Framework;
using System.Collections.Generic;

namespace ContentConsole.Test.Unit
{
    [TestFixture]
    public class TextCleanser
    {

        #region Text Cleansing

        [TestCase("swine|bad|nasty|horrible", "This has a bad word", Result = 1, Description = "Can find a single bad word")]
        [TestCase("swine|bad|nasty|horrible", "This is a nasty horrible sentence", Result = 2, Description = "Can find multiple bad words")]
        public int Cleanser_Counts_Words(string words, string textToClean)
        {

            // Arrange.
            var badWords = GetDisallowedWords(words);

            // Act.
            var cleanser = new ContentConsole.TextCleanser(badWords);
            var count = cleanser.CountDisallowedWords(textToClean);

            // Assert.
            return count;

        }

        [TestCase("swine|bad|nasty|horrible", "This has a Horrible word", Result = 1, Description = "Can find a bad starting with a capital")]
        [TestCase("swine|bad|nasty|horrible", "This is a BAD word", Result = 1, Description = "Can find a bad all uppercase")]
        public int Cleanser_Counts_Words_Case_Insensitive(string words, string textToClean)
        {

            // Arrange.
            var badWords = GetDisallowedWords(words);

            // Act.
            var cleanser = new ContentConsole.TextCleanser(badWords);
            var count = cleanser.CountDisallowedWords(textToClean);

            // Assert.
            return count;

        }

        [TestCase("swine|bad|nasty|horrible", "Swine is not a nice word", Result = 1, Description = "Can find a word at the start")]
        [TestCase("swine|bad|nasty|horrible", "The weather is horrible", Result = 1, Description = "Can find a word at the end")]
        public int Cleanser_Counts_Words_Start_And_End(string words, string textToClean)
        {

            // Arrange.
            var badWords = GetDisallowedWords(words);

            // Act.
            var cleanser = new ContentConsole.TextCleanser(badWords);
            var count = cleanser.CountDisallowedWords(textToClean);

            // Assert.
            return count;

        }

        [TestCase("swine|bad|nasty|horrible", "This is a 'horrible' place", Result = 1, Description = "Can find a  word with punctuation on both sides")]
        [TestCase("swine|bad|nasty|horrible", "The weather can be horrible, but it should get better", Result = 1, Description = "Can find a word with puncuation at the end")]
        [TestCase("swine|bad|nasty|horrible", "The weather can be -horrible, but I like it", Result = 1, Description = "Can find a word with puncuation at the start")]
        public int Cleanser_Counts_Words_Ignoring_Punctuation(string words, string textToClean)
        {

            // Arrange.
            var badWords = GetDisallowedWords(words);

            // Act.
            var cleanser = new ContentConsole.TextCleanser(badWords);
            var count = cleanser.CountDisallowedWords(textToClean);

            // Assert.
            return count;

        }

        [TestCase("swine|bad|nasty|horrible", "My name is Sinbad", Result = 0, Description = "Does not count a word that ends with a disallowed word")]
        [TestCase("swine|bad|nasty|horrible", "He bade him farewell", Result = 0, Description = "Does not count a word that starts with a disallowed word")]
        [TestCase("swine|bad|nasty|horrible", "He was a troubadour in France", Result = 0, Description = "Does not count a word that contains a disallowed word")]
        public int Cleanser_Does_Not_Count_Word_If_Part_Of_Another_Word(string words, string textToClean)
        {

            // Arrange.
            var badWords = GetDisallowedWords(words);

            // Act.
            var cleanser = new ContentConsole.TextCleanser(badWords);
            var count = cleanser.CountDisallowedWords(textToClean);

            // Assert.
            return count;

        }

        #endregion

        #region Text Redaction

        [TestCase("swine|bad|nasty|horrible", "This has a bad word", Result = "This has a b#d word", Description = "Can redact a single word")]
        [TestCase("swine|bad|nasty|horrible", "This is a nasty horrible sentence", Result = "This is a n###y h######e sentence", Description = "Can redact multiple words")]
        public string Cleanser_Redacts_Words(string words, string textToClean)
        {

            // Arrange.
            var badWords = GetDisallowedWords(words);

            // Act.
            var cleanser = new ContentConsole.TextCleanser(badWords);
            var cleaned = cleanser.RedactDisallowedWords(textToClean);

            // Assert.
            return cleaned;

        }


        [TestCase("swine|bad|nasty|horrible", "This has a Horrible word", Result = "This has a H######e word", Description = "Can redact a word starting with a capital")]
        [TestCase("swine|bad|nasty|horrible", "This is a BAD word", Result = "This is a B#D word", Description = "Can redact a word all uppercase")]
        public string Cleanser_Redacts_Words_Case_Insensitive(string words, string textToClean)
        {

            // Arrange.
            var badWords = GetDisallowedWords(words);

            // Act.
            var cleanser = new ContentConsole.TextCleanser(badWords);
            var cleaned = cleanser.RedactDisallowedWords(textToClean);

            // Assert.
            return cleaned;

        }

        [TestCase("swine|bad|nasty|horrible", "Swine is not a nice word", Result = "S###e is not a nice word", Description = "Can redact a word at the start")]
        [TestCase("swine|bad|nasty|horrible", "The weather is horrible", Result = "The weather is h######e", Description = "Can redact a word at the end")]
        public string Cleanser_Redacts_Words_Start_And_End(string words, string textToClean)
        {

            // Arrange.
            var badWords = GetDisallowedWords(words);

            // Act.
            var cleanser = new ContentConsole.TextCleanser(badWords);
            var cleaned = cleanser.RedactDisallowedWords(textToClean);

            // Assert.
            return cleaned;

        }

        [TestCase("swine|bad|nasty|horrible", "This is a 'horrible' place", Result = "This is a 'h######e' place", Description = "Can redact a word with punctuation on both sides")]
        [TestCase("swine|bad|nasty|horrible", "The weather can be horrible, but it should get better", Result = "The weather can be h######e, but it should get better", Description = "Can redact a word with puncuation at the end")]
        [TestCase("swine|bad|nasty|horrible", "The weather can be -horrible, but I like it", Result = "The weather can be -h######e, but I like it", Description = "Can redact a word with puncuation at the start")]
        public string Cleanser_Redacts_Words_Ignoring_Punctuation(string words, string textToClean)
        {

            // Arrange.
            var badWords = GetDisallowedWords(words);

            // Act.
            var cleanser = new ContentConsole.TextCleanser(badWords);
            var cleaned = cleanser.RedactDisallowedWords(textToClean);

            // Assert.
            return cleaned;

        }

        [TestCase("swine|bad|nasty|horrible", "My name is Sinbad", Result = "My name is Sinbad", Description = "Does not redact a word that ends with a disallowed word")]
        [TestCase("swine|bad|nasty|horrible", "He bade him farewell", Result = "He bade him farewell", Description = "Does not redact a word that starts with a disallowed word")]
        [TestCase("swine|bad|nasty|horrible", "He was a troubadour in France", Result = "He was a troubadour in France", Description = "Does not redact a word that contains a disallowed word")]
        public string Cleanser_Does_Not_Redact_Word_If_Part_Of_Another_Word(string words, string textToClean)
        {

            // Arrange.
            var badWords = GetDisallowedWords(words);

            // Act.
            var cleanser = new ContentConsole.TextCleanser(badWords);
            var cleaned = cleanser.RedactDisallowedWords(textToClean);

            // Assert.
            return cleaned;
        }

        #endregion

        /// <summary>
        /// Turn string of words into a list
        /// </summary>
        /// <param name="words">Words separated by a | character.</param>
        /// <returns>List of words.</returns>
        private List<string> GetDisallowedWords(string words)
        {
            var disallowedWords = new List<string>();

            foreach (var word in words.Split('|'))
            {
                if (string.IsNullOrWhiteSpace(word))
                    continue;
                disallowedWords.Add(word);
            }

            return disallowedWords;
        }

    }
}
