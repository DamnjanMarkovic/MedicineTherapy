
using CustomControls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Serialization;

namespace CustomControls
{
  public static class StaticProperties
  {
    public readonly static string ConfigurationGUIStyle = "ConfigurationGUIStyle.xml";

    public readonly static string ResourcesLocation = "pack://siteoforigin:,,,/Resources/";

    public static void SetCommonStyleLabel(object fromObject, object toObject)
    {
      PropertyInfo[] toObjectProperties = toObject.GetType().GetProperties();
      foreach (PropertyInfo propTo in toObjectProperties)
      {
        PropertyInfo propFrom = fromObject.GetType().GetProperty(propTo.Name);
        if (propFrom != null && propFrom.CanWrite)
          propTo.SetValue(toObject, propFrom.GetValue(fromObject, null), null);
      }
    }

    public static void SetCommonStyle(object fromObject, object toObject)
    {
      PropertyInfo[] toObjectProperties = toObject.GetType().GetProperties();
      foreach (PropertyInfo propTo in toObjectProperties)
      {
        PropertyInfo propFrom = fromObject.GetType().GetProperty(propTo.Name);
        if (propFrom != null && propFrom.CanWrite)
          propTo.SetValue(toObject, propFrom.GetValue(fromObject, null), null);
      }
    }

    public static CustomStyle.CustomCommonStyle GetCommonValues(CustomStyle.CustomCommonProperties ControlWithStringProperties)
    {
      CustomStyle.CustomCommonStyle ControlWithValues = new CustomStyle.CustomCommonStyle();
      if ((ControlWithStringProperties == null)) return default(CustomStyle.CustomCommonStyle);

      try
      {
        ControlWithValues.Background = PropertiesConverter.GetSolidColorBrush(ControlWithStringProperties.Background);
        ControlWithValues.BorderBrush = PropertiesConverter.GetSolidColorBrush(ControlWithStringProperties.BorderBrush);
        ControlWithValues.Foreground = PropertiesConverter.GetSolidColorBrush(ControlWithStringProperties.Foreground);

        ControlWithValues.BackgroundMouseOver = PropertiesConverter.GetSolidColorBrush(ControlWithStringProperties.BackgroundMouseOver);
        ControlWithValues.BorderColorMouseOver = PropertiesConverter.GetSolidColorBrush(ControlWithStringProperties.BorderColorMouseOver);
        ControlWithValues.TextColorMouseOver = PropertiesConverter.GetSolidColorBrush(ControlWithStringProperties.TextColorMouseOver);

        ControlWithValues.BackgroundDisabled = PropertiesConverter.GetSolidColorBrush(ControlWithStringProperties.BackgroundDisabled);
        ControlWithValues.BorderColorDisabled = PropertiesConverter.GetSolidColorBrush(ControlWithStringProperties.BorderColorDisabled);
        ControlWithValues.TextColorDisabled = PropertiesConverter.GetSolidColorBrush(ControlWithStringProperties.TextColorDisabled);

        ControlWithValues.BackgroundChecked = PropertiesConverter.GetSolidColorBrush(ControlWithStringProperties.BackgroundChecked);
        ControlWithValues.BorderColorChecked = PropertiesConverter.GetSolidColorBrush(ControlWithStringProperties.BorderColorChecked);
        ControlWithValues.TextColorChecked = PropertiesConverter.GetSolidColorBrush(ControlWithStringProperties.TextColorChecked);

        ControlWithValues.CornerRadius = PropertiesConverter.GetCornerRadiusValue(ControlWithStringProperties.CornerRadius);
        ControlWithValues.BorderThickness = PropertiesConverter.GetBorderThickness(ControlWithStringProperties.BorderThickness);

        ControlWithValues.DropShadowEffectBlur = PropertiesConverter.GetValueDouble(ControlWithStringProperties.DropShadowEffectBlur);
        ControlWithValues.DropShadowEffectOpacity = PropertiesConverter.GetValueDouble(ControlWithStringProperties.DropShadowEffectOpacity);
        ControlWithValues.DropShadowEffectColor = PropertiesConverter.GetColor(ControlWithStringProperties.DropShadowEffectColor);
        ControlWithValues.DropShadowEffectShadowDepth = PropertiesConverter.GetValueDouble(ControlWithStringProperties.DropShadowEffectShadowDepth);

      }
      catch (Exception ex)
      {
        MessageBox.Show("Colors converting failure.");
      }
      return ControlWithValues;
    }

    public static T DeserializeXMLFileToObject<T>(string XmlFilename)
    {
      T returnObject = default(T);
      if (string.IsNullOrEmpty(XmlFilename) || !File.Exists(XmlFilename)) 
                return default(T);

      try
      {
        StreamReader xmlStream = new StreamReader(XmlFilename);
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        returnObject = (T)serializer.Deserialize(xmlStream);
      }
      catch (Exception ex)
      {

      }
      return returnObject;
    }

    public static IEnumerable<DataGridRow> GetDataGridRows(DataGrid bla)
    {
      List<DataGridRow> list = new List<DataGridRow>();
      return list;
    }

  }
}
