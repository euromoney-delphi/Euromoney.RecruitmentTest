using System.Collections.Generic;
using NUnit.Framework;

namespace ContentConsole.Test.Unit
{
    public class ContentFilterTest
    {
        List<string> _bannedWords = new List<string> { "bad", "horrible" };

        [Test]
        [TestCase("The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.", 2,
            Description = "content with 2 banned words with lowercase words")]
        [TestCase("The weather in Manchester in winter is bad. It rains all the time - it must be HORRIBLE for people visiting.", 2,
             Description = "content with 2 banned words with uppercase word")]
        [TestCase("The weather in Manchester in winter is good. It rains all the time - it must be nice for people visiting.", 0,
             Description = "content with no banned words")]
        public void GetBadWordsCount_ReturnsBannedWordsCount(string content, int expectedCount)
        {
            var sut = new ContentFilter(_bannedWords);
            var actual = sut.GetBadWordsCount(content);

            Assert.AreEqual(expectedCount, actual);
        }

        [Test]
        [TestCase("The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.",
            "The weather in Manchester in winter is b#d. It rains all the time - it must be h######e for people visiting.",
            Description = "content with bad word with no punctuation")]
        [TestCase("The weather in Manchester in winter is bad. It rains all the time - it must be 'HORRIBLE' for people visiting.",
            "The weather in Manchester in winter is b#d. It rains all the time - it must be 'H######E' for people visiting.",
            Description = "content with bad word starting and ending with punctuation")]
        [TestCase("The weather in Manchester in winter is bad. It rains all the time - it must be Horrible! for people visiting.",
            "The weather in Manchester in winter is b#d. It rains all the time - it must be H######e! for people visiting.",
            Description = "content with bad word ending with punctuation")]
        [TestCase("The weather in Manchester in winter is bad. It rains all the time - it must be !Horrible for people visiting.",
            "The weather in Manchester in winter is b#d. It rains all the time - it must be !H######e for people visiting.",
            Description = "content with bad word starting with punctuation")]
        public void FilterContent_ReturnsFilteredContent(string content, string expectedFilteredContent)
        {
            var sut = new ContentFilter(_bannedWords);
            var actual = sut.FilterContent(content);

            Assert.AreEqual(expectedFilteredContent, actual);
        }

       
    }
}
