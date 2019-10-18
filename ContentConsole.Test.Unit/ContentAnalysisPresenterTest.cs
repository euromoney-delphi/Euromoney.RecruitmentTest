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
        public void ShouldReturnCorrectNumberOfBadWordsInOutPut_WhenABadWordIsDetected(int expectedNumber)
        {
            // arrange
            const string content = "blah blah blab blah blah";
            var analysisResult = new ContentAnalysisResult {OriginalContent = content, NumberOfBadWords = expectedNumber };

            var detectNegativeWordServiceMock = new Mock<IDetectNegativeWordService>();

            detectNegativeWordServiceMock.Setup(x => x.GetDetectedNegativeContentAnalysis(content))
                .Returns(analysisResult);

            // act
            var contentAnalysisPresenter = new ContentAnalysisPresenter(detectNegativeWordServiceMock.Object);
            var output = contentAnalysisPresenter.GetDetectedNegativeOutput(content);

            // assert
            var expectedPhrase = $"Total Number of negative words: {expectedNumber}\n";
            Assert.True(output.Contains(expectedPhrase));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldThrowAnException_WhenDetectNegativeWordServiceObjectIsNull()
        {
            // arrange
            const string content = "blah blah blab blah blah";

            // act
            var contentAnalysisPresenter = new ContentAnalysisPresenter(null);
            contentAnalysisPresenter.GetDetectedNegativeOutput(content);

            // assert
            Assert.Fail("An exception should have been thrown");
        }
    }
}
