using System;
using System.Collections.Generic;
using System.Linq;
using ContentConsole.Services;

namespace ContentConsole.Models
{
    public class Phrase
    {
        private readonly string _original;
        private readonly List<PhrasePart> _phraseParts = new List<PhrasePart>();
        public IEnumerable<PhrasePart> PhraseParts => _phraseParts.ToArray();

        public Phrase(string original)
        {
            _original = original;
        }

        public void AddPhrasePart(PhrasePart part)
        {
            _phraseParts.Add(part);
        }

        public override string ToString()
        {
            return PhraseParts.Aggregate(string.Empty, (current, part) => current + part.Part);
        }

        public int TotalFilteredWords
        {
            get
            {
                return PhraseParts.Where(part => part is FilteredPhrasePart).Cast<FilteredPhrasePart>()
                    .Count(filteredPart => filteredPart.IsFilteredWord);
            }
        }

        public string Original => new string(_original.ToCharArray());
    }
}
