using System.Collections.Generic;
using System.Linq;
using ContentConsole.Libraries;
using ContentConsole.Models;
using NUnit.Framework;

namespace ContentConsole.Test.Unit.Libraries
{
    [TestFixture]
    public class BadWordLibraryFixture
    {
        private BadWordLibrary _library;
        [SetUp]
        public void Setup()
        {
            _library = new BadWordLibrary();
            _library.BadWords.Add(new BadWord { Value = "Bad" });
            _library.BadWords.Add(new BadWord { Value = "swine" });
            _library.BadWords.Add(new BadWord { Value = "nasty" });

        }
        [Test]
        public void BadWordListWithThreeObjects()
        {
            var expectedList = new List<BadWord>
            {
                new BadWord{Value = "Bad"},
                new BadWord{Value = "swine"},
                new BadWord{Value = "nasty"}
            };

            var actualBadWordList = _library.BadWords;

            Assert.AreEqual(expectedList.Count,actualBadWordList.Count);
        }

        [Test]
        public void BadWordListContainsObjectOfTypeBadWord()
        {
            var expectedList = new List<BadWord>
            {
                new BadWord{Value = "Bad"}
            };

            var actualBadWordList = _library.BadWords;

            Assert.IsInstanceOf<BadWord>(actualBadWordList[0]);
        }

        [Test]
        public void BadWordListContainsNasty()
        {
            var actualBadWord = _library.BadWords.FirstOrDefault(x => x.Value == "nasty");

            Assert.IsNotNull(actualBadWord);
        }
    }
}
