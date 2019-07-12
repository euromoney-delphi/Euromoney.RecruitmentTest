using System.Collections.Generic;

namespace ContentConsole
{
    public interface IWordScanner
    {
        int CountBannedWords(string text);
    }
}