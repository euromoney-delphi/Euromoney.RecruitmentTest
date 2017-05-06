using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentConsole.Test.Unit
{
    public class Mother
    {
        public static string DefaultContent =>
            "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";

        public static string ExpectedCleanContent =>
            "The weather in Manchester in winter is b#d. It rains all the time - it must be h######e for people visiting.";

        public static string AlternativeContent =>
            "The weather in Manchester in winter is nasty. It rains like a swine all the time - it must be horrible for people visiting.";

        public static List<string> DefaultBadWords()
        {
            return new List<string> {"bad", "swine", "horrible", "nasty"};
        }

        public static List<string> ThreeBadWords()
        {
            return new List<string> {"bad", "swine", "nasty"};
        }

        public static List<string> AlternativeBadWords()
        {
            return new List<string> {"crappy", "rubbish", "disgusting"};
        }
    }
}
