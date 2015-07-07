using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace flc.FrontDoor.Data
{
    public enum ProductBase
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

    }

    public enum AssetType
    {
        Rates,
        FX,
        Credit
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
        NOK
    }

    public enum Features
    {
        
        Price,
        Value,
        Volatility,
        Rate,
        DVO1,
        PnL,
        Delta,
        Vega,
        Gamma,
        Rho,
        Duration,
        Convexity,

        //Add More Features
    }

    /// <summary>
    /// The Index Definition must be defined for each Index. An index is any financial product
    /// </summary>
    public class InstrumentDefinition
    {


        /// <summary>
        /// Instrument Name
        /// </summary>
       public string name;
        /// <summary>
        /// The descriptor of type Curve or Time Series
        /// </summary>
        IndexDescriptor descriptor;
        /// <summary>
        /// The features the Instrument can carry
        /// </summary>
        List<Features> Features;



        /// <summary>
        /// The Bloomberg ID
        /// </summary>
      public  string bbgtickr;
        /// <summary>
        /// The Data Query ID
        /// </summary>
        string dqtickr;
        /// <summary>
        /// The FLC in-house ID
        /// </summary>
        /// 
     public   string fcltickr;



        /// <summary>
        /// The Base Currency in which the Instrument is quoted. 
        /// </summary>
        string basecurrency;

        /// <summary>
        /// The Optional Quoted Currency
        /// </summary>
        string quotedcurrency;

        /// <summary>
        /// The Optional replicating strategy
        /// </summary>
      //  Dictionary<Instrument,double> replicatingstrategy;
    }

    public class Instrument
    {

        #region Fields

        // Fields...
        private string _bbgCode;
        private List<Features> _features;
        private string _productType;
        private Currency _currency;
        private AssetType _assettype;
        private string _name;
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

       public string BbgCode
       {
           get { return this._bbgCode; }
           set { this._bbgCode = value; }
       }
       #endregion

       #region Public Overrrides
       //public override string ToString()
       //{
       //    return Name;
       //}

       #endregion

    }

}
