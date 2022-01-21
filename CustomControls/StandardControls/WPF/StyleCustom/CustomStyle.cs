
using CustomControls.StandardControls.WPF_02.StyleCustom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml.Serialization;

namespace CustomControls
{

    public sealed class CustomStyle
    {
        private CustomStyle()
        {
        }
        public CustomTextBoxProperties CustomTextBoxProperties { get; set; }
        public CustomButtonProperties CustomButtonProperties { get; set; }
        public CustomLabelProperties CustomLabelProperties { get; set; }
        public CustomDateBoxProperties CustomDateBoxProperties { get; set; }
        public CustomRadioButtonProperties CustomRadioButtonProperties { get; set; }
        public CustomCheckBoxProperties CustomCheckBoxProperties { get; set; }
        public CustomComboBoxProperties CustomComboBoxProperties { get; set; }
        public CustomExpanderProperties CustomExpanderProperties { get; set; }

    private static readonly object padlock = new object();
        private static CustomStyle instance = null;

        public static CustomStyle Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new CustomStyle();
                    }
                    return instance;
                }
            }
        }


        public void SetDefaultProperties()
        {
            CustomStyle customStyle = StaticProperties.DeserializeXMLFileToObject<CustomStyle>(StaticProperties.ConfigurationGUIStyle);
            if (customStyle != null)
            {
                CustomButtonStyle.Instance.SetDefaultCustomControlStyle(customStyle.CustomButtonProperties);
                CustomTextBoxStyle.Instance.SetDefaultCustomControlStyle(customStyle.CustomTextBoxProperties);
                CustomDateBoxStyle.Instance.SetDefaultCustomControlStyle(customStyle.CustomDateBoxProperties);
                CustomRadioButtonStyle.Instance.SetDefaultCustomControlStyle(customStyle.CustomRadioButtonProperties);
                CustomCheckBoxStyle.Instance.SetDefaultCustomControlStyle(customStyle.CustomCheckBoxProperties);
                CustomComboBoxStyle.Instance.SetDefaultCustomControlStyle(customStyle.CustomComboBoxProperties);
                CustomLabelStyle.Instance.SetDefaultCustomControlStyle(customStyle.CustomLabelProperties);
                CustomExpanderStyle.Instance.SetDefaultCustomControlStyle(customStyle.CustomExpanderProperties);
            }

        }


        public class CustomCommonProperties
        {
            public string Background { get; set; } 
            public string BorderBrush { get; set; }
            public string Foreground { get; set; }

            public string BackgroundMouseOver { get; set; }
            public string BorderColorMouseOver { get; set; }
            public string TextColorMouseOver { get; set; }

            public string BackgroundDisabled { get; set; }
            public string BorderColorDisabled { get; set; }
            public string TextColorDisabled { get; set; }

            public string BackgroundChecked { get; set; }
            public string BorderColorChecked { get; set; }
            public string TextColorChecked { get; set; }

            public string CornerRadius { get; set; }
            public string BorderThickness { get; set; }


            public string DropShadowEffectBlur { get; set; }
            public string DropShadowEffectOpacity { get; set; }
            public string DropShadowEffectColor { get; set; }
            public string DropShadowEffectShadowDepth { get; set; }

        }

        public class CustomCommonStyle
        {
            public Brush Background { get; set; }                       = PropertiesConverter.GetSolidColorBrush("#FF242424");
            public SolidColorBrush BorderBrush { get; set; }            = PropertiesConverter.GetSolidColorBrush("Black");
            public SolidColorBrush Foreground { get; set; }             = PropertiesConverter.GetSolidColorBrush("#FFaecbd1");

            public Brush BackgroundMouseOver { get; set; }              = PropertiesConverter.GetSolidColorBrush("#FF333333");
            public SolidColorBrush BorderColorMouseOver { get; set; }   = PropertiesConverter.GetSolidColorBrush("Black");
            public SolidColorBrush TextColorMouseOver { get; set; }     = PropertiesConverter.GetSolidColorBrush("#FFD2EDF6");

            public Brush BackgroundDisabled { get; set; }               = PropertiesConverter.GetSolidColorBrush("#FF08080A");
            public SolidColorBrush BorderColorDisabled { get; set; }    = PropertiesConverter.GetSolidColorBrush("Black");
            public SolidColorBrush TextColorDisabled { get; set; }      = PropertiesConverter.GetSolidColorBrush("#FF75CEDE");

            public Brush BackgroundChecked { get; set; }                = PropertiesConverter.GetSolidColorBrush("#FF242424");
            public SolidColorBrush BorderColorChecked { get; set; }     = PropertiesConverter.GetSolidColorBrush("Gray");
            public SolidColorBrush TextColorChecked { get; set; }       = PropertiesConverter.GetSolidColorBrush("#00bfdf");

            public int CornerRadius { get; set; }                       = PropertiesConverter.GetCornerRadiusValue("0");
            public Thickness BorderThickness { get; set; }              = PropertiesConverter.GetBorderThickness("0,0,0,0");


            public double DropShadowEffectBlur { get; set; }            = PropertiesConverter.GetValueDouble("15");
            public double DropShadowEffectOpacity { get; set; }         = PropertiesConverter.GetValueDouble("1");
            public Color DropShadowEffectColor { get; set; }            = PropertiesConverter.GetColor("White");
            public double DropShadowEffectShadowDepth { get; set; }     = PropertiesConverter.GetValueDouble("0");

        }

    }

}


