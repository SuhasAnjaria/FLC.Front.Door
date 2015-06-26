using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.ComponentModel;
using Framework.UI.Input;
using Framework.IO;
using flc.FrontDoor.ViewModels;
 using System.Windows.Data;
using System.Windows.Documents;

namespace flc.FrontDoor.Data
{
    class Product
    {
        public string Name;
        public string AssetType;
        public string ProductType;
        public string Currency;

        public override string ToString()
        {
            return Name;
        }
    }


    #region Hierarchy Transformation Model


    class HierarchyViewModel : BaseViewModel
    {
        public static List<Product> Product1 = new List<Product>{
                new Product{Name = "OIS Swap", AssetType ="Rates",ProductType="Swap",Currency="USD"},
                new Product{Name = "Libor Swap", AssetType ="Rates",ProductType="Swap",Currency="USD"},
                new Product{Name = "Libor Swaption", AssetType ="Rates",ProductType="Swaption",Currency="USD"},
                new Product{Name = "Eunoia Swap", AssetType ="Rates",ProductType="Swap",Currency="EUR"},
                new Product{Name = "Libor Swap", AssetType ="Rates",ProductType="Swap",Currency="EUR"},
                new Product{Name = "Libor Swaption", AssetType ="Rates",ProductType="Swaption",Currency="EUR"},
                new Product{Name = "OIS", AssetType ="Rates",ProductType="Cap",Currency="USD"},
                new Product{Name = "OIS", AssetType ="Rates",ProductType="Cap",Currency="EUR"},
                new Product{Name = "USD-EUR Swap", AssetType ="FX",ProductType="Swap",Currency="USD"},
                new Product{Name = "EUR-SEK Swap", AssetType ="FX",ProductType="Swap",Currency="EUR"}
            };
        public IEnumerable<CurrencyViewModel> Currency { get; set; }
        public HierarchyViewModel()
        {
            Currency = Product1
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
         
        private string currency;
        public IEnumerable<AssetTypeViewModel> AssetTypes { get; set; }

        public CurrencyViewModel(string currency, IEnumerable<Product> CurrencySorted)
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
        public string MyCurrency
        {
            get { return this.currency; }

            set { this.SetProperty(ref this.currency, value); }


        }


        	
    }


    class AssetTypeViewModel : BaseViewModel
    {
        private string assettype;

        public IEnumerable<ProductTypeViewModel> ProductType { get; set; }

        public AssetTypeViewModel(string assettype, IEnumerable<Product> AssetSorted)
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

        public string MyAssetType
        {
            get { return this.assettype; }

            set { this.SetProperty(ref this.assettype, value); }


        }
    }

    class ProductTypeViewModel : BaseViewModel
    {
      
        private  IEnumerable<Product> _products;
        private string producttype;
  


    public ProductTypeViewModel(string producttype, IEnumerable<Product> ProductSorted)
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


        public  IEnumerable<Product> Products
        {
            get { return _products; }
            set { this.SetProperty(ref this._products , value); }
        }
    		
    }

   

    class ProducttoNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var Name = (Product)value;
            return Name.Name;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

  
    
}
    #endregion