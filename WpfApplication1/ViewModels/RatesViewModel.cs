namespace flc.FrontDoor.ViewModels
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using flc.FrontDoor.Assets;
    using FrontDoor.Data;
    using flc.FrontDoor.Models;
    using GalaSoft.MvvmLight.Command;
    using System.Collections.ObjectModel;
    using System.Windows.Controls.Primitives;
    using Framework.UI;
    using flc.FrontDoor;
    using Autofac;

    public class RatesViewModel : BaseViewModel
    {

        public delegate void NewHandled(RatesViewModel sender, GridEventArgs e);
        public event NewHandled GridDataAdded;

        private DateTime _date;
        private RelayCommand<object> _productSelectedCommand;
        private RelayCommand<object> _attributeSelectedCommand;
        private RelayCommand<object> _gridSelectionChangedCommand;
        private RelayCommand _refreshCommand;

        public RelayCommand<object> ProductSelectedCommand
        {
            get
            {
                if (this._productSelectedCommand == null)
                {
                    this._productSelectedCommand = new RelayCommand<object>(AssignProduct);
                    return this._productSelectedCommand;
                }
                else
                {
                    return this._productSelectedCommand;
                }

            }

        }
        public RelayCommand<object> AttributeSelectedCommand
        {
            get
            {
                if (this._attributeSelectedCommand == null)
                {
                    this._attributeSelectedCommand = new RelayCommand<object>(AssignAttribute);
                    return this._attributeSelectedCommand;
                }

                return _attributeSelectedCommand;
            }
        }
        public RelayCommand<object> GridSelectionChangedCommand
        {
            get
            {
                if (this._gridSelectionChangedCommand == null)
                {
                    this._gridSelectionChangedCommand = new RelayCommand<object>(GridChanged);
                    return this._gridSelectionChangedCommand;
                }

                return this._gridSelectionChangedCommand;
            }
        }
        public RelayCommand RefreshGridCommand
        {
            get
            {
                if (this._refreshCommand == null)
                {
                    this._refreshCommand = new RelayCommand(RefreshGrid);
                    return this._refreshCommand;
                }

                return this._refreshCommand;
            }
        }


        // Fields...

        private string _feature = null;
        private Instrument _selectedInstrument;
        private bool _doesGridDisplay;
        private ObservableCollection<dynamic> _matrixArgs = new ObservableCollection<dynamic>();

        public Instrument Instrument
        {
            get { return _selectedInstrument; }
            set { this.SetProperty(ref this._selectedInstrument, value); }
        }
        public string Feature
        {
            get { return this._feature; }
            set { this.SetProperty(ref this._feature, value); }
        }
        private void AssignAttribute(object obj)
        {
            if (obj != null)
            {
                Feature = obj.ToString();


            }
        }
        private void AssignProduct(object obj)
        {
            if (obj != null)
            {

                Instrument = (Instrument)obj;
                GridDataAdded(this, new GridEventArgs(this.Instrument.Currency.ToString(),
                                        this.Instrument.ProductType,
                                        this.Instrument.Underlying,
                                        this.Feature,
                                        this.Date));
            }
        }

        private void RefreshGrid()
        {
            if (this.Instrument.Name != null)
            {
                
                GridDataAdded(this, new GridEventArgs(this.Instrument.Currency.ToString(),
                                   this.Instrument.ProductType,
                                   this.Instrument.Underlying,
                                   this.Feature,
                                   this.Date));
            }

        }
        private void GridChanged(object obj)
        {
            TypeSwitch.Do(obj,
                TypeSwitch.Case<string>((x) =>
                {
                    //TODO:
                }),
                TypeSwitch.Case<DataGridColumnHeader>(x =>
                {
                    //TODO:
                }));
        }
        public bool DoesGridDisplay
        {
            get { return _doesGridDisplay; }
            set { this.SetProperty(ref this._doesGridDisplay, value); }
        }

        public DateTime Date
        {
            get { return _date; }
            set { this.SetProperty(ref this._date, value); }
        }

        public ObservableCollection<dynamic> MatrixArgs
        {
            get { return _matrixArgs; }
            set { this.SetProperty(ref this._matrixArgs, value); }
        }

        public RatesViewModel()
        {
            var A = Models.ModelBuilder.ModelContainer.Resolve<RatesMatrixModel>();
            this.GridDataAdded += A.RatesViewModel_GridDataAdded;
            

            this.Date = DateTime.Today;

        }

        public class GridEventArgs
        {
            public string Underlying { get; set; }
            public string Currency { get; set; }
            public DateTime Date { get; set; }
            public string Feature { get; set; }
            public string ProductType { get; set; }
            /// <summary>
            /// Initializes a new instance of the GridEventArgs class.
            /// </summary>
            public GridEventArgs(string currency, string producttype, string underlying, string feature, DateTime date)
            {
                Currency = currency;
                Underlying = underlying;
                Date = date;
                Feature = feature;
                ProductType = producttype;
            }
        }

    }
}