using System.Collections.Generic;
using NUnit.Framework;

namespace ContentConsole.Test.Unit
{
    [TestFixture]
    class ContentConsoleTestscs
    {
        [TestCase("The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.", 2)]
        [TestCase("The weather in Manchester in winter is bad. It doesnt rains all the time - it must be bad for people visiting.", 2)]
        [TestCase("The weather in Manchester in winter is good. It doesnt rains all the time - it must be wonderful for people visiting.", 0)]
        public void CountNegativeContent_BadWordCount_ValuesAreEqual(string content, int iExpectedResult = 2)
        {
            List<string> lBadWords = new List<string>() { "bad", "horrible" };
            int result = Program.CountNegativeContent(content, lBadWords);
            Assert.AreEqual(result, iExpectedResult);
        }

        [Test]
        public void IsUser_UserIsUser_ReturnsTrue()
        {
            var result = Program.IsUser(new User() { IsUser = true });
            Assert.IsTrue(result);
        }
    }
}
