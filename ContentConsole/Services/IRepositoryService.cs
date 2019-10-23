using System.Collections.Generic;

namespace ContentConsole.Services
{
    public interface IRepositoryService<T> : IEnumerable<T>
    {
        void Add(T item);
        bool Remove(T item);
    }
}