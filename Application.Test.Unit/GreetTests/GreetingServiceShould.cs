using Application.Greet;
using Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace Application.Test.Unit.GreetTests
{
    public class GreetingServiceShould
    {
        [Test]
        public void CallToOutputGreetingMessageFromConfigurationOnApplicationLaunch()
        {

            #region Arrange

            var greetingMessageFromConfig = "test";
            var testConfigurationSettings = new Dictionary<string, string>()
            {
                {  "GreetingMessage", greetingMessageFromConfig }
            };

            var testInMemoryConfiguration = new ConfigurationBuilder()
                .AddInMemoryCollection(testConfigurationSettings)
                .Build();

            var mockConsoleIOManager = new Mock<IConsoleIOManager>();
            var sut = new GreetingService(mockConsoleIOManager.Object, testInMemoryConfiguration);

            #endregion Arrange


            #region Act

            sut.Greet();

            #endregion Act

            #region Assert

            mockConsoleIOManager
                .Verify(c => c.OutputTextToConsole(It.Is<string>(s => s == greetingMessageFromConfig)),
                "because the greeting message in the app configuration should be output to the console when the Greet method is called");

            #endregion Assert
        }
    }
}
