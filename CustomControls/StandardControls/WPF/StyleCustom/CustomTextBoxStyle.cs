
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Xml.Serialization;

namespace CustomControls
{

    public sealed class CustomTextBoxStyle : CustomStyle.CustomCommonStyle
    {

        public SolidColorBrush BackgroundValueEntered { get; set; }     = PropertiesConverter.GetSolidColorBrush("#FF333333");
        public SolidColorBrush TextColorValueEntered { get; set; }      = PropertiesConverter.GetSolidColorBrush("#FFaecbd1");
        public SolidColorBrush BorderColorValueEntered { get; set; }    = PropertiesConverter.GetSolidColorBrush("Black");
        public SolidColorBrush CaretBrush { get; set; }                 = PropertiesConverter.GetSolidColorBrush("White");
        public SolidColorBrush TextColorPlaceHolder { get; set; }       = PropertiesConverter.GetSolidColorBrush("#FFaecbd1");

        private CustomTextBoxStyle()
        {

        }

        private static readonly object padlock = new object();
        private static CustomTextBoxStyle instance = null;

        public static CustomTextBoxStyle Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new CustomTextBoxStyle();
                    }
                    return instance;
                }
            }
        }

        public void SetDefaultCustomControlStyle(CustomTextBoxProperties control)
        {

            StaticProperties.SetCommonStyle(StaticProperties.GetCommonValues(control), this);
            BackgroundValueEntered = PropertiesConverter.GetSolidColorBrush(control.BackgroundValueEntered);
            TextColorValueEntered = PropertiesConverter.GetSolidColorBrush(control.TextColorValueEntered);
            BorderColorValueEntered = PropertiesConverter.GetSolidColorBrush(control.BorderColorValueEntered);
            CaretBrush = PropertiesConverter.GetSolidColorBrush(control.CaretBrush);
            TextColorPlaceHolder = PropertiesConverter.GetSolidColorBrush(control.TextColorPlaceHolder);

        }

    }
    public class CustomTextBoxProperties : CustomStyle.CustomCommonProperties
    {
        public CustomTextBoxProperties()
        {
        }

        public string BackgroundValueEntered { get; set; }
        public string TextColorValueEntered { get; set; }
        public string BorderColorValueEntered { get; set; }
        public string CaretBrush { get; set; }  
        public string TextColorPlaceHolder { get; set; } 

    }
    
}

