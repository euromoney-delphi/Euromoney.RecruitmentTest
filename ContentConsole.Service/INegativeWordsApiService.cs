using System.Collections.Generic;
using ContentConsole.Model;

namespace ContentConsole.Service
{
    public interface INegativeWordsApiService
    {
        List<string> GetNegativeWordsAsync();
        void AddNegativeWords(string newWord);
        public void RemoveNegativeWords(string word);
    }
}