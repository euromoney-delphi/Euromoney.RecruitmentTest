namespace Domain
{
    public interface IUserReport
    {
        int NegativeWordCount { get; }
        string OriginalText { get; }
    }
}