namespace ContentConsole
{
    public interface IWordScanner
    {
        int CountBannedWords(string text);
        int FilterBannedWords(string content, bool filterWords, out string filteredContent);
    }
}