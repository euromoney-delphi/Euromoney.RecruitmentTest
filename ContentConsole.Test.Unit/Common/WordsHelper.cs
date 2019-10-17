using System.Collections.Generic;

namespace ContentConsole.Test.Unit.Common
{
    public class WordsHelper
    {
        public static List<string> GetBannedWords()
        {
            string bannedWord1 = "swine";
            string bannedWord2 = "bad";
            string bannedWord3 = "nasty";
            string bannedWord4 = "horrible";
            List<string> banndedWords = new List<string>()
            {
                bannedWord1,
                bannedWord2,
                bannedWord3,
                bannedWord4
            };

            return banndedWords;
        }
    }
}
