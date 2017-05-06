namespace ContentConsole
{
    public interface IWordFilter
    {
        bool EnableClean { get; set; }

        int Scan(string contentToScan);
        string Clean(string contentToClean, char maskChar);
    }
}