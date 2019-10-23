using System;

namespace ContentConsole.Models
{
    public class PhrasePart : IPhrasePart
    {

        public PhrasePart(char firstChar)
        {
            Part += firstChar;
            IsWord = IsWordCharacter(firstChar);
        }

        protected PhrasePart()
        {
        }
        public string Part { get; protected set; } = string.Empty;
        public bool IsWord { get; protected set; }

        public void AddChar(char newChar)
        {
            Part += newChar;
        }

        internal static bool IsWordCharacter(char c)
        {
            return char.IsLetterOrDigit(c);
        }

        public override string ToString()
        {
            return Part;
        }
    }
}