using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentConsole.Words
{
    public interface IUserProfile
    {
        bool IsAdministrator();

        bool IsReader();

        bool IsContentCurator();
        
    }
}
