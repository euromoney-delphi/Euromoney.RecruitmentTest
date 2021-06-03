using Application.Interfaces;
using System.Collections.Generic;

namespace Persistence
{
    public class BannedWordRepository : IBannedWordRepository
    {
        public HashSet<string> Get()
        {
            return new HashSet<string>()
            {
                "swine",
                "bad",
                "nasty",
                "horrible"
            };
        }
    }
}
