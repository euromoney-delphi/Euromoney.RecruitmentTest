using System.Collections.Generic;
using NegativeContentService.Data;

namespace ContentConsole.TestFixtures
{
    public class StubNegativeWordRepository : INegativeWordRepository
    {
        private readonly IList<string> _injectStubTestData;

        public StubNegativeWordRepository(IList<string> injectStubTestData)
        {
            _injectStubTestData = injectStubTestData;
        }

        public IList<string> GetAllNegativeWords()
        {
            return _injectStubTestData;
        }
    }
}