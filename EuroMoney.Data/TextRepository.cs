using System.Collections.Generic;
using System.Linq;

namespace EuroMoney.Data
{
    public class TextRepository : ITextRepository
    {
        private IList<string> _banndedWords = new List<string>();        

        public TextRepository()
        {
            //Note in real world app we will 
            //1. Make the methods Task based and async
            //2. fetch this data from the datbase in Get Method and not in constructor
            if (_banndedWords == null || !_banndedWords.Any())
                _banndedWords = new List<string>
                {
                    "swine",
                    "bad",
                    "nasty",
                    "horrible"
                };
        }
        public IList<string> GetBannedWords()
        {
            //Note: Fetch the BannedWords from DB in real App
            return _banndedWords;
        }

        public bool SaveBannedWords(IList<string> bannedWords)
        {
            //Note: Real world app save in db
            _banndedWords = bannedWords;
            return true; ;
        }
    }
}
