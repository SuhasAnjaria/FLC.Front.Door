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
                    var _Action = new Action<InstrumentDTO>((o) => DoSomething(o));
                    Parallel.ForEach(tickers, _Action);
                }
            }
            catch 
            {
               
            }

            return InstrumentMaster;
        }
        private void DoSomething(InstrumentDTO ticker)
        {
            
            {
                
                var A = new Instrument
                {
                    Name = ticker.FLCTicker,
                    
                    AssetType = (AssetType)Enum.Parse(typeof(AssetType), ticker.AssetType, true),
                    ProductType = ticker.ProductType,
                    Currency = (Currency)Enum.Parse(typeof(Currency), ticker.Currency, true),
                    BbgCode = ticker.BloombergTickers.ToList(),
                    DqCode = ticker.DataQueryTickers.ToList(),
                    Underlying =ticker.Underlying,
                    AvailableFeatures = ticker.Fields.Select(c => (Features)Enum.Parse(typeof(Features), c, true)).ToList()


                };
                if (A.Name.Contains("USD.Swap.Libor3m"))
                {
                 if(A.AvailableFeatures.Count>1)
                 {
                     int j;
                 }
                }

                lock (this.InstrumentMaster)
                {
                    this.InstrumentMaster.Add(A);
          
                }
            }
        }

       
    }
}
