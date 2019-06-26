using System;
using System.Text;
using ContentConsole.AppInterfaces;

namespace ContentConsole.AppServices
{
    public class UserInteraction : IUserInteraction
    {
        public string GetTextInput()
        {
            var stringBuilder = new StringBuilder()
                .AppendLine("\nEnter The Content For Scanning:")
                .AppendLine("---------------------------------")
                .Append("=>");

            Console.Write(stringBuilder.ToString());

            string textInput = Console.ReadLine();
            return textInput;
        }

        public void OutputTotalNegativeWordsToScreen(int negativeWordCount)
        {
            Console.WriteLine("\nTotal number of negative words: " + negativeWordCount);
        }

        public void PressAnyKeyToExit()
        {
            Console.WriteLine("\nPress ANY key to exit.");
            Console.ReadKey();
        }

        public void OutputScannedText(string textInput)
        {
            Console.WriteLine("\nScanned the text:");
            Console.WriteLine(textInput);
        }
    }
}