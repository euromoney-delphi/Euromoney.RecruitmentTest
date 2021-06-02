using FluentAssertions;
using NUnit.Framework;

namespace Domain.Test.Unit
{
    public class UserReportShould
    {
        private readonly string _testOriginalText = "test text";
        private readonly int _testNegativeWordCount = 1;

        [Test]
        public void ShouldReturnOriginalTextWhenOriginalTextPropertyAccessed()
        {

            #region Arrange

            var sut = new UserReport();

            #endregion Arrange

            #region Act


            #endregion Act

            #region Assert

            sut.OriginalText.Should().Be(_testOriginalText, "because the original text should be returned when the OriginalText property is accessed");

            #endregion Assert
        }
    }
}