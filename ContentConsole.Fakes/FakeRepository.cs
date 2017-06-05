using System.Collections.Generic;
using Domain;

namespace ContentConsole.Fakes
{
    public class FakeRepository<T>: IRepository<T>
    {
        private static readonly List<T> Items = new List<T>();

        public IEnumerable<T> FindAll()
        {
            return Items;
        }

        public void Add(T entity)
        {
            Items.Add(entity);
        }
        
    }
}
