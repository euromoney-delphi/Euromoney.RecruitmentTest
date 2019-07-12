using System.Collections.Generic;

namespace ContentConsole.Data
{
    public interface IBannedWordsRepository
    {
        void Add(params string[] bannedWords);
        IReadOnlyCollection<string> Get();
    }
}