using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace ContentConsole.DataAccess
{
    public class FilterWordsRepository
    {
        public IList<string> LoadBadWordsFromRepo(string pathToRepo)
        {
            var entries = File.ReadAllText(pathToRepo);
            return JsonConvert.DeserializeObject<IList<string>>(entries);
        }
    }
}
