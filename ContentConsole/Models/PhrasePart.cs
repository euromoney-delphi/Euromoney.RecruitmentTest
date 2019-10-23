using System;

namespace ContentConsole.Models
{
    public class PhrasePart
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

    public class FilteredPhrasePart : PhrasePart
    {
        private string _originalPart;
        public FilteredPhrasePart(string originalPart, bool isWord, bool isFilteredWord, string part)
        {
            OriginalPart = originalPart;
            Part = part;
            IsWord = isWord;
            IsFilteredWord = isFilteredWord;
        }

        public bool IsFilteredWord { get; set; }
        public string OriginalPart
        {
            get => _originalPart ?? Part;
            private set => _originalPart = value;
        }
    }
}