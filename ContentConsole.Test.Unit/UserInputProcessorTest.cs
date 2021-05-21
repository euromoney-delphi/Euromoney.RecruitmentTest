using System.Collections.Generic;
using System.Text.RegularExpressions;
using ContentConsole.Model;
using ContentConsole.Processor;
using Moq;
using NUnit.Framework;

namespace ContentConsole.Test.Unit
{
    public class UserInputProcessorTest
    {
        private UserInputProcessor _processor;

        [SetUp]
        public void Setup()
        {
            _processor = new UserInputProcessor();
        }

        [Test]
        [Category("User Input - Processing")]
        public void ShouldStoreUserInput()
        {
            //Arrange
            var input = Constants.INPUT;

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

            _processor.GetUserInput(input);
            //Act


            var result = _processor.ProcessUserInput(input);

            //Assert
            Assert.AreEqual(2, result.BadWordsCount);
        }
    }
}