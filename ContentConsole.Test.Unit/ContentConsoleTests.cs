using System;
using System.Collections.Generic;
using System.Linq;
using ContentConsole;
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
        [TestCase(
            "The weather in Manchester in winter is good. It doesnt rain all the time - it must be horrible for people visiting.",
            "The weather in Manchester in winter is good. It doesnt rain all the time - it must be horrible for people visiting.", true)]
        public void FilterNegativeWords_HashesOutBadWords_ValuesAreEqual(string content, string expectedresult, bool bDisableFilter = false)
        {
            List<string> badWords = new List<string>() { "bad", "horrible" };
            var result = Program.FilterNegativeWords(content, badWords, bDisableFilter);
            Assert.AreEqual(result, expectedresult);
        }

        [Test]
        public void IsContentCreator_UserIsContentCreator_ReturnsTrue()
        {
            var result = Program.IsContentCurator(new User() { IsContentCurator = true });
            Assert.IsTrue(result);
        }
    }
}
