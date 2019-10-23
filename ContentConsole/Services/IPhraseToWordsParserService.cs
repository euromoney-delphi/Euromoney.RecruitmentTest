using System;
using ContentConsole.Models;

namespace ContentConsole.Services
{
    public interface IPhraseToWordsParserService
    {
        Phrase Parse(string original, IWordFilterService wordFilterService);
    }
}
