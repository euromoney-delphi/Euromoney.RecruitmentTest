using System;
using System.Collections.Generic;

namespace ContentConsole
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            BaseClass user = new UserCase();
            BaseClass admin = new AdministratorCase();
            BaseClass reader = new ReaderCase();
            BaseClass contentCurator = new ContentCuratorCase();

            user.ProcessRequest();
            admin.ProcessRequest();
            reader.ProcessRequest();
            contentCurator.ProcessRequest();
            Console.ReadKey();
        }
    }    
    
    public abstract class BaseClass
    {
        public BannedUserWords BannedWords = new BannedUserWords();
        public int badWords = 0;
        public void CheckBannedWords()
        {
            foreach (var bannedWord in BannedWords.GetBannedWordList())
            {
                if (Content.content.Contains(bannedWord))
                {
                    badWords = badWords + 1;
                }
            }

        }
        public abstract void ProcessRequest();
    }

    public class UserCase : BaseClass
    {
        public override void ProcessRequest()
        {
            Console.WriteLine("User story1");
            Console.WriteLine("Scanned the text:");
            Console.WriteLine(Content.content);
            CheckBannedWords();
            Console.WriteLine("Total Number of negative words: " + badWords);
        }
    }

    public class ContentCuratorCase : BaseClass
    {
        public override void ProcessRequest()
        {
            Console.WriteLine("User story4");
            CheckBannedWords();
            Console.WriteLine("Total Number of negative words: " + badWords);
            Console.WriteLine("Original text:");
            Console.WriteLine(Content.content);
        }
    }
    public class AdministratorCase : BaseClass
    {
        public void AddBannedWords(string word)
        {
            BannedWords.AddBannedWords(word);
        }
        public string BannedWordsLists()
        {
            string list = string.Empty;
            foreach (string word in BannedWords.GetBannedWordList())
            {
                list = list + word + "\n";
            }
            return list;
        }
        public override void ProcessRequest()
        {
            Console.WriteLine("User story2");
            CheckBannedWords();
            Console.WriteLine("list of negative words - "+BannedWordsLists());
            Console.WriteLine("Want to add a new negative word? Y/N ");
            string ret = Console.ReadLine();
            if (ret == "Y")
            {
                Console.WriteLine("enter a new negative word- ");
                string negativeword = Console.ReadLine();
            
                AddBannedWords(negativeword);
            }
            CheckBannedWords();
            Console.WriteLine("Total Number of negative words: " + badWords);
        }
    }

    public class ReaderCase : BaseClass
    {       
        string contentReader = Content.content;
        
        public string GetReaderContent()
        {
            foreach (var bannedWord in BannedWords.GetBannedWordList())
            {
                if (contentReader.Contains(bannedWord))
                {                    
                    string hashtext =new String('#', bannedWord.Length - 2);
                    string replacement = bannedWord.Substring(0, 1) + hashtext + bannedWord.Substring(bannedWord.Length - 1, 1);
                    contentReader = contentReader.Replace(bannedWord, replacement);
                }
            }
            return contentReader;

        }
        public override void ProcessRequest()
        {
            Console.WriteLine("User story3");
            Console.WriteLine("Scanned the text:");
            string readerContent = GetReaderContent();
            Console.WriteLine(readerContent);
        }
    }
}
