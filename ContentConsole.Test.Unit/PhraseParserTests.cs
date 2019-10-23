using System.Linq;
using ContentConsole.Models;
using ContentConsole.Services;
using NUnit.Framework;

namespace ContentConsole.Test.Unit
{
    [TestFixture]
    public class PhraseParserTests
    {
        [Test]
        public void PhraseParsingWithProvidedExampleSucceeds()
        {
            var service = new PhraseToWordsParserService();
            var filterService = new BadWordFilterService(new StringRepositoryService(new []
                {
                    "bad",
                    "swine",
                    "horrible",
                    "nasty"
                }
                ));
            string textToParse = "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting. This is really nasty nasty weather.";
            var result = service.Parse(textToParse, filterService);
            var badWordCount = result.PhraseParts.Where(part => part is FilteredPhrasePart).Cast<FilteredPhrasePart>()
                .Count(filteredPart => filteredPart.IsFilteredWord);
            Assert.AreEqual(
                "The weather in Manchester in winter is b#d. It rains all the time - it must be h######e for people visiting. This is really n###y n###y weather.",
                result.ToString());
            Assert.AreEqual(4, badWordCount);
        }

        [Test]
        public void PhraseParsingWithAStartingBadwordSucceeds()
        {
            var service = new PhraseToWordsParserService();
            var filterService = new BadWordFilterService(new StringRepositoryService(new[]
                {
                    "bad",
                    "swine",
                    "horrible",
                    "nasty"
                }
            ));
            string textToParse = "Bad is bad The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting. This is really nasty nasty weather.";
            var result = service.Parse(textToParse, filterService);
            var badWordCount = result.PhraseParts.Where(part => part is FilteredPhrasePart).Cast<FilteredPhrasePart>()
                .Count(filteredPart => filteredPart.IsFilteredWord);
            Assert.AreEqual(
                "B#d is b#d The weather in Manchester in winter is b#d. It rains all the time - it must be h######e for people visiting. This is really n###y n###y weather.",
                result.ToString());
            Assert.AreEqual(6, badWordCount);
        }

        [Test]
        public void PhraseParsingWithAEndingBadWordSucceeds()
        {
            var service = new PhraseToWordsParserService();
            var filterService = new BadWordFilterService(new StringRepositoryService(new[]
                {
                    "bad",
                    "swine",
                    "horrible",
                    "nasty"
                }
            ));
            string textToParse = "Bad is bad The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting. This is really nasty nasty weather. How nasty";
            var result = service.Parse(textToParse, filterService);
            var badWordCount = result.PhraseParts.Where(part => part is FilteredPhrasePart).Cast<FilteredPhrasePart>()
                .Count(filteredPart => filteredPart.IsFilteredWord);
            Assert.AreEqual(
                "B#d is b#d The weather in Manchester in winter is b#d. It rains all the time - it must be h######e for people visiting. This is really n###y n###y weather. How n###y",
                result.ToString());
            Assert.AreEqual(7, badWordCount);
        }

        [Test]
        public void PhraseParsingWithAnEmptyStringSucceeds()
        {
            var service = new PhraseToWordsParserService();
            var filterService = new BadWordFilterService(new StringRepositoryService(new[]
                {
                    "bad",
                    "swine",
                    "horrible",
                    "nasty"
                }
            ));
            string textToParse = "";
            var result = service.Parse(textToParse, filterService);
            var badWordCount = result.PhraseParts.Where(part => part is FilteredPhrasePart).Cast<FilteredPhrasePart>()
                .Count(filteredPart => filteredPart.IsFilteredWord);
            Assert.AreEqual(
                "",
                result.ToString());
            Assert.AreEqual(0, badWordCount);
        }

        [Test]
        public void PhraseParsingWithAWhitespaceStringSucceeds()
        {
            var service = new PhraseToWordsParserService();
            var filterService = new BadWordFilterService(new StringRepositoryService(new[]
                {
                    "bad",
                    "swine",
                    "horrible",
                    "nasty"
                }
            ));
            string textToParse = "     \t\r\n";
            var result = service.Parse(textToParse, filterService);
            var badWordCount = result.PhraseParts.Where(part => part is FilteredPhrasePart).Cast<FilteredPhrasePart>()
                .Count(filteredPart => filteredPart.IsFilteredWord);
            Assert.AreEqual(
                "",
                result.ToString());
            Assert.AreEqual(0, badWordCount);
        }
    }
}
