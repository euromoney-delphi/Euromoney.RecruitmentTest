using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UserReport : IUserReport
    {
        public string OriginalText { get; private set; } = "test text";
        public int NegativeWordCount { get; private set; }
    }
}
