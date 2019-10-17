using System.Collections.Generic;

namespace EuroMoney.Data
{
    public interface ITextRepository
    {
        IList<string> GetBannedWords();
        bool SaveBannedWords(IList<string> bannedWords);
    }
}