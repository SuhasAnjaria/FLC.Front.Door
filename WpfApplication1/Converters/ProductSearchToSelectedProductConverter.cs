using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using flc.FrontDoor.ViewModels;

namespace flc.FrontDoor.Converters
{
    class ProductSearchToSelectedProductConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
          
            {
                var ProductSearchVM = value as ProductSearchViewModel;
                return ProductSearchVM.Name;
            }
          
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            
            {
                var ProductSearchVM = value as ProductSearchViewModel;
                return ProductSearchVM.Name;
            }
            
        }
    }
}
