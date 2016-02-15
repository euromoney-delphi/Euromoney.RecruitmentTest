using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentConsole
{
    public class BannedUserWords
    {
        List<string> BannedWordsList = new List<string>
        { "swine","bad","nasty","horrible" };

        public void AddBannedWords(string word)
        {
            BannedWordsList.Add(word);
        }

        public List<string> GetBannedWordList()
        {
            return BannedWordsList.ToList();
        }
    }

    public static class Content
    {
        public static string content =
           "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";

    }
}
