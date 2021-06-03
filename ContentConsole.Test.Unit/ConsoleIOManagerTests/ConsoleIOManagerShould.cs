using FluentAssertions;
using KinderConsole;
using NUnit.Framework;
using System;
using System.IO;

namespace ContentConsole.Test.Unit.ConsoleIOManagerTests
{
    public class ConsoleIOManagerShould
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("")]
        [TestCase("test text 2")]
        public void OutputTextToConsoleWhenOutputTextToConsoleMethodIsCalledWithTheTextAsItsInput(string testTextForOutput)
        {

            #region Arrange

            var sut = new ConsoleIOManager();

            #endregion Arrange


            #region Act

            using var testStringWriterToCaputureConsoleOutput = new StringWriter();
            Console.SetOut(testStringWriterToCaputureConsoleOutput);

            sut.OutputTextToConsole(testTextForOutput);

            var stringReader = new StringReader(testStringWriterToCaputureConsoleOutput.ToString());

            var consoleOutput = stringReader.ReadLine();

            #endregion Act

            #region Assert

            consoleOutput.Should().Be(testTextForOutput, 
                "because the input that the OutputTextToConsole method is called with should be output to the console");

            #endregion Assert
        }
    }
}