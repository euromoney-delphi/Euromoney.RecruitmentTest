using System;
using NegativeContentService;

namespace ContentConsole
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var content =
                "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";

            var output = GetDetectedNegativeOutputInfo(content);
            Console.WriteLine(output);
            Console.ReadKey();
        }

        private static string GetDetectedNegativeOutputInfo(string content)
        {
            var presenter = new ContentAnalysisPresenter(new DetectNegativeWordService());
            return presenter.GetDetectedNegativeOutput(content);
        }
    }

}
