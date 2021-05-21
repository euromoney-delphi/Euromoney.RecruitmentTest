using ContentConsole.Service;
using NUnit.Framework;

namespace ContentConsole.Test.Unit
{
    [TestFixture]
    public class NegativeWordsApiServiceTest
    {
        private NegativeWordsApiService _apiService;

        [SetUp]
        public void Setup()
        {
            _apiService = new NegativeWordsApiService();
        }

        [Test]
        [Category("Negative Words API Service - Mock Data")]
        public void ShouldContainSeedDataForBadWords()
        {
            //Arrange


            //Act

            var result = _apiService.GetNegativeWordsAsync();

            //Assert
            Assert.AreEqual(4, result.Count);
        }

        [Test]
        [Category("Negative Words API Service - Mock Data")]
        public void ShouldRemoveSpecificWordsBasedOnUserInput()
        {
            //Arrange
            var word = "bad";

            //Act

            _apiService.RemoveNegativeWords(word);
            var result = _apiService.GetNegativeWordsAsync();

            //Assert
            Assert.AreEqual(3, result.Count);
        }

        [Test]
        [Category("Negative Words API Service - Mock Data")]
        public void ShouldRemoveSpecificWordsBasedOnUserInputWithUppercaseFormat()
        {
            //Arrange
            string word = "BaD";

            //Act

            _apiService.RemoveNegativeWords(word);
            var result = _apiService.GetNegativeWordsAsync();

            //Assert
            Assert.AreEqual(3, result.Count);
        }

        [Test]
        [Category("Negative Words API Service - Mock Data")]
        public void ShouldAddNewWordsToMockDBList()
        {
            //Arrange
            string word = "grumpy";

            //Act

            _apiService.AddNegativeWords(word);
            var result = _apiService.GetNegativeWordsAsync();

            //Assert
            Assert.AreEqual(5, result.Count);
        }


        [Test]
        [Category("Negative Words API Service - Mock Data")]
        public void ShouldAddNewWordsToMockDBListWithUppercaseFormat()
        {
            //Arrange
            string word = "GrUmPy";

            //Act

            _apiService.AddNegativeWords(word);
            var result = _apiService.GetNegativeWordsAsync();

            //Assert
            Assert.AreEqual(5, result.Count);
        }
    }
}
