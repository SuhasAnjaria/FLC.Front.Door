using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using flc.FrontDoor.Data;
using System.Windows.Documents;

namespace flc.FrontDoor.Converters
{
    class StringToFeaturesConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                var A = (string)value;
                return (Features)Enum.Parse(typeof(Features), A, true);
            }
            return null;
        }

        public object ConvertBack(object value, Type targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                string Converted = Enum.GetName((value.GetType()), value);
                return Converted;
            }

            catch (Exception ex)
            {
                return string.Empty;
            }
        }
    }
}
