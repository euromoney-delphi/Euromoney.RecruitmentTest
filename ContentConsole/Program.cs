using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ContentConsole
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            #region CommonCodeForAllStories
            //Get command line arguments and store runtime settings.
            //All settings are stored in this class.
            //used to mimic different settings during runtime.
            RunTimeSettings runTimeSettings = new RunTimeSettings(args);

            //Create User With Access Rights Specified From command line.
            //In real world would be read from DB or AD for example
            User user = new User()
            {
                IsAdmin = runTimeSettings.IsAdmin,
                IsContentCurator = runTimeSettings.IsContentCurator,
                IsReader = runTimeSettings.IsReader,
                IsUser = runTimeSettings.IsUser
            };
            #endregion

            //Story3 Command Line = /story3 /isreader 

            //Remove comments as necersary
            //Setting Values Required For This Test
            runTimeSettings.Story3 = true;
            user.IsReader = true;

            if (runTimeSettings.Story3)
            {
                if (IsReader(user))
                {
                    Console.WriteLine(FilterNegativeWords(runTimeSettings.Content, ReadBadWordsFromRepository()));
                }
                else
                {
                    Console.WriteLine("You Are Not An Authorised Reader.");
                }
            }
            Console.WriteLine("Press ANY key to exit.");
            Console.ReadKey();
        }

        /// <summary>
        /// Get The Bad Words from a text file
        /// </summary>
        /// <returns></returns>
        public static List<string> ReadBadWordsFromRepository()
        {
            //Reads Bad Words From The Database
            return (new BadWordList()).BadWords;
        }

        /// <summary>
        /// Is the User a Reader?
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool IsReader(User user)
        {
            return user.IsReader;
        }

        /// <summary>
        /// Simulates Adding New Bad Word To The Repo For This Runtime
        /// </summary>
        /// <param name="arrNewBadWords"></param>
        /// <returns></returns>
        public static List<string> AddNegativeWordsToRepo(string[] arrNewBadWords)
        {
            var lMergedBadWords = new List<string>();
            foreach (string newBadWord in arrNewBadWords)
            {
                lMergedBadWords.Add(newBadWord);
            }
            return lMergedBadWords;
        }

        /// <summary>
        /// Simulates Removing A Bad Word From This Repo For This Runtime
        /// </summary>
        /// <param name="arrNewBadWords"></param>
        /// <returns></returns>
        public static List<string> RemoveNegativeWordsRepo(string[] arrNewBadWords)
        {
            var lMergedBadWords = new List<string>(ReadBadWordsFromRepository());
            foreach (string wordToRemove in arrNewBadWords)
            {
                lMergedBadWords.Remove(wordToRemove);
            }
            return lMergedBadWords;
        }

        /// <summary>
        /// Apply filter to negatve words in content
        /// </summary>
        /// <param name="content"></param>
        /// <param name="lBadWords"></param>
        /// <returns></returns>
        public static string FilterNegativeWords(string content, List<string> lBadWords)
        {
            foreach (string badWord in lBadWords)
            {
                string sReplacementWord = badWord[0].ToString() + new string('#', badWord.Length - 2) + badWord[badWord.Length - 1].ToString();
                content = Regex.Replace(content, badWord, sReplacementWord, RegexOptions.IgnoreCase);
            }
            return content;
        }
    }


    #region classes
    //used to declare and set our user values for access
    //assuming all values may be set independently, for example
    //an admin may be able to modify the bad word criteria but not be able
    //to actually view confidential content.
    public class User
    {
        public bool IsUser { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsReader { get; set; }
        public bool IsContentCurator { get; set; }
    }

    /// <summary>
    /// Stores All Runtime information retrieved from command line and is used when simulating execution of tests
    /// </summary>
    public class RunTimeSettings
    {
        public RunTimeSettings(string[] args)
        {
            //Set Default Content, Overridden if set by commandline
            this.Content = "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";
            foreach (string arg in args)
            {
                //Get First Part Of Argument
                string tmpArg = arg.Split(':')[0].ToLower();
                switch (tmpArg)
                {
                    case "/content":
                        this.Content = arg.Split(':')[1];
                        break;
                    case "/story1":
                        this.Story1 = true;
                        break;
                    case "/story2":
                        this.Story2 = true;
                        break;
                    case "/story3":
                        this.Story3 = true;
                        break;
                    case "/story4":
                        this.Story4 = true;
                        break;
                    case "/isadmin":
                        this.IsAdmin = true;
                        break;
                    case "/isreader":
                        this.IsReader = true;
                        break;
                    case "/isuser":
                        this.IsUser = true;
                        break;
                    case "/iscontentcurator":
                        this.IsContentCurator = true;
                        break;
                    case "/addbadwords":
                        this.AddBadWords = true;
                        this.BadWordsToAdd = arg.Split(':')[1].Split(',');
                        break;
                    case "/removebadwords":
                        this.RemoveBadWords = true;
                        this.BadWordsToRemove = arg.Split(':')[1].Split(',');
                        break;
                    case "/disablefilter":
                        this.DisableFilter = true;
                        break;
                }
            }
        }

        public string Content { get; set; }
        public bool Story1 { get; set; }
        public bool Story2 { get; set; }
        public bool Story3 { get; set; }
        public bool Story4 { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsUser { get; set; }
        public bool IsReader { get; set; }
        public bool IsContentCurator { get; set; }
        public bool AddBadWords { get; set; }
        public string[] BadWordsToAdd { get; set; }
        public bool RemoveBadWords { get; set; }
        public string[] BadWordsToRemove { get; set; }
        public bool DisableFilter { get; set; }
        public string[] BadWords { get; set; }
    }
    #endregion
}
