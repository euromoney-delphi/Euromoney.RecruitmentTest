using ContentConsole.Models;
using NUnit.Framework;

namespace ContentConsole.Test.Unit.Models
{
    [TestFixture]
    public class BadWordFixture
    {
        [Test]
        public void WordPropertyToReturnBad()
        {
            const string expectedWord = "Bad";

            var badWord = new BadWord {Value = "Bad"};

            Assert.AreEqual(expectedWord, badWord.Value);
        }
    }
}
