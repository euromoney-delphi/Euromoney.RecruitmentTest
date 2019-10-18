using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using AutoFixture;
using AutoFixture.AutoMoq;
using ContentConsole.Services;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace ContentConsole.Test.Unit.ServicesTests
{
    [TestFixture]
    public class TextAnalysisServiceTests
    {
        private readonly TextFilterService _classUnderTest;

        public TextAnalysisServiceTests()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var mockBadWordsList = new List<string> { "swine", "bad", "nasty", "horrible" };
            var badWordsProviderMock = fixture.Freeze<Mock<IFilterWordsProvider>>();
            badWordsProviderMock.Setup(provider => provider.BadWordsList).Returns(mockBadWordsList);
            _classUnderTest = fixture.Create<TextFilterService>();
        }

        [Test]
        [TestCase("The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.", "The weather in Manchester in winter is b*d. It rains all the time - it must be h******e for people visiting.", 2)]
        [TestCase("", "", 0)]
        [TestCase(null, null, 0)]
        public void AnalyseText_Should_ReturnsNumberOfBadWords(string content, string expectedContent, int expectedNumberOfFilteredWords)
        {
            var result = _classUnderTest.AnalyseText(content);
            result.NumberOfFilteredWordsFound.Should().Be(expectedNumberOfFilteredWords);
            result.FilteredContent.Should().Be(expectedContent);
        }
    }
}
