using System.Collections.Generic;

namespace Domain
{
    public interface IRepository<T>
    {

        IEnumerable<T> FindAll();

        void Add(T entity);

    }
}
