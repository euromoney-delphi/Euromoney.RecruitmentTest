using ContentConsole.AppServices;
using NUnit.Framework;

namespace ContentConsole.Test.Unit
{
    [TestFixture]
    public class UserServiceShould
    {
        [TestCase("The weather in Manchester in winter is bad, very bad.")]
        [TestCase("The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.")]
        public void ReturnTheNegativeWordCountInAText(string textInput)
        {
            // Arrange
            var userService = new UserService(new NegativeWordStore());
            int expectedCount = 2;

            // Act
            int actualCount = userService.GetNegativeWordCount(textInput);

            // Assert
            Assert.That(actualCount, Is.EqualTo(expectedCount));
        }
    }
}