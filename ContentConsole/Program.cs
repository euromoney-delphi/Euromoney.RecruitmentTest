using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;

namespace ContentConsole
{
    public static class Program
    {
        public static void Main(string[] args)
        {

            string bannedWord1 = "swine";
            string bannedWord2 = "bad";
            string bannedWord3 = "nasty";
            string bannedWord4 = "horrible";

            string content =
                "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";

            #region
            int badWords = 0;
            if (content.Contains(bannedWord1))
            {
                badWords = badWords + 1;
            }
            if (content.Contains(bannedWord2))
            {
                badWords = badWords + 1;
            }
            if (content.Contains(bannedWord3))
            {
                badWords = badWords + 1;
            }
            if (content.Contains(bannedWord4))
            {
                badWords = badWords + 1;
            }
            #endregion

            Console.WriteLine("Scanned the text:");
            Console.WriteLine(content);
            Console.WriteLine("Total Number of Bad words: " + badWords);

            Console.WriteLine("Press ANY key to exit.");

           string total = GetTotalNumberOfBadWords(content);
           Console.WriteLine(total);

           string filter = FilterBadWords(content);
           Console.WriteLine(filter);

           string disable = DisableBadFiltering(content);
           Console.WriteLine(total + disable);

           UpdateBadWord(GetBadWords());

            Console.ReadKey();

            /*
             * Different approach
             * Repository Pattern
             * 1. Create an Interface an implement below methods in the repository
             * 2. Access the repository from the controller and return the results.
             */
        }

        public static List<BadWordModel> GetBadWords()
        {
            List<BadWordModel> BadWords = new List<BadWordModel>
            {
                new BadWordModel {BadWord = "swine"},
                new BadWordModel {BadWord = "bad"},
                new BadWordModel {BadWord = "nasty"},
                new BadWordModel {BadWord = "horrible"}
            };

            return BadWords;
        }

        public static string GetTotalNumberOfBadWords(string sentence)
        {
            int count = 0;
            string output = "Total count of bad words : ";

            foreach (var BadWord in GetBadWords())
            {
                if (sentence.ToLower().Contains(BadWord.BadWord))
                {
                    count++;
                }
            }

            return output + count;
        }

        public static string FilterBadWords(string sentence)
        {
            string strReplace = string.Empty;

            foreach (var word in GetBadWords().Select(c=>c.BadWord))
            {
                string first = word.First().ToString();
                string last = word.Last().ToString();

                string removeLast = word.Remove(word.Length - 1);
                string wordToRemove = removeLast.Remove(0, 1);

                if (sentence.ToLower().Contains(word))
                {
                    for (int i = 0; i < wordToRemove.Length; i++)
                    {
                        strReplace += "#";
                    }

                    sentence = Regex.Replace(sentence, word, first + strReplace + last, RegexOptions.IgnoreCase);
                }
            }

            return sentence;
        }

        public static string DisableBadFiltering(string sentence)
        {
            foreach (var BadWordModel in GetBadWords())
            {
                sentence = Regex.Replace(sentence,
                    "\\b" + string.Join("\\b|\\b", BadWordModel.BadWord) + "\\b", "");
            }


            return sentence;
        }

        public static void UpdateBadWord(List<BadWordModel> BadWordEntity)
        {
            if (BadWordEntity != null)
            {
                foreach (var badWordModel in BadWordEntity)
                {
                    badWordModel.BadWord = "test";
                }
            }
        }
    }

    public class BadWordModel
    {
        public string BadWord { get; set; }
    }
}
