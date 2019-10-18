using Moq;
using NegativeContentService.Data;
using NUnit.Framework;

namespace NegativeContentService.Test.Unit
{
    public class DetectNegativeWordServiceTest
    {
        private readonly Mock<INegativeWordRepository> _negativeWordRepository;

        public DetectNegativeWordServiceTest()
        {
            _negativeWordRepository = new Mock<INegativeWordRepository>();

            _negativeWordRepository.Setup(x => x.GetAllNegativeWords())
                .Returns(new[] { "horrible", "swine" });
        }

        [Test]
        public void ShouldReturnCorrectNumberOfBadWordsInResult_WhenABadWordIsFound()
        {
            const int expectedNumber = 2;
            const string content = "blah blah horrible blah swine";



            // act
            var detectNegativeWordService = new DetectNegativeWordService(_negativeWordRepository.Object);
            var result = detectNegativeWordService.GetNegativeContentAnalysis(content);

            // assert
            Assert.AreEqual(expectedNumber, result.NumberOfBadWords);
        }

        [Test]
        public void ShouldReturnCorrectNumberOfBadWordsInResult_WhenABadWordIsNotFound()
        {
            const int expectedNumber = 0;
            const string content = "blah blah blah blah blah";

            // act
            var detectNegativeWordService = new DetectNegativeWordService(_negativeWordRepository.Object);
            var result = detectNegativeWordService.GetNegativeContentAnalysis(content);

            // assert
            Assert.AreEqual(expectedNumber, result.NumberOfBadWords);
        }

        [Test]
        public void ShouldReturnReplaceBadWordsWithHashedOne_WhenABadWordIsFound()
        {
            const string expectedWord = "h######e";
            const string content = "blah blah horrible blah";

            // act
            var detectNegativeWordService = new DetectNegativeWordService(_negativeWordRepository.Object);
            var result = detectNegativeWordService.GetNegativeContentAnalysis(content);

            // assert
            var expectedContent = $"blah blah {expectedWord} blah";
            Assert.AreEqual(expectedContent, result.SanitizedContent);
        }
    }
}
