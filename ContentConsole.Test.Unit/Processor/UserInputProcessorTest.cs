using System.Collections.Generic;
using System.Text.RegularExpressions;
using ContentConsole.Model;
using ContentConsole.Processor;
using ContentConsole.Service;
using Moq;
using NUnit.Framework;

namespace ContentConsole.Test.Unit
{
    [TestFixture]
    public class UserInputProcessorTest
    {
        private List<string> _badWordsList;
        private UserInputProcessor _processor;
        private Mock<INegativeWordsApiService> _apiService;

        [SetUp]
        public void Setup()
        {
            _badWordsList = new List<string> { "swine", "bad", "nasty", "horrible" };
            _apiService = new Mock<INegativeWordsApiService>();
            _processor = new UserInputProcessor(_apiService.Object);
        }

        [Test]
        [Category("User Input - Processing")]
        public void ShouldStoreUserInput()
        {
            //Arrange
            var input = Constants.INPUT;

            _apiService.Setup(x => x.GetNegativeWordsAsync()).Returns(_badWordsList);
            //Act

            var result = _processor.ProcessUserInput(input);

            //Assert
            Assert.IsNotEmpty(result.InputUnformatted);
            Assert.IsNotNull(result.InputUnformatted);
        }

        [Test]
        [Category("User Input - Processing")]
        public void ShouldStoreUserInputAndRemoveAllPunctuation()
        {
            //Arrange
            var input = Constants.INPUT;
            var expectedOutput = Regex.Replace(input, @"[^\w\s]", "");

            _apiService.Setup(x => x.GetNegativeWordsAsync()).Returns(_badWordsList);

            //Act

            var result = _processor.ProcessUserInput(input);

            //Assert
            Assert.AreEqual(expectedOutput, result.InputFormatted);
        }

        [Test]
        [Category("User Input - Negative Words Processing")]
        public void ShouldReturnCountOfNegativeWordsFromUserInput()
        {
            //Arrange
            var input = Constants.INPUT;

            _apiService.Setup(x => x.GetNegativeWordsAsync()).Returns(_badWordsList);
            _processor.GetUserInput(input);

            //Act
            var result = _processor.ProcessUserInput(input);

            //Assert
            Assert.AreEqual(2, result.BadWordsCount);
        }

        [Test]
        [Category("User Input - Negative Words Filtering")]
        public void ShouldFilterWordsFromUserInput()
        {
            //Arrange
            var input = Constants.INPUT;
            var expectedOutput = "The weather in Manchester in winter is b#d It rains all the time  it must be h######e for people visiting";


            _apiService.Setup(x => x.GetNegativeWordsAsync()).Returns(_badWordsList);
            _processor.GetUserInput(input);

            //Act
            var result = _processor.ProcessUserInput(input);

            //Assert
            Assert.AreEqual(expectedOutput, result.InputFiltered);
        }
    }
}