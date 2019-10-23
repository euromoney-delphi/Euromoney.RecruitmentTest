using System.Collections.Generic;

namespace ContentConsole.Models
{
    public interface IPhrase
    {
        IEnumerable<IPhrasePart> PhraseParts { get; }
        int TotalFilteredWords { get; }
        string Original { get; }
        void AddPhrasePart(IPhrasePart part);
        string ToString();
    }
}