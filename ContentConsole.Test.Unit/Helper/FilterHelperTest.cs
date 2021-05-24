using System;
using System.Collections.Generic;
using ContentConsole.Model;
using ContentConsole.Processor;
using NUnit.Framework;

namespace ContentConsole.Test.Unit.Helper
{
    [TestFixture]
    public class FilterHelperTest
    {
        private List<string> _badWordsList;

        [SetUp]
        public void Setup()
        {
            _badWordsList = new List<string> { "swine", "bad", "nasty", "horrible" };
        }

        [Test]
        [Category("Filter Helper - Filtering")]
        public void ShouldFilterUserInput()
        {
            //Arrange
            var expectedOutput = "The weather in Manchester in winter is b#d It rains all the time  it must be h######e for people visiting";
            var input = Constants.INPUT;
            var filter = "#";
            //Act

            var result = FilterHelper.FilterOutString(input, filter, _badWordsList);

            //Assert
            Assert.AreEqual(expectedOutput, result);

        }
    }
}
