using System;
using System.Collections.Generic;
using System.Text;
using ContentConsole.AppInterfaces;

namespace ContentConsole.AppServices
{
    public class AdminInteraction : IAdminInteraction
    {
        public string GetNewNegativeWord(IList<string> negativeWords)
        {
            var stringBuilder = new StringBuilder()
                .AppendLine("\nAdd A New Word To The Below Negative Word List:")
                .AppendLine("-----------------------------------------------")
                .AppendLine(string.Join(",", negativeWords))
                .AppendLine("-----------------------------------------------")
                .Append("=>");

            Console.Write(stringBuilder.ToString());

            string newWord = Console.ReadLine();

            return newWord;
        }
    }
}