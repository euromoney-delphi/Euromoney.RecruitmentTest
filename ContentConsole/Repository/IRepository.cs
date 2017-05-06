using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentConsole.Repository
{
    public interface IRepository<T>
    {
        IList<T> GetAll();
    }
}
