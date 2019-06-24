using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentConsole
{
    class WordAnalizer
    {
        public static int CountBadWords(string content, List<string> badWords)
        {
            return badWords.Count(x => content.ToLower().Split(' ').Contains(x.ToLower()));
        }
    }
}
