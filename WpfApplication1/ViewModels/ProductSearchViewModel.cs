
namespace flc.FrontDoor.ViewModels
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using flc.FrontDoor.Data;
    using System.Windows.Controls;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Windows.Interactivity;
    using System.Globalization;
/// <summary>
    /// The Logic to search the Master Product List
    /// </summary>
    public class ProductSearchViewModel:BaseViewModel
    {
        #region Private Fields
        private string _description;
        private string _currency;
        private string _assettype;
        private string _name;
        private string _features;
        private string _bbgCode;
        #endregion

        #region Public Properties
        public Instrument Product { get; set; }
        public bool IsMatch { get; set; }

        public string Name
        {
            get { return _name; }
            set { if (_name != value) { _name = value; OnPropertyChanged("Name"); } }
        }

        public string AssetType
        {
            get { return _assettype; }
            set { if (_assettype != value) { _assettype = value; OnPropertyChanged("Assetype"); } }
        }

        public string Currency
        {
            get { return _currency; }
            set { if (_currency != value) { _currency = value; OnPropertyChanged("Currency"); } }
        }

        public string Description
        {
            get { return _description; }
            set { if (_description != value) { _description = value; OnPropertyChanged("Description"); } }
        }

        public string BbgCode
        {
            get { return _bbgCode; }
            set { if (_bbgCode != value) { _bbgCode = value; OnPropertyChanged("BbgCode"); } }
        }

        public string Features
        {
            get { return _features; }
            set { if (_features != value) { _features = value; OnPropertyChanged("Features"); } }
        }
        #endregion

        #region Search Logic
        public static bool IsAutocompleteSuggestion(string
        search, object productItem)
        {

            const string pattern = @"\b{0}";/* Regex Character to signify search in the beginning and end of each word */
            var result = false;
            var product = productItem as ProductSearchViewModel;

            var parts = search.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (product != null)
            {
                foreach (var part in parts)
                {
                    product.IsMatch = false;
                    var regex = new Regex(string.Format(part));
                    product.InitializeSearch();
                    product.CompareName(regex);
                    product.CompareFeatures(regex);
                    product.CompareAssetTypes(regex);
                    product.CompareDescription(regex);
                    product.CompareBbgCode(regex);
                    product.Finalize();

                    return result = result || product.IsMatch;

                }

            }
            return result;
        }



        private void InitializeSearch()
        {
            AssetType = "";
            Currency = "";
            Description = "";
            Features = "";

        }

        private void CompareDescription(Regex regex)
        {
            //TODO
        }

        private void CompareAssetTypes(Regex regex)
        {
            if (Product.AssetType != null)
            {
                var A = Product.AssetType.ToString();
                if (regex.IsMatch(A))
                {
                    AssetType = String.Format(CultureInfo.InvariantCulture, "{0}", Product.AssetType);
                    IsMatch = true;
                }
            }
        }

        private void CompareFeatures(Regex regex)
        {
            if (Product.AvailableFeatures != null)
            {
                if (regex.IsMatch(Product.AvailableFeatures.ToString()))
                {
                    Features = String.Format(CultureInfo.InvariantCulture, "{0}", Product.AvailableFeatures.ToString());
                    IsMatch = true;
                }
            }
        }

        private void CompareName(Regex regex)
        {
            if (Product.Name != null)
            {
                if (regex.IsMatch(Product.Name))
                {
                    IsMatch = true;
                }
            }
        }

        private void CompareBbgCode(Regex regex)
        {
            if (Product.BbgCode != null)
            {
                if (regex.IsMatch(Product.BbgCode))
                {
                    BbgCode = Product.BbgCode;
                    IsMatch = true;
                }
            }
        }

        private void Finalize()
        {
            if (IsMatch == true)
            {
                this.Name = Product.Name;
                this.Currency = Product.Currency.ToString();
                this.AssetType = Product.AssetType.ToString();
                this.Features = Product.AvailableFeatures.ToString();
                this.BbgCode = Product.BbgCode;
                
            }
        }
        #endregion
    }
}
