using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Persistence
{

    /// <summary>
    /// TODO: Supoused to be the real repostory implementation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Repositroy<T>: IRepository<T>
    {

        public IEnumerable<T> FindAll()
        {
            throw new NotImplementedException();
        }

        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

    }
}
