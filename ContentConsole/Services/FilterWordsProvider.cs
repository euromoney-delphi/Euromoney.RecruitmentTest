using System.Collections.Generic;

namespace ContentConsole.Services
{
    public interface IFilterWordsProvider
    {
        IList<string> BadWordsList { get; }
    }

    public class FilterWordsProvider : IFilterWordsProvider
    {
        public IList<string> BadWordsList { get; }

        public FilterWordsProvider(IList<string> badWordsList)
        {
            BadWordsList = badWordsList;
        }
    }
}