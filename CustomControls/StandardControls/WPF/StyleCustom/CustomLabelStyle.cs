
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace CustomControls
{
    public sealed class CustomLabelStyle : CustomStyle.CustomCommonStyle
    {
        public SolidColorBrush BackgroundValueEntered { get; set; } = PropertiesConverter.GetSolidColorBrush("#FF333333");


        private CustomLabelStyle()
        {
        }

        private static readonly object padlock = new object();
        private static CustomLabelStyle instance = null;

        public static CustomLabelStyle Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new CustomLabelStyle();
                    }
                    return instance;
                }
            }
        }

        public void SetDefaultCustomControlStyle(CustomLabelProperties control)
        {
            StaticProperties.SetCommonStyle(StaticProperties.GetCommonValues(control), this);
            BackgroundValueEntered = PropertiesConverter.GetSolidColorBrush(control.BackgroundValueEntered);
        }
    }

    public class CustomLabelProperties : CustomStyle.CustomCommonProperties
    {
        public CustomLabelProperties()
        {
        }
        public string BackgroundValueEntered { get; set; }
    }
}
