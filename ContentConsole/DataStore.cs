using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentConsole
{
    public class DataStore
    {
        private List<string> _bannedWords = new List<string> { "swine", "bad", "nasty", "horrible" };

        public List<string> BannedWords
        {

            get => _bannedWords;

            set => _bannedWords = value;
        }

    }
}
