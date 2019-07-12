using System.Collections.Generic;

namespace ContentConsole
{
    public interface IPunctuationStripper
    {
        string StripPunctuation(string text, bool stripPunctuation = true, IEnumerable<char> charsToStrip = null);
    }
}