using System;
using Moq;
using NegativeContentService;
using NegativeContentService.Models;
using NUnit.Framework;

namespace ContentConsole.Test.Unit
{
    public class ContentAnalysisPresenterTest
    {
        [Test]
        [TestCase(0)]
        [TestCase(1)]
        public void ShouldReturnCorrectNumberOfBadWords_AndHasedBadWord_InOutPut_WhenABadWordIsDetected(int expectedNumber)
        {
            // arrange
            const string content = "blah blah blab blah blah";
            const string sanitizedContent = "blah blah b##b blah blah";
            var analysisResult = new ContentAnalysisResult {OriginalContent = content, NumberOfBadWords = expectedNumber, SanitizedContent = sanitizedContent };

            var detectNegativeWordServiceMock = new Mock<IDetectNegativeWordService>();

            detectNegativeWordServiceMock.Setup(x => x.GetNegativeContentAnalysis(content))
                .Returns(analysisResult);

            // act
            var contentAnalysisPresenter = new ContentAnalysisPresenter(detectNegativeWordServiceMock.Object);
            var output = contentAnalysisPresenter.GetDetectedNegativeOutput(content, true);

            // assert
            var expectedPhrase = $"Total Number of negative words: {expectedNumber}\n";
            Assert.True(output.Contains(expectedPhrase));
            Assert.True(output.Contains(analysisResult.SanitizedContent));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldThrowAnException_WhenDetectNegativeWordServiceObjectIsNull()
        {
            // arrange
            const string content = "blah blah blab blah blah";

            // act
            var contentAnalysisPresenter = new ContentAnalysisPresenter(null);
            contentAnalysisPresenter.GetDetectedNegativeOutput(content, true);

            // assert
            Assert.Fail("An exception should have been thrown");
        }

        [Test]
        public void ShouldReturnNotFilterBadWords_WhenBadWordFilteringIsDisable()
        {
            // arrange
            const int expectedNumber = 1;
            const bool isBadWordFilteringEnabled = false;
            const string content = "blah blah blab blah blah";
            const string sanitizedContent = "blah blah b##b blah blah";

            var analysisResult = new ContentAnalysisResult { OriginalContent = content, NumberOfBadWords = expectedNumber, SanitizedContent = sanitizedContent };

            var detectNegativeWordServiceMock = new Mock<IDetectNegativeWordService>();

            detectNegativeWordServiceMock.Setup(x => x.GetNegativeContentAnalysis(content))
                .Returns(analysisResult);

            // act
            var contentAnalysisPresenter = new ContentAnalysisPresenter(detectNegativeWordServiceMock.Object);
            var output = contentAnalysisPresenter.GetDetectedNegativeOutput(content, isBadWordFilteringEnabled);

            // assert
            Assert.True(output.Contains(analysisResult.OriginalContent));
        }
    }
}
