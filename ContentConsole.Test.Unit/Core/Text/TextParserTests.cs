using ContentConsole.Test.Unit.Common;
using EuroMoney.Core.Text;
using NUnit.Framework;
using System.Collections.Generic;


namespace ContentConsole.Test.Unit.Core.Text
{
    [TestFixture]
    public class TextParserTests
    {
        private TextParser textParser;
        [SetUp]
        public void Setup()
        {
            textParser = new TextParser();            
        }

        [Test]
        public void When_Sentence_Has_BadWords_Then_Return_BadWords_Count()
        {
            //Arrange
            int expectedBadWordsCount = 2;
            string inputData = "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";
            List<string> banndedWords = WordsHelper.GetBannedWords();

            //Act           
            var result = textParser.Filter(inputData, banndedWords);

            //Assert
            Assert.AreEqual(expectedBadWordsCount, result?.BadWordsCount);
        }       

        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void When_Sentence_Has_NoInput_Data_Then_Return_BadWords_Count_As_Zero(string inputData)
        {
            //Arrange
            int expectedBadWordsCount = 0;
            List<string> banndedWords = WordsHelper.GetBannedWords();

            //Act   
            var result = textParser.Filter(inputData, banndedWords);

            //Assert
            Assert.AreEqual(expectedBadWordsCount, result.BadWordsCount);
            Assert.AreEqual(inputData, result.OriginalText);
        }        

        [Test]        
        public void When_Sentence_Has_Input_Data_But_No_Banned_WordsThen_Return_BadWords_Count_As_Zero()
        {
            //Arrange
            int expectedBadWordsCount = 0;
            string inputData = "A quick brown fox";
            
            List<string> banndedWords = new List<string>() { };

            //Act   
            var result = textParser.Filter(inputData, banndedWords);

            //Assert
            Assert.AreEqual(expectedBadWordsCount, result.BadWordsCount);
            Assert.AreEqual(inputData, result.OriginalText);
        }

        [Test]
        public void When_Word_Is_BadWord_Then_Return_Hash_Of_BadWords()
        {
            //Arrange
            char hasher = '*';
            string expectedHash = "h******e";
            string inputData = "horrible";

            //Act           
            var result = textParser.GetHashedString(inputData, hasher);

            //Assert
            Assert.AreEqual(expectedHash, result);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void When_Word_Is_Not_Valid_Then_Return_Non_hashed_Word(string inputData)
        {
            //Arrange
            char hasher = '*';
            string exptectedHash = inputData;
            List<string> banndedWords = WordsHelper.GetBannedWords();

            //Act           
            var result = textParser.GetHashedString(inputData, hasher);

            //Assert
            Assert.AreEqual(exptectedHash, result);
        }
    }
}
