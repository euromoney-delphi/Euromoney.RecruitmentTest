using System.Collections.Generic;

namespace ContentConsole.AppInterfaces
{
    public interface IAdminInteraction
    {
        string GetNewNegativeWord(IList<string> negativeWords);
    }
}