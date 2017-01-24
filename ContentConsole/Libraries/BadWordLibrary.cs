using System.Collections.Generic;
using ContentConsole.Models;

namespace ContentConsole.Libraries
{
    public class BadWordLibrary
    {
        public BadWordLibrary()
        {
            BadWords = new List<BadWord>();
        }
        public List<BadWord> BadWords { get; set; }
    }
}