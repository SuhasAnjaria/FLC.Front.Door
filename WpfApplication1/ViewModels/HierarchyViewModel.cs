
namespace flc.FrontDoor.Data
{
    
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.ComponentModel;
using Framework.UI.Input;
using Framework.IO;
using System.Threading.Tasks;
using System.Windows;
using FrontDoor.ViewModels;
using System.Windows.Data;
using System.Windows.Documents;
using FacadeService;
using Autofac;
using flc.FrontDoor.Models;
using System.Globalization;

     #region Hierarchy Transformation Model
 public class HierarchyViewModel : BaseViewModel
    {
    
    public static Instrument _selectedInstrument;
    public static string _selectedProduct ;
    private List<Instrument> _products = new List<Instrument>();


  
         
         public List<Instrument> Products
         {
             get { return this._products; }
             set { this.SetProperty(ref this._products, value); }

         }

        public static List<Instrument> products = new List<Instrument>();
        public IEnumerable<CurrencyViewModel> Currencies { get; set; }
        public HierarchyViewModel()
        {
            //Products = products;

            using (var scope = ModelBuilder.ModelContainer.BeginLifetimeScope())
            {
                var a = scope.Resolve<Instrumentlist>();
                var b = a.InstrumentMaster;
                foreach (var m in b)
                {
                    if (m.Underlying != "(NA)")
                    {
                        this.Products.Add(m);
                    }
                }
            }
            Currencies = Products
                .OrderBy(prod => prod.Currency)
                .GroupBy(prod => prod.Currency)
                .OrderBy(group => group.Key)
                .Select(group =>
                    new CurrencyViewModel(group.Key, group.Select(prod => prod).ToArray()
                        )
                        ).ToArray();
        }

        private static void DoSomething(flc.FrontDoor.FacadeService.InstrumentDTO ticker)
            {
                lock (HierarchyViewModel.products)
                {
                    TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
                    var A = new Instrument
                    {
                        Name = ticker.FLCTicker,
                        AssetType = (AssetType)Enum.Parse(typeof(AssetType), ticker.AssetType, true),
                        ProductType = myTI.ToTitleCase(ticker.ProductType),
                        Currency = (Currency)Enum.Parse(typeof(Currency), ticker.Currency, true),
                       // BbgCode = ticker.BloombergTicker,
                        //DqCode = ticker.DataQueryTicker,
                        AvailableFeatures = ticker.Fields.Select(c => (Features)Enum.Parse(typeof(Features), c, true)).ToList()

                    };
                    HierarchyViewModel.products.Add(A);
                }
            }
    }

    public class CurrencyViewModel : BaseViewModel
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


    public class AssetTypeViewModel : BaseViewModel
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

    public class ProductTypeViewModel : BaseViewModel
    {
      
        private  IEnumerable<UnderlyingViewModel> _underlyingsorted;
        private string producttype;
  


    public ProductTypeViewModel(string producttype, IEnumerable<Instrument> ProductSorted)
        {
            MyProductType = producttype;
            _underlyingsorted = ProductSorted
                .OrderBy(prod => prod.Underlying)
                .GroupBy(prod => prod.Underlying)
                .OrderBy(group => group.Key)
                .Where(group =>group.Key!="NA")
                .Select(group => new UnderlyingViewModel(group.Key, group.Select(prod => prod).ToArray()
                    )
                    ).ToList();
           
        }



        public string MyProductType
        {
            get { return this.producttype; }
            set { this.SetProperty(ref this.producttype, value); }

        }


        public  IEnumerable<UnderlyingViewModel> Underlyingsorted
        {
            get { return _underlyingsorted; }
            set { this.SetProperty(ref this._underlyingsorted , value); }
        }
    		
    }

    public class UnderlyingViewModel:BaseViewModel
    {
        // Fields...
        private string _underlying;
        private IEnumerable<Instrument> _products;

        public IEnumerable<Instrument> Products
        {
            get { return _products; }
            set { this.SetProperty(ref this._products , value); }
        }

        public string Underlying
        {
            get { return _underlying; }
            set { this.SetProperty(ref this._underlying ,value); }
        }
        public UnderlyingViewModel(string underlying, IEnumerable<Instrument> Underlyingsorted)
        {
            Underlying = underlying;
            Products = Underlyingsorted;
        }
    }

   

    

  
    
}
    #endregion