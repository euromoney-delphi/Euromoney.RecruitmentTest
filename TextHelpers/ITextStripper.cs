using System.Collections.Generic;

namespace ContentConsole
{
    public interface ITextStripper
    {
        string StripText(string text, bool stripPunctuation = true, IEnumerable<char> charsToStrip = null);
    }
}