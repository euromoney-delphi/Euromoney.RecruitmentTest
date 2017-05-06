using System;
using System.Collections.Generic;
using ContentConsole.Repository;
using Moq;
using NUnit.Framework;

namespace ContentConsole.Test.Unit.BannedWordFilterTests
{
    [TestFixture]
    public class when_scan_for_bad_words
    {
        [Test]
        public void should_result_in_two_bad_words()
        {
            var bannedWords = ExecuteTest(Mother.DefaultBadWords, Mother.DefaultContent);
            Assert.AreEqual(2, bannedWords);
        }

        [Test]
        public void should_result_in_three_bad_words()
        {
            var bannedWords = ExecuteTest(Mother.DefaultBadWords, Mother.AlternativeContent);
            Assert.AreEqual(3, bannedWords);
        }

        [Test]
        public void with_alternative_banned_words_should_result_in_zero_bad_words()
        {
            var bannedWords = ExecuteTest(Mother.AlternativeBadWords, Mother.DefaultContent);
            Assert.AreEqual(0, bannedWords);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void should_throw_argument_null_exception_when_content_is_null()
        {
            ExecuteTest(Mother.DefaultBadWords, null);
        }

        private int ExecuteTest(Func<IList<string>> valueFunction, string contentToScan)
        {
            Mock<BannedWordRepository> mock = new Mock<BannedWordRepository>();
            mock.Setup(x => x.GetAll()).Returns(valueFunction);

            var wordFilter = new BannedWordFilter(mock.Object.GetAll());
            return wordFilter.Scan(contentToScan);
        }
    }
}
