using NegativeContentService.Models;

namespace NegativeContentService
{
    public interface IDetectNegativeWordService
    {
        ContentAnalysisResult GetDetectedNegativeContentAnalysis(string content);
    }
}