using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace DonkeyExampleApp
{
    public class FileSizeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is long))
                return DependencyProperty.UnsetValue;

            return FormatFileSize((long)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private static string FormatFileSize(long size)
        {
            if (size < 1024)
                return String.Format("{0} bytes", size);

            if (size < 1048576)
                return String.Format("{0:0.00} KB", (double)size / 1024d);

            if (size < 1073741824)
                return String.Format("{0:0.00} MB", (double)size / 1048576d);

            if (size < 1099511627776)
                return String.Format("{0:0.00} GB", (double)size / 1073741824d);

            return String.Format("{0:0.00} TB", (double)size / 1099511627776d);
        }
    }
}