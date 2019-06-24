namespace ContentConsole
{
    public interface IContentFilter
    {
        string FilterContent(string content);
        int GetBadWordsCount(string content);
    }
}