using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegativeContentService.Data
{
    public interface INegativeWordRepository
    {
        IList<string> GetAllNegativeWords();
    }
}
