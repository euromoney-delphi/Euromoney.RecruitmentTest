using System.Linq;
using NegativeContentService.Models;

namespace NegativeContentService
{
    public class DetectNegativeWordService : IDetectNegativeWordService
    {
        public ContentAnalysisResult GetDetectedNegativeContentAnalysis(string content)
        {
            var bannedWords = new[] {"swine", "bad", "nasty", "horrible"};

            var numberOfBadWords = bannedWords.Count(content.Contains);
            return new ContentAnalysisResult { OriginalContent = content, NumberOfBadWords = numberOfBadWords };
        }
    }
}
