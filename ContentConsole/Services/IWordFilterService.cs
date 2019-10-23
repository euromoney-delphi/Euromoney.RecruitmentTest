using ContentConsole.Models;

namespace ContentConsole.Services
{
    public interface IWordFilterService
    {
        FilteredPhrasePart FilterPart(PhrasePart part);
    }
}