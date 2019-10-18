using System.Linq;
using System.Text.RegularExpressions;

namespace ContentConsole.Services
{
    public class TextFilterService
    {
        private readonly IFilterWordsProvider _badWordsProvider;

        public TextFilterService(IFilterWordsProvider badWordsProvider)
        {
            _badWordsProvider = badWordsProvider;
        }

        public TextFilterResult AnalyseText(string content)
        {
            if (string.IsNullOrEmpty(content))
                return new TextFilterResult { NumberOfFilteredWordsFound = 0, FilteredContent = content };
            var pattern = string.Join("|", _badWordsProvider.FilterWordsList.Select(Regex.Escape));
            var match = Regex.Matches(content, pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            var newContent = Regex.Replace(content,
                pattern,
                matchedWord =>
                    $"{matchedWord.Value.First()}{string.Join(string.Empty, Enumerable.Repeat("*", matchedWord.Length - 2))}{matchedWord.Value.Last()}");
            return new TextFilterResult { NumberOfFilteredWordsFound = match.Count, FilteredContent = newContent };
        }
    }

    public class TextFilterResult
    {
        public int NumberOfFilteredWordsFound { get; set; }
        public string FilteredContent { get; set; }
    }
}
