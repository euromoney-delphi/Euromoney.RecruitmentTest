using ContentConsole.Data;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace ContentConsole.Test.Unit
{
    [TestFixture("Foo Bar Fizz Buzz", new[] { "Foo", "Fizz" }, 2, "F#o Bar F##z Buzz")]
    [TestFixture("Foo Bar Fizz Buzz", new[] { "Buzz", "Bar" }, 2, "Foo B#r Fizz B##z")]
    [TestFixture("Foo Bar Fizz Buzz", new[] { "foo", "fizz", "buzz", "BAr" }, 4, "F#o B#r F##z B##z")]
    public class WordScannerTests
    {
        private readonly string _text;
        private readonly IEnumerable<string> _bannedWords;
        private readonly int _expected;
        private readonly string _expectedOutput;

        public WordScannerTests(string text, IEnumerable<string> bannedWords, int expected, string expectedOutput)
        {
            _text = text;
            _bannedWords = bannedWords;
            _expected = expected;
            _expectedOutput = expectedOutput;
        }

        private IBannedWordsRepository MockRepository()
        {
            var repoMock = new Mock<IBannedWordsRepository>();
            repoMock.Setup(x => x.Get()).Returns(_bannedWords.ToList().AsReadOnly());
            return repoMock.Object;
        }

        private IPunctuationStripper MockTextStripper()
        {
            var repoMock = new Mock<IPunctuationStripper>();
            repoMock.Setup(x => x.StripPunctuation(It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<IEnumerable<char>>())).Returns(_text);
            return repoMock.Object;
        }

        [Test]
        public void TestCountBannedWords()
        {
            var scanner = new WordScanner(MockRepository(), MockTextStripper());
            Assert.AreEqual(_expected, scanner.CountBannedWords(_text));
        }

        [Test]
        public void TestFilterBannedWords()
        {
            var scanner = new WordScanner(MockRepository(), MockTextStripper());
            Assert.AreEqual(_expected, scanner.FilterBannedWords(_text, true, out var filteredText));
            Assert.AreEqual(_expectedOutput, filteredText);
        }

        [Test]
        public void TestDontFilterBannedWords()
        {
            var scanner = new WordScanner(MockRepository(), MockTextStripper());
            Assert.AreEqual(_expected, scanner.FilterBannedWords(_text, false, out var filteredText));
            Assert.AreEqual(_text, filteredText);
        }
    }
}
