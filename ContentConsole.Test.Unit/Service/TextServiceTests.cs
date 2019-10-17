using ContentConsole.Test.Unit.Common;
using EuroMoney.Core.Text;
using EuroMoney.Data;
using EuroMoney.Service;
using Moq;
using NUnit.Framework;

namespace ContentConsole.Test.Unit.Service
{
    [TestFixture]
    public class TextServiceTests
    {
        private Mock<ITextRepository> textRepositoryMock;
        bool isFilteringEnabled;
        private ITextService textService;
        private ITextParser textParser;

        [SetUp]
        public void Setup()
        {
            textParser = new TextParser();
            textRepositoryMock = new Mock<ITextRepository>();
            isFilteringEnabled = true;
            
        }

        [Test]
        public void When_BandWord_Filter_Enabled_Then_Filter_Banned_Words()
        {
            //Arrange
            string content = "The weather is bad and it is quite horrible in the dark";
            var banndedWords = WordsHelper.GetBannedWords();
            int expectedBadWordsCount = 2;
            textRepositoryMock.Setup(x => x.GetBannedWords()).Returns(banndedWords);
            textService = new TextService(textParser, textRepositoryMock.Object);
            //Act
            var serviceResult = textService.FilterBannedWords(content, isFilteringEnabled);

            //Assert
            Assert.NotNull(serviceResult);
            Assert.AreEqual(expectedBadWordsCount, serviceResult.BadWordsCount);
            Mock.Get(textRepositoryMock.Object).Verify(x => x.GetBannedWords(), Times.Once);
        }

        [Test]
        public void When_BandWord_Filter_Disableded_Then_dont_Filter_Banned_Words()
        {
            //Arrange
            isFilteringEnabled = false;
            string content = "The weather is bad and it is quite horrible in the dark";
            var banndedWords = WordsHelper.GetBannedWords();
            int expectedBadWordsCount = 0;
            textRepositoryMock.Setup(x => x.GetBannedWords()).Returns(banndedWords);
            textService = new TextService(textParser, textRepositoryMock.Object);
            //Act
            var serviceResult = textService.FilterBannedWords(content, isFilteringEnabled);

            //Assert
            Assert.NotNull(serviceResult.BadWordsCount);
            Assert.AreEqual(expectedBadWordsCount, serviceResult.BadWordsCount);
            Mock.Get(textRepositoryMock.Object).Verify(x => x.GetBannedWords(), Times.Never);
        }
    }

}
