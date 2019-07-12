using ContentConsole.Data;
using System;
using System.Linq;
using Unity;

namespace ContentConsole
{
    public static class Program
    {
        private static readonly IUnityContainer _container = new UnityContainer();
        public static void Main(string[] args)
        {
            RegisterServices();

            bool filterWords = SetArgSwitches(args);

            var content = "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";

            var wordScanner = _container.Resolve<IWordScanner>();
            int badWords = wordScanner.FilterBannedWords(content, filterWords, out var filteredContent);

            Console.WriteLine("Scanned the text:");
            Console.WriteLine(filteredContent);
            Console.WriteLine("Total Number of negative words: " + badWords);

            Console.WriteLine("Press ANY key to exit.");
            Console.ReadKey();
        }

        private static bool SetArgSwitches(string[] args)
        {
            bool filterWords = true;
            if (args.Length > 0)
            {
                if (args.Any(x => string.Equals("/disableFilter", x, StringComparison.OrdinalIgnoreCase)))
                    filterWords = false;
            }

            return filterWords;
        }

        private static void RegisterServices()
        {
            _container.RegisterType<IPunctuationStripper, PunctuationStripper>();
            _container.RegisterType<IWordScanner, WordScanner>();
            _container.RegisterType<IBannedWordsRepository, BannedWordsRepository>();
        }
    }

}
