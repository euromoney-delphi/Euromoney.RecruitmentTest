using System;
using System.Linq;
using ContentConsole.TestFixtures;
using NegativeContentService;

namespace ContentConsole
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var content =
                "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";

            var isBadWordFilteringEnabled = !args.Any(x => x.Equals("-disableBadWord"));

            var output = GetDetectedNegativeOutputInfo(content, isBadWordFilteringEnabled);
            Console.WriteLine(output);
            Console.ReadKey();
        }

        private static string GetDetectedNegativeOutputInfo(string content, bool isBadWordFilteringEnabled)
        {
            var presenter = new ContentAnalysisPresenter(
                new DetectNegativeWordService(
                    new StubNegativeWordRepository(new[] {"swine", "bad", "nasty", "horrible"})));
            return presenter.GetDetectedNegativeOutput(content, isBadWordFilteringEnabled);
        }
    }

}
