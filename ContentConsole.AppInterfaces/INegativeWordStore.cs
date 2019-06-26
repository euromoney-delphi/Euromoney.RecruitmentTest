using System.Collections.Generic;

namespace ContentConsole.AppInterfaces
{
    public interface INegativeWordStore
    {
        IList<string> GetAll();
        void Add(string negativeWord);
        char[] GetSeparators();
    }
}