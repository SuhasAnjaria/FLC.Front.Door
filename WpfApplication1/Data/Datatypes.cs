
namespace flc.FrontDoor.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
/// <summary>
    /// Basic DataType for plotting
    /// </summary>
    public class XYPoint
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

    /// <summary>
    /// Series to be passed on to the plotting function
    /// </summary>
    public class DoubleSeries : List<XYPoint>
    {
        public DoubleSeries()
        {

        }

        public  DoubleSeries(int capacity)
            : base(capacity)
        {

        }

        public IList<double> XData { get { return this.Select(x => x.X).ToArray(); } }
        public IList<double> YData { get { return this.Select(x => x.Y).ToArray(); } }

    }

}
