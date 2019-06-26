using System;
using System.Text;
using ContentConsole.AppInterfaces;

namespace ContentConsole.AppServices
{
    public class ConsoleInteraction : IConsoleInteraction
    {
        public void ClearScreen()
        {
            Console.Clear();
        }

        public char GetMenuSelection()
        {
            return Console.ReadKey().KeyChar;
        }

        public void ShowRoleMenu()
        {
            var stringBuilder = new StringBuilder()
                .AppendLine("-----------------")
                .AppendLine("Select your role:")
                .AppendLine("-----------------")
                .AppendLine("[1] User")
                .AppendLine("[2] Admin")
                .AppendLine("[x] Press ANY key to exit.")
                .AppendLine("-----------------")
                .Append("=>");

            Print(stringBuilder.ToString());
        }

        public void Print(string outputText)
        {
            Console.Write(outputText);
        }

        public bool Quit { get; set; } = false;
    }
}