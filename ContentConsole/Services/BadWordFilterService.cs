using System;
using System.Linq;
using ContentConsole.Models;

namespace ContentConsole.Services
{
    public class BadWordFilterService : IWordFilterService
    {
        private readonly IStringRepositoryService _badWordStringRepositoryService;

        public BadWordFilterService(IStringRepositoryService badWordStringRepositoryService)
        {
            _badWordStringRepositoryService = badWordStringRepositoryService;
        }

        public FilteredPhrasePart FilterPart(PhrasePart part)
        {
            var isBadWord = _badWordStringRepositoryService.Contains(part.Part.ToLowerInvariant());
            var filteredPart = isBadWord ? CensorString(part.Part) : part.Part;

            return new FilteredPhrasePart(part.Part, part.IsWord, isBadWord, filteredPart);
        }

        private string CensorString(string source)
        {
            var censoredCharCount = source.Length - 2;
            if (censoredCharCount < 0) censoredCharCount = 0;
            return source[0] + new string('#', censoredCharCount) + source.Last();
        }
    }
}
