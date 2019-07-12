using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentConsole
{
    public class TextStripper : ITextStripper
    {
        public string StripText(string text, bool stripPunctuation = true, IEnumerable<char> charsToStrip = null)
        {
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;

            IEnumerable<char> output = null;

            output = stripPunctuation ? text.Where(c => !char.IsPunctuation(c)) : text;

            if (charsToStrip != null && charsToStrip.Any())
                output = output.Where(c => !charsToStrip.Contains(c));

            return new string(output.ToArray());
        }
    }
}
