using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace flc.FrontDoor.Models.Interfaces
{
    interface IDataGetter
    {
        object GetData( params object[] input );
    }

    interface IInstrumentDataGetter: IDataGetter
    {

    }

    
}
