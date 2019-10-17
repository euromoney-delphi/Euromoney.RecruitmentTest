using EuroMoney.Core.Model;
using EuroMoney.Core.Text;
using EuroMoney.Data;

namespace EuroMoney.Service
{
    public class TextService : ITextService
    {
        private readonly ITextParser textParser;
        private readonly ITextRepository textRepository;

        public TextService(ITextParser textParser, ITextRepository textRepository)
        {
            this.textParser = textParser;
            this.textRepository = textRepository;
        }

        public TextResult FilterBannedWords(string data, bool isFilteringEnabled)
        {
            if (!isFilteringEnabled)
                return new TextResult { BadWordsCount = 0, DisplayText = data, OriginalText = data };
            return textParser.Filter(data, textRepository.GetBannedWords());
        }

    }
}
