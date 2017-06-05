using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContentConsole.Words;

namespace ContentConsole
{
    public class Runner
    {
        private readonly IWordsService _wordsService;

        private const string Phrase =
            "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";
        

        public Runner(IWordsService wordsService)
        {
            _wordsService = wordsService;
        }


        public void Start()
        {
            Console.WriteLine("Add words, 'E' finish entering words");
            string word=string.Empty;
            while (word != "E")
            {
                word = Console.ReadLine();
                if (word != "E")
                {
                    _wordsService.AddWord(word);
                }
            }

            Console.WriteLine("Press any key to analyse");
            Console.ReadLine();
            
            var wordResponse = _wordsService.Analyse(Phrase);
            Console.WriteLine("Scanned the text:");
            Console.WriteLine(wordResponse.Phrase);
            Console.WriteLine($"Total Number of negative words: {wordResponse.WordsFound}");
            Console.ReadLine();

        }
        

    }
}
