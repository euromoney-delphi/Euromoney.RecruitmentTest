using ContentConsole.Test.Unit.Common;
using EuroMoney.Data;
using NUnit.Framework;
using System.Collections.Generic;

namespace ContentConsole.Test.Unit.Data
{
    [TestFixture]
    public class TextRepositoryTests
    {
        private ITextRepository textRepository;
        [SetUp]
        public void Setup()
        {
            textRepository = new TextRepository();
        }

        [Test]
        public void When_BadWords_Are_Defined_Then_Return_BadWords()
        {
            //Arrange
          
            List<string> expectedBanndedWords = WordsHelper.GetBannedWords();

            //Act           
            var result = textRepository.GetBannedWords();

            //Assert
            Assert.NotNull(expectedBanndedWords);
            Assert.AreEqual(expectedBanndedWords.Count, result.Count);
        }

        [Test]
        public void When_BadWords_Are_Not_Defined_Then_Return_Null_BadWords()
        {
            //Arrange

            List<string> expectedBanndedWords = null;
            textRepository.SaveBannedWords(expectedBanndedWords);

            //Act           
            var result = textRepository.GetBannedWords();

            //Assert
            Assert.Null(expectedBanndedWords);
        }

        [Test]
        public void When_BadWords_Are_Added_Then_Save_BadWords()
        {
            //Arrange

            List<string> expectedBanndedWords = new List<string> {"dummy1" };

            //Act           
            var result = textRepository.SaveBannedWords(expectedBanndedWords);

            //Assert
            Assert.True(result);
        }
    }
}
