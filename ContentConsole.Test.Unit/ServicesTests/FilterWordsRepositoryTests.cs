using AutoFixture;
using ContentConsole.DataAccess;
using FluentAssertions;
using NUnit.Framework;

namespace ContentConsole.Test.Unit.ServicesTests
{
    [TestFixture]
    public class FilterWordsRepositoryTests
    {
        private readonly FilterWordsRepository _classUnderTest;
        public FilterWordsRepositoryTests()
        {
            var fixture = new Fixture();
            _classUnderTest = fixture.Create<FilterWordsRepository>();
        }

        [Test]
        [TestCase(@"TestData\BadWordsRepoOneWord.json", new[] { "swine" })]
        [TestCase(@"TestData\BadWordsRepoMultipleWords.json", new[] { "swine", "bad", "nasty", "horrible" })]
        public void LoadBadWordsFromRepo_Should_ReturnListOfBadWords(string pathToRepo, string[] expectedValues)
        {
            _classUnderTest.LoadBadWordsFromRepo(pathToRepo).Should().BeEquivalentTo(expectedValues);
        }
    }
}
