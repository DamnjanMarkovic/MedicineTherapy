
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace CustomControls.StandardControls.WPF_02.StyleCustom
{

    public sealed class CustomExpanderStyle : CustomStyle.CustomCommonStyle
  {
    public SolidColorBrush BackgroundToggleButton { get; set; } = PropertiesConverter.GetSolidColorBrush("Transparent");
    public SolidColorBrush BackgroundToggleButtonChecked { get; set; } = PropertiesConverter.GetSolidColorBrush("Transparent");
    public SolidColorBrush ForegroundExpanded { get; set; } = PropertiesConverter.GetSolidColorBrush("#00bfdf");
    public SolidColorBrush BackgroundItems { get; set; } = PropertiesConverter.GetSolidColorBrush("Green");
    public SolidColorBrush BorderBrushItems { get; set; } = PropertiesConverter.GetSolidColorBrush("#FFaecbd1");
    public Thickness BorderThicknessItems { get; set; } = PropertiesConverter.GetBorderThickness("0,0,0,3");


    private CustomExpanderStyle()
    {
    }

    private static readonly object padlock = new object();
    private static CustomExpanderStyle instance = null;

    public static CustomExpanderStyle Instance
    {
      get
      {
        lock (padlock)
        {
          if (instance == null)
          {
            instance = new CustomExpanderStyle();
          }
          return instance;
        }
      }
    }

    public void SetDefaultCustomControlStyle(CustomExpanderProperties control)
    {
      StaticProperties.SetCommonStyle(StaticProperties.GetCommonValues(control), this);
      BackgroundToggleButton = PropertiesConverter.GetSolidColorBrush(control.BackgroundToggleButton);
      ForegroundExpanded = PropertiesConverter.GetSolidColorBrush(control.ForegroundExpanded);
      BackgroundToggleButtonChecked = PropertiesConverter.GetSolidColorBrush(control.BackgroundToggleButtonChecked);
      BackgroundItems = PropertiesConverter.GetSolidColorBrush(control.BackgroundItems);
      BorderBrushItems = PropertiesConverter.GetSolidColorBrush(control.BorderBrushItems);
      BorderThicknessItems = PropertiesConverter.GetBorderThickness(control.BorderThicknessItems);
    }
  }

  public class CustomExpanderProperties : CustomStyle.CustomCommonProperties
  {
    public CustomExpanderProperties()
    {
    }
    public string BackgroundToggleButton { get; set; }
    public string ForegroundExpanded { get; set; }
    public string BackgroundToggleButtonChecked { get; set; }
    public string BackgroundItems { get; set; }
    public string BorderBrushItems { get; set; }
    public string BorderThicknessItems { get; set; }

  }
}
