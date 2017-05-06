using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContentConsole.Repository;
using Moq;
using NUnit.Framework;

namespace ContentConsole.Test.Unit.BannedWordFilterTests
{
    [TestFixture]
    public class when_filter_banned_words
    {
        [Test]
        public void should_replace_banned_words_with_filter_char()
        {
            var result = this.ExecuteTest(Mother.DefaultBadWords, Mother.DefaultContent);
            Assert.AreEqual(Mother.ExpectedCleanContent, result);
        }

        [Test]
        public void should_not_replace_banned_words_with_filter_char()
        {
            var result = this.ExecuteTest(Mother.DefaultBadWords, Mother.DefaultContent, false);
            Assert.AreEqual(Mother.DefaultContent, result);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void should_throw_argument_null_exception_when_content_is_null()
        {
            this.ExecuteTest(Mother.DefaultBadWords, null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void should_throw_argument_null_exception_when_banned_words_is_null()
        {
            this.ExecuteTest(null, null);
        }

        private string ExecuteTest(Func<IList<string>> valueFunction, string contentToClean, bool enableClean = true)
        {
            Mock<BannedWordRepository> bannedWordRepositoryMock = new Mock<BannedWordRepository>();
            bannedWordRepositoryMock.Setup(x => x.GetAll()).Returns(valueFunction);

            var wordFilter = new BannedWordFilter(bannedWordRepositoryMock.Object.GetAll());
            wordFilter.EnableClean = enableClean;
            return wordFilter.Clean(contentToClean, '#');
        }
    }
}
