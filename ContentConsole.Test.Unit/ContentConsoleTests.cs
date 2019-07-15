using System.Collections.Generic;
using NUnit.Framework;

namespace ContentConsole.Test.Unit
{
    [TestFixture]
    class ContentConsoleTests
    {
        [TestCase(
            "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.",
            "The weather in Manchester in winter is b#d. It rains all the time - it must be h######e for people visiting.")]
        [TestCase(
            "The weather in Manchester in winter is good. It doesnt rain all the time - it must be horrible for people visiting.",
            "The weather in Manchester in winter is good. It doesnt rain all the time - it must be h######e for people visiting.")]
        [TestCase(
            "The weather in Manchester in winter is good. It doesnt rain all the time - it must be wonderful for people visiting.",
            "The weather in Manchester in winter is good. It doesnt rain all the time - it must be wonderful for people visiting.")]
        public void FilterNegativeWords_HashesOutBadWords_ValuesAreEqual(string content, string expectedresult)
        {
            List<string> badWords = new List<string>() { "bad", "horrible" };
            var result = Program.FilterNegativeWords(content, badWords);
            Assert.AreEqual(result, expectedresult);
        }

        [Test]
        public void IsReader_UserIsReader_ReturnsTrue()
        {
            var result = Program.IsReader(new User() { IsReader = true });
            Assert.IsTrue(result);
        }
    }
}
