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

    public enum IndexDescriptor
    {
        [Display(Description = "Curve with a Tenor")]
        Curve  ,

        [Display(Description = "Time Series object with Values for Time frame")]
        TimeSeries
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


}
