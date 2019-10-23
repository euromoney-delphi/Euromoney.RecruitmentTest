using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace ContentConsole.Services
{
 
    // TODO: not a thread safe implementation
    [ExcludeFromCodeCoverage]
    public class StringRepositoryService : IStringRepositoryService
    {
        private readonly List<string> _repository;

        public StringRepositoryService(): this(new string[0])
        {
        }

        public StringRepositoryService(IEnumerable<string> initialData)
        {
            // ensure it is all lower case
            _repository = initialData.Select(s => s.ToLowerInvariant()).ToList();
        }

        public IEnumerator<string> GetEnumerator()
        {
            // Return copy of original list to prevent client manipulation
            return new List<string>(_repository).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(string item)
        {
            _repository.Add(item);
        }

        public bool Remove(string item)
        {
            return _repository.Remove(item);
        }
    }
}