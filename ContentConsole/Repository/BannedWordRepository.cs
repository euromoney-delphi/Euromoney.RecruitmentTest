using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentConsole.Repository
{
    public class BannedWordRepository : IRepository<string>
    {
        public virtual IList<string> GetAll()
        {
            return new List<string>()
            {
                "swine",
                "bad",
                "nasty",
                "horrible"
            };
        }
    }
}
