using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentConsole.Words
{
    public interface IWordsFactory
    {

        IWordsFactory Init(string phrase);

        IWordsFactory WithWordFound(string wordFound);

        IWordsFactory WithPretify(char replacement);

        WordResponse Create();

    }
}
