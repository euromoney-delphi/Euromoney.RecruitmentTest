using System;

namespace ContentConsole
{
    public static class Program
    {
        private static bool _raw;
        private static bool _showHelp;

        public static void Main(string[] args)
        {

            // Check for copmmand line arguments.
            ProcessArgs(args);

            // Show help & usage text.
            if (_showHelp)
            {
                ShowHelp();
                return;
            }

            const string content = "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";

            // Show unfiltered text.
            if (_raw)
            {
                ShowRawText(content);
                return;
            }

            // Show redacted text.
            ShowRedactedText(content);

        }

        private static void ProcessArgs(string[] args)
        {
            foreach (var arg in args)
            {
                switch (arg)
                {
                    case "/?":
                    case "/help":
                        _showHelp = true;
                        break;

                    case "/show":
                        _raw = true;
                        break;

                }
            }
        }

        public static void ShowHelp()
        {
            Console.WriteLine("");
            Console.WriteLine("Welcome to the text cleanser");
            Console.WriteLine("----------------------------");
            Console.WriteLine("");
            Console.WriteLine("The following arguments can be used:");
            Console.WriteLine("  /show : Shows the unfiltered text, without the word count");
            Console.WriteLine("");

            Console.WriteLine("Press ANY key to exit.");
            Console.ReadKey();
        }

        public static void ShowRawText(string content)
        {
            Console.WriteLine("This is the unfiltered text:");
            Console.WriteLine(content);
            Console.WriteLine("");

            Console.WriteLine("Press ANY key to exit.");
            Console.ReadKey();
        }

        public static void ShowRedactedText(string content)
        {
            var repo = new DisallowedWordRepo();
            var bannedWords = repo.GetDisallowedWords();

            var cleanser = new TextCleanser(bannedWords);
            var badWordCount = cleanser.CountDisallowedWords(content);
            var redactedContent = cleanser.RedactDisallowedWords(content);

            Console.WriteLine("Scanned the text:");
            Console.WriteLine(redactedContent);
            Console.WriteLine("Total Number of negative words: " + badWordCount);
            Console.WriteLine("");

            Console.WriteLine("Press ANY key to exit.");
            Console.ReadKey();
        }

    }

}
