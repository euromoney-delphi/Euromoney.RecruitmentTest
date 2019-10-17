using System.Collections.Generic;

namespace EuroMoney.Core.Model
{
    public class TextResult
    {
        public int BadWordsCount { get; set; }
        public IList<string> BannedWords { get; set; }

        public string OriginalText { get; set; }

        public string DisplayText { get; set; }

    }
}
