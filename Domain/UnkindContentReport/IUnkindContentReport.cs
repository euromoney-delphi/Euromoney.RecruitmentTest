namespace Domain.UnkindContentReport
{
    public interface IUnkindContentReport
    {
        int NegativeWordCount { get; }
        string OriginalText { get; }
    }
}