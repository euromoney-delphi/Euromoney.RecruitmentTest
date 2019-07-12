using ContentConsole.Data;
using NUnit.Framework;
using System.Linq;

namespace Tests
{
    public class BannedWordsRepositoryTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var repo = new BannedWordsRepository();
            var words = repo.Get().ToArray();

            Assert.Contains("horrible", words);
            Assert.Contains("swine", words);
            Assert.Contains("bad", words);
            Assert.Contains("nasty", words);

            repo.Add("foo", "bar", "fizz", "buzz");
            words = repo.Get().ToArray();

            Assert.Contains("horrible", words);
            Assert.Contains("swine", words);
            Assert.Contains("bad", words);
            Assert.Contains("nasty", words);
            Assert.Contains("foo", words);
            Assert.Contains("bar", words);
            Assert.Contains("fizz", words);
            Assert.Contains("buzz", words);
        }
    }
}