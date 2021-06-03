namespace Domain.UnkindContentReport
{
    public class UnkindContentReport : IUnkindContentReport
    {
        public UnkindContentReport(string originalText, int negativeWordCount)
        {
            OriginalText = originalText;
            NegativeWordCount = negativeWordCount;
        }
        public string OriginalText { get; private set; }
        public int NegativeWordCount { get; private set; }
    }
}
