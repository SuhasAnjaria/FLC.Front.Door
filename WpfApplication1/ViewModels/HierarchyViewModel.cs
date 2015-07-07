
namespace flc.FrontDoor.Data
{
    
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.ComponentModel;
using Framework.UI.Input;
using Framework.IO;
using System.Windows;
using flc.FrontDoor.ViewModels;
 using System.Windows.Data;
using System.Windows.Documents;

     #region Hierarchy Transformation Model
class HierarchyViewModel : BaseViewModel
    {
    
    public static Instrument _selectedInstrument;
    public static string _selectedProduct ;
    private List<Instrument> _products;


    public  string SelectedProduct
    {
        get {
            
            return _selectedProduct;
        
        }
        set 
        { if(value!=null)
            {
            //_selectedProduct = value;
            //OnPropertyChanged("SelectedProduct");
            this.SetProperty(() => _selectedProduct = value);
            }
         }
    }


    public  Instrument SelectedInstrument
    {
        get { return _selectedInstrument;
        
        }
        set
        {
            if (value != null)
            {
                //_selectedInstrument = value;
                //OnPropertyChanged("SelectedInstrument");
                this.SetProperty(() => _selectedInstrument = value);
            }
        }
    }

         public List<Instrument> Products
         {
             get { return this._products; }
             set { this.SetProperty(ref this._products, value); }

         }	
        		
        public static List<Instrument> products = new List<Instrument>{
                new Instrument{
                    Name = "OIS Swap", AssetType =AssetType.Rates,ProductType="Swap",Currency=Currency.USD ,
                    AvailableFeatures = new List<Features>{Features.Price,Features.Rate,Features.Volatility },},

                new Instrument{
                    Name = "Libor Swap", AssetType =AssetType.Rates,ProductType="Swap",Currency=Currency.USD,
                    AvailableFeatures = new List<Features>{Features.Price, Features.Rate, Features.Volatility}},

                new Instrument{
                    Name = "Libor Swaption", AssetType =AssetType.Rates,ProductType="Swaption",Currency=Currency.USD,
                    AvailableFeatures= new List<Features>{Features.Price, Features.Rate, Features.Volatility}},

                new Instrument{
                    Name = "Eunoia Swap", AssetType =AssetType.Rates,ProductType="Swap",Currency=Currency.EUR,
                AvailableFeatures= new List<Features>{Features.Price, Features.Rate, Features.Volatility}},

                new Instrument{
                    Name = "Libor Swap", AssetType =AssetType.Rates,ProductType="Swap",Currency=Currency.EUR,
                AvailableFeatures= new List<Features>{Features.Price, Features.Rate, Features.Volatility}},

                new Instrument{
                    Name = "Libor Swaption", AssetType =AssetType.Rates,ProductType="Swaption",Currency=Currency.EUR,
                    AvailableFeatures= new List<Features>{Features.Price, Features.Rate, Features.Volatility}},

                new Instrument{
                    Name = "OIS", AssetType =AssetType.Rates,ProductType="Cap",Currency=Currency.USD,
                    AvailableFeatures= new List<Features>{Features.Price, Features.Rate, Features.Volatility,Features.DVO1}},

                new Instrument{
                    Name = "OIS", AssetType =AssetType.Rates,ProductType="Cap",Currency=Currency.EUR,
                    AvailableFeatures= new List<Features>{Features.Price, Features.Rate, Features.Volatility}},

                new Instrument{
                    Name = "USD-EUR Swap", AssetType =AssetType.FX,ProductType="Swap",Currency=Currency.USD,
                    AvailableFeatures= new List<Features>{Features.Price, Features.Rate, Features.Volatility}},

                new Instrument{
                    Name = "EUR-SEK Swap", AssetType =AssetType.FX,ProductType="Swap",Currency=Currency.EUR,
                    AvailableFeatures= new List<Features>{Features.Price, Features.Rate, Features.Volatility}},
            };
        public IEnumerable<CurrencyViewModel> Currencies { get; set; }
        public HierarchyViewModel()
        {
            Products = products;
            Currencies = Products
                .OrderBy(prod => prod.Currency)
                .GroupBy(prod => prod.Currency)
                .OrderBy(group => group.Key)
                .Select(group =>
                    new CurrencyViewModel(group.Key, group.Select(prod => prod).ToArray()
                        )
                        ).ToArray();
            
            
        }
    }

    class CurrencyViewModel : BaseViewModel
    {
         
        private Currency currency;
        public IEnumerable<AssetTypeViewModel> AssetTypes { get; set; }

        public CurrencyViewModel(Currency currency, IEnumerable<Instrument> CurrencySorted)
        {
            MyCurrency = currency;
            AssetTypes = CurrencySorted
                         .OrderBy(prod => prod.AssetType)
                         .GroupBy(prod => prod.AssetType)
                         .OrderBy(group => group.Key)
                         .Select(group => new AssetTypeViewModel(group.Key, group.Select(prod => prod).ToArray()
                             )
                             ).ToList();
        }
        public Currency MyCurrency
        {
            get { return this.currency; }

            set { this.SetProperty(ref this.currency, value); }


        }



       

        

        	
    }


    class AssetTypeViewModel : BaseViewModel
    {
        private AssetType assettype;

        public IEnumerable<ProductTypeViewModel> ProductType { get; set; }

        public AssetTypeViewModel(AssetType assettype, IEnumerable<Instrument> AssetSorted)
        {
            MyAssetType = assettype;
            ProductType = AssetSorted
                .OrderBy(prod => prod.ProductType)
                .GroupBy(prod => prod.ProductType)
                .OrderBy(group => group.Key)
                .Select(group => new ProductTypeViewModel(group.Key, group.Select(prod => prod).ToArray()
                    )
                    ).ToList();
        }

        public AssetType MyAssetType
        {
            get { return this.assettype; }

            set { this.SetProperty(ref this.assettype, value); }


        }
    }

    class ProductTypeViewModel : BaseViewModel
    {
      
        private  IEnumerable<Instrument> _products;
        private string producttype;
  


    public ProductTypeViewModel(string producttype, IEnumerable<Instrument> ProductSorted)
        {
            MyProductType = producttype;
            _products = ProductSorted
                .OrderBy(prod => prod.ProductType)
                .Select(prod => prod).ToArray();
           
        }



        public string MyProductType
        {
            get { return this.producttype; }
            set { this.SetProperty(ref this.producttype, value); }

        }


        public  IEnumerable<Instrument> Products
        {
            get { return _products; }
            set { this.SetProperty(ref this._products , value); }
        }
    		
    }

   

    

  
    
}
    #endregion