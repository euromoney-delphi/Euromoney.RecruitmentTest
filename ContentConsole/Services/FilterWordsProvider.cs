using System.Collections.Generic;

namespace ContentConsole.Services
{
    public interface IFilterWordsProvider
    {
        IList<string> FilterWordsList { get; }
    }

    public class FilterWordsProvider : IFilterWordsProvider
    {
        public IList<string> FilterWordsList { get; }

        public FilterWordsProvider(IList<string> filterWordsList)
        {
            FilterWordsList = filterWordsList;
        }
    }
}