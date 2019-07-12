using NUnit.Framework;
using System.Linq;

namespace ContentConsole.Test.Unit
{
    [TestFixture("Foo.Bar,Fizz:Buzz;", "")]
    [TestFixture("Foo. Bar, Fizz : Buzz; ", "")]
    [TestFixture("Foo. Bar, Fizz : Buzz; ", " F")]
    public class PunctuationStripperTests
    {
        private readonly string _testString;
        private readonly string _extraChars;

        public PunctuationStripperTests(string testString, string extraChars)
        {
            _testString = testString;
            _extraChars = extraChars;
        }
        [Test]
        public void TestStripPunctuation()
        {
            IPunctuationStripper stripper = new PunctuationStripper();
            var result = stripper.StripPunctuation(_testString, true, _extraChars);

            Assert.False(result.Any(c => char.IsPunctuation(c) || _extraChars.Contains(c)));
        }
    }
}
