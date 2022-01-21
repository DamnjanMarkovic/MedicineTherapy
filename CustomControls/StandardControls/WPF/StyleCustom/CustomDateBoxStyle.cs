
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace CustomControls
{

    public sealed class CustomDateBoxStyle : CustomStyle.CustomCommonStyle
    {

        public SolidColorBrush BackgroundValueEntered { get; set; }     = PropertiesConverter.GetSolidColorBrush("#FF333333");
        public SolidColorBrush TextColorValueEntered { get; set; }      = PropertiesConverter.GetSolidColorBrush("#FFaecbd1");
        public SolidColorBrush CaretBrush { get; set; }                 = PropertiesConverter.GetSolidColorBrush("White");
        public SolidColorBrush TextColorPlaceHolder { get; set; }       = PropertiesConverter.GetSolidColorBrush("#FFaecbd1");
        public SolidColorBrush BorderColorValueEntered { get; set; }    = PropertiesConverter.GetSolidColorBrush("Black");

        private CustomDateBoxStyle()
        {

        }

        private static readonly object padlock = new object();
        private static CustomDateBoxStyle instance = null;

        public static CustomDateBoxStyle Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new CustomDateBoxStyle();
                    }
                    return instance;
                }
            }
        }

        public void SetDefaultCustomControlStyle(CustomDateBoxProperties control)
        {
            StaticProperties.SetCommonStyle(StaticProperties.GetCommonValues(control), this);

            BackgroundValueEntered = PropertiesConverter.GetSolidColorBrush(control.BackgroundValueEntered);
            TextColorValueEntered = PropertiesConverter.GetSolidColorBrush(control.TextColorValueEntered);
            BorderColorValueEntered = PropertiesConverter.GetSolidColorBrush(control.BorderColorValueEntered);
            CaretBrush = PropertiesConverter.GetSolidColorBrush(control.CaretBrush);
            TextColorPlaceHolder = PropertiesConverter.GetSolidColorBrush(control.TextColorPlaceHolder);
 

        }

    }




    public class CustomDateBoxProperties : CustomStyle.CustomCommonProperties
    {
        public CustomDateBoxProperties()
        {
        }

        public string BackgroundValueEntered { get; set; }
        public string TextColorValueEntered { get; set; }
        public string BorderColorValueEntered { get; set; }
        public string CaretBrush { get; set; }
        public string TextColorPlaceHolder { get; set; }
    }

}
