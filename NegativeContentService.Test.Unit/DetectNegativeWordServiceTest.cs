using NUnit.Framework;

namespace NegativeContentService.Test.Unit
{
    public class DetectNegativeWordServiceTest
    {

        [Test]
        public void ShouldReturnCorrectNumberOfBadWordsInResult_WhenABadWordIsFound()
        {
            const int expectedNumber = 2;
            const string content = "blah blah horrible blah swine";

            // act
            var detectNegativeWordService = new DetectNegativeWordService();
            var result = detectNegativeWordService.GetDetectedNegativeContentAnalysis(content);

            // assert
            Assert.AreEqual(expectedNumber, result.NumberOfBadWords);
        }

        [Test]
        public void ShouldReturnCorrectNumberOfBadWordsInResult_WhenABadWordIsNotFound()
        {
            const int expectedNumber = 0;
            const string content = "blah blah blah blah blah";

            // act
            var detectNegativeWordService = new DetectNegativeWordService();
            var result = detectNegativeWordService.GetDetectedNegativeContentAnalysis(content);

            // assert
            Assert.AreEqual(expectedNumber, result.NumberOfBadWords);
        }
    }
}
