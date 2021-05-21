using System.Collections.Generic;

namespace ContentConsole.Service
{
    public class NegativeWordsApiService : INegativeWordsApiService
    {
        private List<string> _negativeWords;

        public NegativeWordsApiService()
        {
            _negativeWords = new List<string> { "swine", "bad", "nasty", "horrible" };
        }

        public List<string> GetNegativeWordsAsync() {

            return _negativeWords;
        }



        public void AddNegativeWords(string newWord)
        {
            _negativeWords.Add(newWord.ToLower());
        }


        public void RemoveNegativeWords(string word)
        {

            _negativeWords.Remove(word.ToLower());
        }
    }
}
