
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace CustomControls
{
    public sealed class CustomComboBoxStyle : CustomStyle.CustomCommonStyle
    {

        public SolidColorBrush BorderBrush { get; set; } = PropertiesConverter.GetSolidColorBrush("#1abfdf");
        public Brush BackgroundChecked { get; set; } = PropertiesConverter.GetSolidColorBrush("#FF333333");
        public SolidColorBrush BorderColorChecked { get; set; } = PropertiesConverter.GetSolidColorBrush("Black");
        public SolidColorBrush TextColorChecked { get; set; } = PropertiesConverter.GetSolidColorBrush("#FFaecbd1");


        public SolidColorBrush BackgroundItems { get; set; }        = PropertiesConverter.GetSolidColorBrush("#FF333333");
        public Thickness BorderThicknessItems { get; set; }         = PropertiesConverter.GetBorderThickness("0, 0, 0, 3");
        public Color TextColorDisabledColor { get; set; }           = PropertiesConverter.GetColor("#FF75CEDE");
        public SolidColorBrush TextColorPlaceHolder { get; set; }   = PropertiesConverter.GetSolidColorBrush("#FFaecbd1");
        public Brush BackgroundItemsChecked { get; set; }           = PropertiesConverter.GetSolidColorBrush("#1abfdf");
        public Brush BackgroundMouseOverItems { get; set; }         = PropertiesConverter.GetSolidColorBrush("#FF242424");
        public SolidColorBrush BorderBrushItems { get; set; }       = PropertiesConverter.GetSolidColorBrush("#FFaecbd1");
        public SolidColorBrush TextItemsColorChecked { get; set; }  = PropertiesConverter.GetSolidColorBrush("White");
        public SolidColorBrush ForegroundChecked { get; set; }      = PropertiesConverter.GetSolidColorBrush("#00bfdf");

    private CustomComboBoxStyle()
        {
        }

        private static readonly object padlock = new object();
        private static CustomComboBoxStyle instance = null;

        public static CustomComboBoxStyle Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new CustomComboBoxStyle();
                    }
                    return instance;
                }
            }
        }

        public void SetDefaultCustomControlStyle(CustomComboBoxProperties control)
        {
            
            StaticProperties.SetCommonStyle(StaticProperties.GetCommonValues(control), this);
            TextColorDisabledColor = PropertiesConverter.GetColor(control.TextColorDisabled);
            BorderBrushItems = PropertiesConverter.GetSolidColorBrush(control.BorderBrushItems);
            TextColorPlaceHolder = PropertiesConverter.GetSolidColorBrush(control.TextColorPlaceHolder);
            BackgroundItems = PropertiesConverter.GetSolidColorBrush(control.BackgroundItems);
            BackgroundMouseOverItems = PropertiesConverter.GetSolidColorBrush(control.BackgroundMouseOverItems);
            BackgroundItemsChecked = PropertiesConverter.GetSolidColorBrush(control.BackgroundItemsChecked);
            BorderThicknessItems = (PropertiesConverter.GetBorderThickness(control.BorderThicknessItems));
            TextItemsColorChecked = PropertiesConverter.GetSolidColorBrush(control.TextItemsColorChecked);
            ForegroundChecked = PropertiesConverter.GetSolidColorBrush(control.ForegroundChecked);
    }
    }



    public class CustomComboBoxProperties : CustomStyle.CustomCommonProperties
    {
        public CustomComboBoxProperties()
        {
        }
        public string BorderBrushItems { get; set; }
        public string BackgroundMouseOverItems { get; set; }
        public string BackgroundItems { get; set; }
        public string BackgroundItemsChecked { get; set; }
        public string BorderThicknessItems { get; set; }
        public string TextColorPlaceHolder { get; set; }
        public string TextItemsColorChecked { get; set; }
        public string ForegroundChecked { get; set; } 
  }
}
