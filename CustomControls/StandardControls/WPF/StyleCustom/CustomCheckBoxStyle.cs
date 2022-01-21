
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace CustomControls
{

    public sealed class CustomCheckBoxStyle : CustomStyle.CustomCommonStyle
    {

        public Brush BackgroundMouseOver { get; set; }              = PropertiesConverter.GetSolidColorBrush("#FF242424");
        public SolidColorBrush TextColorMouseOver { get; set; }     = PropertiesConverter.GetSolidColorBrush("#FFFFFF");
        
        private CustomCheckBoxStyle()
        {
        }

        private static readonly object padlock = new object();
        private static CustomCheckBoxStyle instance = null;

        public static CustomCheckBoxStyle Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new CustomCheckBoxStyle();
                    }
                    return instance;
                }
            }
        }

        public void SetDefaultCustomControlStyle(CustomCheckBoxProperties control)
        {

            StaticProperties.SetCommonStyle(StaticProperties.GetCommonValues(control), this);
        }
    }


    public class CustomCheckBoxProperties : CustomStyle.CustomCommonProperties
    {
        public CustomCheckBoxProperties()
        {
        }


    }




}
