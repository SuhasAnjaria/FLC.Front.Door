using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flc.FrontDoor.Models.Interfaces
{
    interface IProcessLocator
    {
        void CreateScope();
        T GetProcessor<T>();
        void ReleaseScope();
    }
}
