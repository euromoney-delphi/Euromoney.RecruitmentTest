namespace ContentConsole.Models
{
    public class FilteredPhrasePart : PhrasePart, IFilteredPhrasePart
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