using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Collections;
using System.Windows;
namespace flc.FrontDoor.Converters
{
    class GeneralMultiStringDisplayConverter:IMultiValueConverter
    {
        
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var AS = DependencyProperty.UnsetValue;    
            if (values[0] != AS )
            {
                int count = values.Count();
                string result = string.Empty;
                for (int i = 0; i < count - 1; ++i)
                {
                    try
                    {
                        var A = Enum.GetName((values[i].GetType()), values[i]);
                        result = String.Format("{0}{1}.", result, A);
                    }
                    catch (Exception ex)
                    {
                        
                        result = String.Format("{0}{1}.", result, values[i]);
                    }
                }
                result = String.Format("{0}{1}", result, values[count - 1]);
                return result;
            }
            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
            //TODO:
        }
    }
}
