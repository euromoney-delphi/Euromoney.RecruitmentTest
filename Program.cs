using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;
using System.Text.RegularExpressions;

namespace ContentConsole
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            bool filteringEnabled = FilterCheck();

            string[] bannedWords = ConfigurationManager.AppSettings.Get("bannedwords").Split(',');

            string content = "bad The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.bad";


            int badWords = CountBannedWords(content, bannedWords);

            if (filteringEnabled)
            {
                content = RemoveBannedWords(content, bannedWords);
            }

            Console.WriteLine("Scanned the text:");
            Console.WriteLine(content);
            Console.WriteLine("Total Number of negative words: " + badWords);

            Console.WriteLine("Press ANY key to exit.");
            Console.ReadKey();
        }

        public static bool FilterCheck()
        {
            string input = "";

            do
            {
                Console.WriteLine("Do you want negative word filtering?  Please enter y/n");
                input = Console.ReadLine();
            } while (input != "y" && input != "n");

            return input == "y" ? true : false;
        }

        public static string IndexedReplaceHash(this string s, int index, int length, int charactercount)
        {
            var builder = new StringBuilder();
            builder.Append(s.Substring(0, index));
            builder.Append(new string('#', charactercount));
            builder.Append(s.Substring(index + length));
            return builder.ToString();
        }

        public static int CountBannedWords(string content, string[] bannedWords)
        {
            int count = 0;
            foreach (string word in bannedWords)
            {
                MatchCollection matches = Regex.Matches(content, $@"\b{word}\b", RegexOptions.IgnoreCase);

                count += matches.Count;
            }
            return count;
        }

        public static string RemoveBannedWords(string content, string[] bannedWords)
        {
            foreach (string word in bannedWords)
            {
                MatchCollection matches = Regex.Matches(content, $@"\b{word}\b", RegexOptions.IgnoreCase);

                foreach (Match match in matches)
                {
                    if (match.Index == 0)
                    {
                        content = content.IndexedReplaceHash(1, match.Length - 2, match.Length - 2);
                    }
                    else if (match.Index + match.Length == content.Length)
                    {
                        content = content.IndexedReplaceHash(match.Index + 1, match.Length - 2, match.Length - 2);
                    }
                    else
                    {
                        content = content.IndexedReplaceHash(match.Index + 1, match.Length - 2, match.Length - 2);
                    }
                }                
            }
            return content;
        }
    }
}
