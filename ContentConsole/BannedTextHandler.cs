using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ContentConsole
{
    public static class BannedTextHandler
    {
        public static int WordCount(List<string> bannedWords, string content)
        {
            int count = 0;
            foreach (string badWord in bannedWords)                 //Iterate through banned word list
            {
                int i = 0;
                while ((i = content.IndexOf(badWord, i)) != -1)     //Searches content string for the bad word, if not found condition is false
                {
                    i += badWord.Length;                            //Added so word isn't counted twice
                    count++;                                        //Add found bad word to count
                }
            }
            return count;
        }

        public static string WordFilter(List<string> bannedWords, string content)
        {
            string alteredString = content;
            foreach (string badWord in bannedWords)
            {
                var correctedWord = badWord.Substring(0, 1) + new String('#', badWord.Length - 2) + badWord.Substring(badWord.Length - 1, 1);   //Replaces bad word with # but keeps first and last letter
                alteredString = Regex.Replace(alteredString, badWord, correctedWord);
            }
            return alteredString;
        }
    }
}
