using NegativeContentService.Models;

namespace NegativeContentService
{
    public interface IDetectNegativeWordService
    {
        ContentAnalysisResult GetNegativeContentAnalysis(string content);
    }
}