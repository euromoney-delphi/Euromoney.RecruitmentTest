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

            //Story2 Command Line = /story2 /isadmin
            //Story2 Command Line = /story2 /isadmin /AddBadWords:rubbish,poor
            //Story2 Command Line = /story2 /isadmin /RemoveBadWords:bad

            //Remove comments as necersary
            //Setting Values Required For This Test(1)
            runTimeSettings.Story2 = true;
            user.IsAdmin = true;

            runTimeSettings.AddBadWords = true;
            runTimeSettings.BadWordsToAdd = new string[] { "rubbish", "poor" };
            runTimeSettings.RemoveBadWords = true;
            runTimeSettings.BadWordsToRemove = new string[] { "bad" };


            if (runTimeSettings.Story2)
            {
                if (IsAdmin(user))
                {
                    List<string> badWords = ReadBadWordsFromRepository();
                    if (runTimeSettings.RemoveBadWords)
                    {
                        badWords = RemoveNegativeWordsRepo(runTimeSettings.BadWordsToRemove);
                    }
                    if (runTimeSettings.AddBadWords)
                    {
                        badWords.AddRange(AddNegativeWordsToRepo(runTimeSettings.BadWordsToAdd));
                    }
                    Console.WriteLine("The Following Words Are Defined As Bad In The Database: ({0} Word(s))", badWords.Count());
                    for (int i = 0; i < badWords.Count(); i++)
                    {
                        Console.WriteLine("{0}: {1}", i, badWords[i]);
                    }
                }
                else
                {
                    Console.WriteLine("You Are Not An Authorised Administrative User.");
                }
            }

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
        /// Is the User an Admin?
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool IsAdmin(User user)
        {
            return user.IsAdmin;
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
