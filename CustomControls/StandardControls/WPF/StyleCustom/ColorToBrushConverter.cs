using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace CustomControls
{
    public class ColorToBrushConverter : IValueConverter
    {

        public virtual object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is Color ? new SolidColorBrush((Color)value) : Brushes.Black;
        }

        public virtual object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }




        //public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        //{
        //    if (null == value)
        //    {
        //        return null;
        //    }

        //    if (value is Color)
        //    {
        //        Color color = (Color)value;
        //        return new SolidColorBrush(color);
        //    }

        //    if (value is SolidColorBrush)
        //    {
        //        return ((SolidColorBrush)value).Color;
        //    }
        //    Type type = value.GetType();
        //    throw new InvalidOperationException("Unsupported type [" + type.Name + "]");
        //}

        //public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        //{
        //    throw new NotImplementedException();
        //}
    }

    public class InvertColorToBrush : ColorToBrushConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Color)
            {
                Color color = (Color)value;
                int iCol = ((color.A << 24) | (color.R << 16) | (color.G << 8) | color.B) ^ 0xffffff;
                Color inverted = Color.FromArgb((byte)(iCol >> 24),
                                                (byte)(iCol >> 16),
                                                (byte)(iCol >> 8),
                                                (byte)(iCol));

                return base.Convert(inverted, targetType, parameter, culture);
            }
            else
            {
                return Brushes.Black;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


}
