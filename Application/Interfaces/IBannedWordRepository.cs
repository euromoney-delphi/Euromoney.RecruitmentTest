using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IBannedWordRepository
    {
        HashSet<string> Get();
    }
}
