using ContentConsole.Models;

namespace ContentConsole.Services
{
    public class PhraseToWordsParserService : IPhraseToWordsParserService
    {
        public Phrase Parse(string original, IWordFilterService wordFilterService)
        {
            if (string.IsNullOrWhiteSpace(original)) return new Phrase(string.Empty);
            var result = new Phrase(original);
            PhrasePart currentPart = null;
            foreach (char c in original)
            {
                if (currentPart == null || currentPart.IsWord != PhrasePart.IsWordCharacter(c))
                {
                    var previousPart = currentPart;
                    currentPart = new PhrasePart(c);
                    if (previousPart != null)
                    {
                        AddPhrasePart(result, previousPart, wordFilterService);
                    }
                }
                else
                {
                    currentPart.AddChar(c);
                }
            }
            AddPhrasePart(result, currentPart, wordFilterService);
            return result;
        }

        private void AddPhrasePart(Phrase source, PhrasePart part, IWordFilterService wordFilterService)
        {
            source.AddPhrasePart(wordFilterService.FilterPart(part));
        }
    }
}