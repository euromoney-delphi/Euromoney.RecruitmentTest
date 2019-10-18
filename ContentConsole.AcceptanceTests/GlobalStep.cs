using System.Linq;
using Moq;
using NegativeContentService;
using NegativeContentService.Data;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ContentConsole.AcceptanceTests
{
    [Binding]
    public sealed class GlobalStep
    {
        private readonly ScenarioContext _context;
        private readonly ContentAnalysisPresenter _presenter;
        private readonly Mock<INegativeWordRepository> _negativeWordRepository;

        public GlobalStep(ScenarioContext injectedContext)
        {
            _negativeWordRepository = new Mock<INegativeWordRepository>();
            _context = injectedContext;
            _context["IsWordFilteringEnabled"] = true;
            _presenter = new ContentAnalysisPresenter(new DetectNegativeWordService(_negativeWordRepository.Object));
        }

        
        
        [Given(@"a set of predefined negative words that include '(.*)'")]
        public void GivenASetOfPredefinedNegativeWordsThatInclude(string bannedWordText)
        {
            var bannedWords = bannedWordText.Split(',');
            _negativeWordRepository.Setup(x => x.GetAllNegativeWords())
                .Returns(bannedWords.ToList());
        }

        [Given(@"a set of predefined negative words")]
        public void GivenASetOfPredefinedNegativeWords()
        {
            _negativeWordRepository.Setup(x => x.GetAllNegativeWords())
                .Returns(new[] {"swine", "bad", "nasty", "horrible"});
        }
        

        [Given(@"(.*) is supplied")]
        public void GivenIsSupplied(string content)
        {
            _context["ContentRequest"] = content;
            Assert.IsNotEmpty(content);
        }


        [Given(@"disabled negative word filtering")]
        public void GivenDisabledNegativeWordFiltering()
        {
            _context["IsWordFilteringEnabled"] = false;
        }

        [When(@"the content is analysed")]
        public void WhenTheContentIsAnalysed()
        {
            var content = _context["ContentRequest"] as string;
            var isWordFilteringEnabled = (bool)_context["IsWordFilteringEnabled"];
            var outputResult = _presenter.GetDetectedNegativeOutput(content, isWordFilteringEnabled);
            _context["OutputResult"] = outputResult;
            Assert.IsNotEmpty(outputResult);
        }

        [Then(@"the number of negative words should be (.*)")]
        public void ThenTheNumberOfNegativeWordsShouldBe(string expectedNumber)
        {
            var outputResult = _context["OutputResult"] as string;
            var phrase = $"Total Number of negative words: {expectedNumber}\n";
            Assert.True(outputResult?.Contains(phrase));
        }

        [Then(@"provide the analysed phrase as its output")]
        public void ThenProvideTheAnalysedPhraseAsItsOutput()
        {
            var outputResult = (string)_context["OutputResult"];
            var content = (string) _context["ContentRequest"];
            Assert.True(outputResult?.Contains(content));
        }

        [When(@"provide the a sanitized phrase as its '(.*)'")]
        public void WhenProvideTheASanitizedPhraseAsIts(string clientOutput)
        {
            var outputResult = (string)_context["OutputResult"];
            Assert.True(outputResult?.Contains(clientOutput));
        }

    }
}
