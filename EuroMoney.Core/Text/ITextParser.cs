using System.Collections.Generic;
using EuroMoney.Core.Model;

namespace EuroMoney.Core.Text
{
    public interface ITextParser
    {
        TextResult Filter(string inputData, IList<string> bannedWords);
        string GetHashedString(string data, char hasher);
    }
}