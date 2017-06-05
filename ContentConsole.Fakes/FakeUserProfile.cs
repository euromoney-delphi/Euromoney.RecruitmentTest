using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContentConsole.Words;

namespace ContentConsole.Fakes
{
    public class FakeUserProfile : IUserProfile
    {
        public bool IsAdministrator()
        {
            return true;
        }

        public bool IsReader()
        {
            return true;
        }

        public bool IsContentCurator()
        {
            return false;
        }
    }
}
