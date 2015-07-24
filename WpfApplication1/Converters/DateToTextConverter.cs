using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Data;

namespace flc.FrontDoor.Converters
{
    class DateToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if(value!=null)
            {
                var Date = (DateTime)value;
                if(Date==DateTime.Today)
                {
                    return "Today";
                }
            return value;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
