using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentConsole
{
    public class BadWordList
    {
        public List<String> BadWords { get; set; }

        public BadWordList()
        {
            BadWords = new List<string>();
            this.BadWords.Add("swine");
            this.BadWords.Add("bad");
            this.BadWords.Add("nasty");
            this.BadWords.Add("horrible");
        }
    }
}
