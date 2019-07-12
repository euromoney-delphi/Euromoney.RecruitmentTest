using ContentConsole.Data;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentConsole.Test.Unit
{
    [TestFixture("Foo Bar Fizz Buzz", new[] { "Foo", "Fizz" }, 2)]
    [TestFixture("Foo Bar Fizz Buzz", new[] { "Buzz", "Bar" }, 2)]
    [TestFixture("Foo Bar Fizz Buzz", new[] { "foo", "fizz", "buzz", "BAr" }, 4)]
    public class WordScannerTests
    {
        private readonly string _text;
        private readonly IEnumerable<string> _bannedWords;
        private readonly int _expected;

        public WordScannerTests(string text, IEnumerable<string> bannedWords, int expected)
        {
            _text = text;
            _bannedWords = bannedWords;
            _expected = expected;
        }

        private IBannedWordsRepository MockRepository()
        {
            var repoMock = new Mock<IBannedWordsRepository>();
            repoMock.Setup(x => x.Get()).Returns(_bannedWords.ToList().AsReadOnly());
            return repoMock.Object;
        }

        [Test]
        public void TestCountBannedWords()
        {
            var scanner = new WordScanner(MockRepository());
            Assert.AreEqual(_expected, scanner.CountBannedWords(_text));
        }
    }
}
