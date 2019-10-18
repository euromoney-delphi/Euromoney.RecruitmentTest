using NegativeContentService;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ContentConsole.AcceptanceTests
{
    [Binding]
    public sealed class GlobalStep
    {
        private readonly ScenarioContext _context;
        private readonly ContentAnalysisPresenter _presenter;

        public GlobalStep(ScenarioContext injectedContext)
        {
            _context = injectedContext;
            _presenter = new ContentAnalysisPresenter(new DetectNegativeWordService());
        }

        [Given(@"a set of predefined negative words")]
        public void GivenASetOfPredefinedNegativeWords()
        {
            _context.Pending();
        }

        [Given(@"(.*) is supplied")]
        public void GivenIsSupplied(string content)
        {
            _context["ContentRequest"] = content;
            Assert.IsNotEmpty(content);
        }

        [When(@"the content is analysed")]
        public void WhenTheContentIsAnalysed()
        {
            var content = _context["ContentRequest"] as string;
            var outputResult = _presenter.GetDetectedNegativeOutput(content);
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

    }
}
