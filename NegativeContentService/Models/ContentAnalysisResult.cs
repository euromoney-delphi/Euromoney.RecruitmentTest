namespace NegativeContentService.Models
{
    public class ContentAnalysisResult
    {
        public string OriginalContent { get; set; }
        public int NumberOfBadWords { get; set; }
        public string SanitizedContent { get; set; }
    }
}