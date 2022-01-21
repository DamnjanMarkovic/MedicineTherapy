using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml;
using System.Xml.Serialization;

namespace CustomControls
{
    public static class PropertiesConverter
    {
        internal static Brush GetBrush(string value)
        {
            var defaultValue = Brushes.Transparent;
            if (CheckString(value))
            {
                try
                {
                    defaultValue = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString(value));
                }
                catch (Exception)
                {
                    MessageBox.Show("GetBrush XML problem");
                }
            }
            return defaultValue;
        }
        internal static double GetValueDouble(string value)
        {
            double defaultValue = 1;

            if (CheckString(value))
            {
                try
                {
                    defaultValue = double.Parse(value);
                }
                catch (Exception)
                {
                    MessageBox.Show("GetValueDouble XML problem");
                }
            }
            return defaultValue;
        }
        internal static FontFamily GetFontFamily(string fontFamily)
        {
            return new FontFamily(fontFamily);
        }
        internal static HorizontalAlignment GetHorizontalAlignment(string horizontalAlignmentPlaceHolder)
        {
            return (System.Windows.HorizontalAlignment)Enum.Parse(typeof(HorizontalAlignment), (horizontalAlignmentPlaceHolder));
        }
        internal static bool GetFocusableValue(string focusable)
        {
            var defaultValue = true;
            if (CheckString(focusable))
            {
                try
                {
                    defaultValue = Convert.ToBoolean(focusable);
                }
                catch (Exception)
                {
                    MessageBox.Show("GetFocusableValue XML problem");
                }
            }
            return defaultValue;
        }
        internal static int GetCornerRadiusValue(string value)

        {
            var defaultValue = 1;

            if (CheckString(value))
            {
                try
                {
                    defaultValue = int.Parse(value);
                }
                catch (Exception)
                {
                    MessageBox.Show("GetCornerRadiusValue XML problem");
                }
            }
            return defaultValue;

        }

        internal static SolidColorBrush GetSolidColorBrush(string value)
        {
            var defaultValue = Brushes.Transparent;
            if (CheckString(value))
            {
                string[] separateColorValues = value.Split(',');

                if (separateColorValues.Length > 1)
                {
                    if (separateColorValues.Length == 4)
                    {
                        try
                        {
                            defaultValue = new System.Windows.Media.SolidColorBrush(
                                                            Color.FromArgb(Convert.ToByte(separateColorValues[0]),
                                                            Convert.ToByte(separateColorValues[1]),
                                                            Convert.ToByte(separateColorValues[2]),
                                                            Convert.ToByte(separateColorValues[3])
                                                            ));
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("ArgbColor XML problem");
                        }
                    }
                    else if (separateColorValues.Length == 3)
                    {
                        try
                        {
                            defaultValue = new System.Windows.Media.SolidColorBrush(Color.FromArgb(255,
                                                            Convert.ToByte(separateColorValues[0]),
                                                            Convert.ToByte(separateColorValues[1]),
                                                            Convert.ToByte(separateColorValues[2])
                                                            ));
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("RgbColor XML problem");
                        }
                    }
                }
                else
                {
                    try
                    {
                        defaultValue = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString(value));
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("GetSolidColorBrush XML problem");
                    }
                }
            }
            return defaultValue;
        }
        internal static Color GetColor(string value)
        {
            var defaultValue = (Color)ColorConverter.ConvertFromString("Transparent");

            if (CheckString(value))
            {
                string[] separateColorValues = value.Split(',');

                if (separateColorValues.Length > 1)
                {
                    if (separateColorValues.Length == 4)
                    {
                        try
                        {
                            defaultValue = Color.FromArgb(Convert.ToByte(separateColorValues[0]),
                                                            Convert.ToByte(separateColorValues[1]),
                                                            Convert.ToByte(separateColorValues[2]),
                                                            Convert.ToByte(separateColorValues[3])
                                                            );
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("ArgbColor XML problem");
                        }
                    }
                    else if (separateColorValues.Length == 3)
                    {
                        try
                        {
                            defaultValue = Color.FromArgb(255,
                                                            Convert.ToByte(separateColorValues[0]),
                                                            Convert.ToByte(separateColorValues[1]),
                                                            Convert.ToByte(separateColorValues[2])
                                                            );
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("RgbColor XML problem");
                        }
                    }
                }
                else
                {
                    try
                    {
                        defaultValue = (Color)ColorConverter.ConvertFromString(value);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Color XML problem");
                    }
                }
            }
            return defaultValue;
        }

        //internal static double GetBorderThicknessValue(string value)
        //{
        //    double defaultValue = 1;

        //    if (CheckString(value))
        //    {
        //        try
        //        {
        //            defaultValue = double.Parse(value);

        //        }
        //        catch (Exception)
        //        {
        //            MessageBox.Show("GetBorderThicknessValue XML problem");
        //        }
        //    }
        //    return defaultValue;
        //}


        internal static Thickness GetBorderThickness(string value)
        {
            var defaultValue = new Thickness(0, 0, 0, 0);

            if (CheckString(value))
            {
                string[] allMarginsInVvalue = value.Split(',');

                if (allMarginsInVvalue.Length > 1)
                {
                    try
                    {
                        defaultValue = new Thickness(
                                            Convert.ToDouble(allMarginsInVvalue[0]),
                                            Convert.ToDouble(allMarginsInVvalue[1]),
                                            Convert.ToDouble(allMarginsInVvalue[2]),
                                            Convert.ToDouble(allMarginsInVvalue[3])
                                            );
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Thickness XML problem");
                    }
                }
                else
                {
                    try
                    {
                        defaultValue = new Thickness(
                                            Convert.ToDouble(allMarginsInVvalue[0])
                                            );
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Thickness XML problem");
                    }
                }
            }
            return defaultValue;
        }
        internal static VerticalAlignment GetVerticalAlignment(string verticalContentAlignment)
        {
            var defaultValue = (System.Windows.VerticalAlignment)Enum.Parse(typeof(VerticalAlignment), "Center");

            if (CheckString(verticalContentAlignment))
            {
                try
                {
                    defaultValue = (System.Windows.VerticalAlignment)Enum.Parse(typeof(VerticalAlignment), (verticalContentAlignment));
                }
                catch (Exception)
                {
                    MessageBox.Show("GetBrush XML problem");
                }
            }
            return defaultValue;

        }
        public static bool CheckString(string value)
        {
            bool result = false;
            if (value != null && value.Length > 0)
            {
                result = true;
            }
            return result;
        }

    }
}

