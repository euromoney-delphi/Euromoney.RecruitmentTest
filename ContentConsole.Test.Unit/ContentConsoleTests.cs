using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace ContentConsole.Test.Unit
{
    [TestFixture]
    class ContentConsoleTestscs
    {
        [Test]
        public void AddNegativeWordsToRepo_AddsNegativeWordsToRepo_EnsuresWordAreAdded()
        {
            List<string> badWordList = Program.AddNegativeWordsToRepo(new string[] { "rubbish" });
            Assert.That(badWordList.Any(badword => badword == "rubbish"));
        }

        [Test]
        public void RemoveNegativeWordsFromRepo_RemoveNegativeWordsFromRepo_EnsuresWordsAreRemoved()
        {
            List<string> badWordList = Program.RemoveNegativeWordsRepo(new string[] { "swine" });
            Assert.That(!badWordList.Any(badword => badword == "swine"));
        }

        [Test]
        public void IsAdmin_UserIsAdmin_ReturnsTrue()
        {
            var result = Program.IsAdmin(new User() { IsAdmin = true });
            Assert.IsTrue(result);
        }
    }
}
