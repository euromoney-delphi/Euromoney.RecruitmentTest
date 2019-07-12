using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentConsole.Test.Unit
{
    [TestFixture("Foo.Bar,Fizz:Buzz;", "")]
    [TestFixture("Foo. Bar, Fizz : Buzz; ", "")]
    [TestFixture("Foo. Bar, Fizz : Buzz; ", " F")]
    public class TextStripperTests
    {
        private readonly string _testString;
        private readonly string _extraChars;

        public TextStripperTests(string testString, string extraChars)
        {
            _testString = testString;
            _extraChars = extraChars;
        }
        [Test]
        public void TestStripPunctuation()
        {
            ITextStripper stripper = new TextStripper();
            var result = stripper.StripText(_testString, true, _extraChars);

            Assert.False(result.Any(c => char.IsPunctuation(c) || _extraChars.Contains(c)));
        }
    }
}
