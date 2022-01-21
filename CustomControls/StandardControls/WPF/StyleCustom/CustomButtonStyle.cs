
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace CustomControls
{
    public sealed class CustomButtonStyle : CustomStyle.CustomCommonStyle
    {

        private CustomButtonStyle()
        {
        }

        private static readonly object padlock = new object();
        private static CustomButtonStyle instance = null;

        public static CustomButtonStyle Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new CustomButtonStyle();
                    }
                    return instance;
                }
            }
        }

        public void SetDefaultCustomControlStyle(CustomButtonProperties control)
        {

            StaticProperties.SetCommonStyle(StaticProperties.GetCommonValues(control), this);

        }
    }

    public class CustomButtonProperties: CustomStyle.CustomCommonProperties
    {

        public CustomButtonProperties()
        {

        }
    }



}
