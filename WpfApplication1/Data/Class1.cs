using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace flc.FrontDoor.Data
{
    class GridPoint
    {
       public string GridHeader { get; set; }
        public double Value { get; set; }

    }

    class GridRow : ObservableCollection<GridPoint> { }

    class FullGrid : ObservableCollection<GridRow> { }

 
    
   
}
