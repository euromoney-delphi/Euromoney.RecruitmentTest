using Application.Interfaces;
using Application.Report;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace Application.Test.Unit.BannedWordCounterTests
{
    public class UnkindContentReporterServiceShould
    {
        [Test]
        public void ReturnUnkindContentReportWithCorrectCountOfBannedWords()
        {

            #region Arrange

            var testBannedWord = "test";
            var mockBannedWordRepository = new Mock<IBannedWordRepository>();
            var testContent = "test content";
            var testBannedWordCount = 1;
            mockBannedWordRepository.Setup(r => r.Get()).Returns(new HashSet<string>() { testBannedWord });
            var sut = new UnkindContentReporterService(mockBannedWordRepository.Object);

            #endregion Arrange


            #region Act

            var result = sut.ProduceReport(testContent).NegativeWordCount;

            #endregion Act

            #region Assert

            result.Should().Be(testBannedWordCount, "because this is the number of banned words in the input content");

            #endregion Assert
        }
    }
}
