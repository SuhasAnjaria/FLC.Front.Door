using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace flc.FrontDoor.Common
{
    interface ISelectable
    {
        ICommand SelectCommand { get; set; }
    }
}
