using Application.Interfaces;
using Application.Prompt;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace Application.Test.Unit.PromptTests
{
    public class PromptingServiceShould
    {
        private Mock<IConsoleIOManager> _mockConsoleIOManager;

        [OneTimeSetUp]
        public void Init()
        {
            _mockConsoleIOManager = new Mock<IConsoleIOManager>();
        }

        [Test]
        public void CallToOutputPromptTextAskingToEnterContentToConsoleWhenPromptUserForContentMethodCalled()
        {

            #region Arrange

            var promptTextForContentEntry = "Please enter content to make more kind:";
            var sut = new ContentPromptingService(_mockConsoleIOManager.Object);

            #endregion Arrange


            #region Act

            sut.PromptForContent();

            #endregion Act

            #region Assert

            _mockConsoleIOManager
                .Verify(c => c.OutputTextToConsole(It.Is<string>(s => s == promptTextForContentEntry)),
                "because the text prompting the user to enter content should be output to the console when the PromptForContent method is called");

            #endregion Assert
        }

        [Test]
        public void ReturnContentEnteredToTerminalByUser()
        {

            #region Arrange

            var testConsoleTextEntry = "test entry";
            _mockConsoleIOManager.Setup(c => c.ReadConsoleTextEntry()).Returns(testConsoleTextEntry);
            var sut = new ContentPromptingService(_mockConsoleIOManager.Object);

            #endregion Arrange


            #region Act

            var result = sut.PromptForContent();

            #endregion Act

            #region Assert

            result.Should().Be(testConsoleTextEntry, 
                "because the text entered into the console when prompted for content should be returned when the PromptForContent method is called");

            #endregion Assert
        }
    }
}
