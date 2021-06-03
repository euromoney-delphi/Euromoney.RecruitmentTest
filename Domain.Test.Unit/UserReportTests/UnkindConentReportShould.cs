using FluentAssertions;
using NUnit.Framework;

namespace Domain.Test.Unit.UnkindContentReportTests
{
    public class UnkindConentReportShould
    {
        [Test]
        [TestCase("")]
        [TestCase("test text 2")]
        public void ShouldReturnOriginalTextWhenOriginalTextPropertyIsAccessed(string testOriginalText)
        {

            #region Arrange

            var arbitraryNegativeWordCount = 1;

            #endregion Arrange

            #region Act

            var sut = new UnkindContentReport.UnkindContentReport(testOriginalText, arbitraryNegativeWordCount);

            #endregion Act

            #region Assert

            sut.OriginalText.Should().Be(testOriginalText, "because the original text should be returned when the OriginalText property is accessed");

            #endregion Assert
        }

        [Test]
        [TestCase(0)]
        [TestCase(int.MaxValue)]
        public void ShouldReturnNegativeWordCountWhenNegativeWordCountPropertyIsAccessed(int testNegativeWordCount)
        {

            #region Arrange

            var arbitraryOriginalText = "";

            #endregion Arrange


            #region Act

            var sut = new UnkindContentReport.UnkindContentReport(arbitraryOriginalText, testNegativeWordCount);

            #endregion Act

            #region Assert

            sut.NegativeWordCount.Should().Be(testNegativeWordCount, "because the negative word count should be returned when the NegativeWordCount property is accessed");

            #endregion Assert
        }
    }
}