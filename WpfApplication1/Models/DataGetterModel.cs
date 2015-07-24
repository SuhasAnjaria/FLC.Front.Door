using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using flc.FrontDoor.Data;
using flc.FrontDoor.ViewModels;
using flc.FrontDoor.FacadeService;
using flc.FrontDoor.Models.Interfaces;
using System.Globalization;

namespace flc.FrontDoor.Models
{
    class Instrumentlist : IInstrumentDataGetter
    {
        public List<Instrument> InstrumentMaster = new List<Instrument>();

        public Instrumentlist()
        {
            this.GetData();
        }

        public object GetData(params object[] input)
        {
            try
            {
                using (FacadeServiceClient session = new FacadeServiceClient())
                {
                    InstrumentDTO[] tickers = (InstrumentDTO[])session.GetInstruments();

                    TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
                    var _Action = new Action<InstrumentDTO>((o) => DoSomething(o));
                    Parallel.ForEach(tickers, _Action);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return InstrumentMaster;
        }
        private void DoSomething(InstrumentDTO ticker)
        {
            lock (this.InstrumentMaster)
            {
                
                var A = new Instrument
                {
                    Name = ticker.FLCTicker,
                    AssetType = (AssetType)Enum.Parse(typeof(AssetType), ticker.AssetType, true),
                    ProductType = ticker.ProductType,
                    Currency = (Currency)Enum.Parse(typeof(Currency), ticker.Currency, true),
                   // BbgCode = ticker.BloombergTicker,
                    //DqCode = ticker.DataQueryTicker,
                    Underlying =ticker.Underlying,
                    AvailableFeatures = ticker.Fields.Select(c => (Features)Enum.Parse(typeof(Features), c, true)).ToList()

                };
                this.InstrumentMaster.Add(A);
            }
        }

       
    }
}
