using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DonkeyExampleApp
{
    public class ToStringConcat : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var e = value as IEnumerable;
            if (e == null)
                return null;

            var se = e.Cast<object>().Select(i => i.ToString()).ToArray();

            return se.Length == 0 ? null : se.Aggregate((i, j) => $"{i}\r\n{j}");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
