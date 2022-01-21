using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MedicineTherapy.Converters
{
    [ValueConversion(typeof(List<string>), typeof(string))]
    public class ListToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string s in (List<string>)value) sb.AppendLine(s);
            return sb.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string[] lines = ((string)value).Split(new string[] { @"\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            return lines.ToList<String>();
        }

        //public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        //{
        //    if (targetType != typeof(string))
        //        throw new InvalidOperationException("The target must be a String");

        //    return string.Join(", ", ((List<string>)value).ToArray());
        //}

        //public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
