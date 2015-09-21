using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using flc.FrontDoor.Data;
using Framework.ComponentModel;


namespace flc.FrontDoor.ViewModels
{
    public class PricerViewModel
    {

    }

    public class RatesPricerObject:NotifyDataErrorInfo<RatesPricerObject>,IPricedObject
    {
        private bool _isaggregated;
        private RatesProductType _ratesProductType;
        private Currency _currency;
        private string _notional;
        private double _fwdrate;
        private double _pvbps;
        private double _volbpnorm;
        private double _vol;
        private double _delta;
        private double _vega;
        private double _price;
        private ITradable _internaltradeobject;

        public bool IsAggregated
        {
            get { return this._isaggregated; }
            set { this.SetProperty (ref _isaggregated, value); }
        }


        public RatesProductType RatesProductType
        {
            get { return this._ratesProductType; }
            set { this.SetProperty (ref _ratesProductType, value); }
        }

        public Currency Currency
        {
            get { return this._currency; }
            set { this.SetProperty (ref _currency, value); }
        }

        public string Notional
        {
            get { return this._notional; }
            set { this.SetProperty (ref _notional, value, "_notional", "Doublenotional"); }
        }

        public double DoubleNotional
        {
            get { return ParseScientific (this._notional); }
        }

        public double PVbps
        {
            get { return this._pvbps; }
            set { this.SetProperty (ref _pvbps, value); }
        }

        public double VolBpNorm
        {
            get { return this._volbpnorm; }
            set { this.SetProperty (ref _volbpnorm, value); }
        }

        public double Vol
        {
            get { return this._vol; }
            set { this.SetProperty (ref _vol, value); }
        }

        public double Delta
        {
            get { return this._delta; }
            set { this.SetProperty (ref  _delta, value); }
        }

        public double Vega
        {
            get { return this._vega; }
            set { this.SetProperty (ref _vega, value); }
        }


        public double FwdRate
        {
            get { return this._fwdrate; }
            set { this.SetProperty (ref _fwdrate, value); }
        }

        private static double ParseScientific (string notional)
        {
            NumberFormatInfo info = new NumberFormatInfo {NumberDecimalSeparator = "."};
            double number;
            double.TryParse (notional, NumberStyles.Float, info, out number);
            return number;
        }
    }

    

    public enum RatesProductType
    {
        
        SWP,
        BSWP,
        SWPTN,
        MDSWPTN,
        BSSWPTN,
        CAP,
        FLR,
        EDF,
        EDOPTN,
        MDOPTN,
        SPDOPTN,
        GBND,
        GBNDOPTN,
        CASH,
        FVA

        
    }

    public interface IProductType
    {
    }


    public interface IPricedObject 
{
}

internal interface ITradable
{
}

    public interface IProductType<T>
    {
        IEnumerable<T> AvailableProducts { get; set; }
    }
}
