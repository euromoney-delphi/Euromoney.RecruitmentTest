using EuroMoney.Core.Model;

namespace EuroMoney.Service
{
    public interface ITextService
    {
        TextResult FilterBannedWords(string data, bool isFilteringEnabled);
    }
}