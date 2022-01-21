
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CustomControls
{
    public sealed class CustomRadioButtonStyle : CustomStyle.CustomCommonStyle
    {

        public SolidColorBrush Foreground { get; set; } = PropertiesConverter.GetSolidColorBrush("#aecbd1");

        public Brush BackgroundMouseOver { get; set; } = PropertiesConverter.GetSolidColorBrush("#FF242424");
        public SolidColorBrush TextColorMouseOver { get; set; } = PropertiesConverter.GetSolidColorBrush("#FFFFFF");        
        

        private CustomRadioButtonStyle()
        {
        }

        private static readonly object padlock = new object();
        private static CustomRadioButtonStyle instance = null;

        public static CustomRadioButtonStyle Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new CustomRadioButtonStyle();
                    }
                    return instance;
                }
            }
        }

        public void SetDefaultCustomControlStyle(CustomRadioButtonProperties control)
        {
            StaticProperties.SetCommonStyle(StaticProperties.GetCommonValues(control), this);
        }
    }



    public class CustomRadioButtonProperties : CustomStyle.CustomCommonProperties
    {
        public CustomRadioButtonProperties()
        {
        }
     

    }
}
