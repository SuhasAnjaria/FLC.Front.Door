using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace flc.FrontDoor.Data
{
   /* public enum ProductBase
    {
        [Display(Description="Interest Rate Swap")]
        InterstRateSwap
        ,
        [Display(Description = "Basis Swap")]
        BasisSwap
        ,
        [Display(Description = "Interest Rate Cap(let)")]
        IntrestRateCap
        ,
        [Display(Description = "Swaption")]
        Swaption
        ,

        [Display(Description = "Interest Rate Floor(let)")]
        Floor
        ,
        [Display(Description = "FX Rate Swap")]
        FXSwap
        ,
        [Display(Description = "Credit Default Swap")]
        CDS
        ,
       [Display(Description = "Option")]
        Option
        ,
       [Display(Description = "Future Contract")]
        Future
        ,
        [Display(Description = "Forward Contract")]
        Forward
        ,

    }*/

    
    public enum AssetType
    {
        Rates,
        FX,
        Credit,
        Econ
    }

    public enum IndexDescriptor
    {
        [Display(Description = "Curve with a Tenor")]
        Curve  ,

        [Display(Description = "Time Series object with Values for Time frame")]
        TimeSeries
    }
    public enum Currency
    {
        USD,
        EUR,
        JPY,
        AUD,
        SEK,
        NOK,
        GBP
    }

    public enum Features
    {
        PayerPremium,
        Premium,
        ReceiverPremium,
        Price,
        Value,
        Volatility,
        LastTradeDate,
        ImpBPVol,
        ImpYldVol,
        ForwardRate,
        Rate,
        DVO1,
        PnL,
        Delta,
        Vega,
        Gamma,
        Rho,
        Duration,
        Convexity,
        Mid,
        Level,
        Close

        //Add More Features
    }

    /// <summary>
    /// The Index Definition must be defined for each Index. An index is any financial product
    /// </summary>
   
    public class Instrument
    {

        #region Fields

        // Fields...
        private List<string> _dqCode;
        private List<string> _bbgCode;
        private List<Features> _features;
        private string _productType;
        private Currency _currency;
        private AssetType _assettype;
        private string _name;
        private string _underlying;
        #endregion

       #region Properties
       // public properties...
       public string Name
       {
           get { return this._name; }
           set { this._name = value; }
       }

       public AssetType AssetType
       {
           get { return this._assettype; }
           set { this._assettype = value; }
       }

       public Currency Currency
       {
           get { return this._currency; }
           set { this._currency = value; }
       }

       public string ProductType
       {
           get { return this._productType; }
           set { this._productType = value; }
       }

       public List<Features> AvailableFeatures
       {
           get { return this._features; }
           set { this._features = value; }
       }

       public List<string> BbgCode
       {
           get { return this._bbgCode; }
           set { this._bbgCode = value; }
       }
        
        public List<string> DqCode
        {
        	get {	return _dqCode; }
        	set { _dqCode = value;	}
        }
        public string Underlying
        {
            get { return this._underlying; }
            set { this._underlying = value; }
        }

       #endregion

   
           /* •—————————————————————————————————————————————•
              | | Example Instrument                    | |
              | |                                       | |
              | | Name = LiborUSD1m3mSpread;            | |
              | | AssetType = Rate;                     | |
              | | ProductType = Swap;                   | |
              | | Currency = USD;                       | |
              | | AvailableFeatures = {Price,DVO1,Vol}; | |
              | | BbgCode = USDLIBOR1m;                 | |
              | | DqCode =  DqABC123;                   | |
              | | Underlying = Libor1m                  | |
              •—————————————————————————————————————————————• */
          
  }

    public class Featurelist
    {
        public static List<Features> GetFeatureList( AssetType assettype)
        {
            switch (assettype.ToString())
            {
                case "Swap":
                    return new List<Features>(){ Features.Price, Features.Rate, Features.DVO1, };
                case "Swaption":
                    return new List<Features>(){ Features.PayerPremium, Features.Rate, Features.Volatility, Features.DVO1, Features.Rate, Features.Gamma };
                default:
                    return null;
            }
        }
    }

}
