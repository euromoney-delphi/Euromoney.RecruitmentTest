using ContentConsole.AppInterfaces;
using ContentConsole.AppServices;
using Moq;
using NUnit.Framework;

namespace ContentConsole.Test.Unit
{
    [TestFixture]
    public class UserMenuSelectionShould
    {
        [Test]
        public void OutputToScreenAsExpected()
        {
            // Arrange
            var userInteractionMock = new Mock<IUserInteraction>();
            var userServiceMock = new Mock<IUserService>();
            var userMenuSelection = new UserMenuSelection(
                userServiceMock.Object,
                userInteractionMock.Object
            );

            userInteractionMock.Setup(x => x.GetTextInput()).Returns(It.IsAny<string>());
            userServiceMock.Setup(x => x.GetNegativeWordCount(It.IsAny<string>())).Returns(It.IsAny<int>());

            // Act
            userMenuSelection.Execute();

            // Assert
            Mock.Get(userInteractionMock.Object)
                .Verify(x => x.OutputScannedText(It.IsAny<string>()), Times.Once);

            Mock.Get(userInteractionMock.Object)
                .Verify(x => x.OutputTotalNegativeWordsToScreen(It.IsAny<int>()), Times.Once);
        }
    }
}