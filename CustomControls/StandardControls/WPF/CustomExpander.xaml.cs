using CustomControls.StandardControls.WPF_02.StyleCustom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CustomControls
{
  /// <summary>
  /// Interaction logic for CustomExpander.xaml
  /// </summary>
  public partial class CustomExpander : Expander
  {
    #region Dependecy properties

    public Brush Background
    {
      get { return (Brush)GetValue(BackgroundProperty); }
      set { SetValue(BackgroundProperty, value); }
    }
    public static readonly DependencyProperty BackgroundProperty =
        DependencyProperty.Register("Background", typeof(Brush), typeof(CustomExpander));

    public Brush BorderBrush
    {
      get { return (Brush)GetValue(BorderBrushProperty); }
      set { SetValue(BorderBrushProperty, value); }
    }
    public static readonly DependencyProperty BorderBrushProperty =
        DependencyProperty.Register("BorderBrush", typeof(Brush), typeof(CustomExpander));

    public Brush Foreground
    {
      get { return (Brush)GetValue(ForegroundProperty); }
      set { SetValue(ForegroundProperty, value); }
    }
    public static readonly DependencyProperty ForegroundProperty =
        DependencyProperty.Register("Foreground", typeof(Brush), typeof(CustomExpander));


    public Brush BackgroundToggleButton
    {
      get { return (Brush)GetValue(BackgroundToggleButtonProperty); }
      set { SetValue(BackgroundToggleButtonProperty, value); }
    }
    public static readonly DependencyProperty BackgroundToggleButtonProperty =
        DependencyProperty.Register("BackgroundToggleButton", typeof(Brush), typeof(CustomExpander));



    public Brush ForegroundExpanded
    {
      get { return (Brush)GetValue(ForegroundExpandedProperty); }
      set { SetValue(ForegroundExpandedProperty, value); }
    }
    public static readonly DependencyProperty ForegroundExpandedProperty =
        DependencyProperty.Register("ForegroundExpanded", typeof(Brush), typeof(CustomExpander));
    

   
    public Brush BackgroundToggleButtonChecked
    {
      get { return (Brush)GetValue(BackgroundToggleButtonCheckedProperty); }
      set { SetValue(BackgroundToggleButtonCheckedProperty, value); }
    }
    public static readonly DependencyProperty BackgroundToggleButtonCheckedProperty =
        DependencyProperty.Register("BackgroundToggleButtonChecked", typeof(Brush), typeof(CustomExpander));



    public Brush ForegroundToggleButtonChecked
    {
      get { return (Brush)GetValue(ForegroundToggleButtonCheckedProperty); }
      set { SetValue(ForegroundToggleButtonCheckedProperty, value); }
    }
    public static readonly DependencyProperty ForegroundToggleButtonCheckedProperty =
        DependencyProperty.Register("ForegroundToggleButtonChecked", typeof(Brush), typeof(CustomExpander));

    public Thickness BorderThickness
    {
      get { return (Thickness)GetValue(BorderThicknessProperty); }
      set { SetValue(BorderThicknessProperty, value); }
    }
    public static readonly DependencyProperty BorderThicknessProperty =
        DependencyProperty.Register("BorderThickness", typeof(Thickness), typeof(CustomExpander));


    public int CornerRadius
    {
      get { return (int)GetValue(CornerRadiusProperty); }
      set { SetValue(CornerRadiusProperty, value); }
    }
    public static readonly DependencyProperty CornerRadiusProperty =
        DependencyProperty.Register("CornerRadius", typeof(int), typeof(CustomExpander));

    

    public Brush BackgroundItems
    {
      get { return (Brush)GetValue(BackgroundItemsProperty); }
      set { SetValue(BackgroundItemsProperty, value); }
    }
    public static readonly DependencyProperty BackgroundItemsProperty =
        DependencyProperty.Register("BackgroundItems", typeof(Brush), typeof(CustomExpander));

    public SolidColorBrush BorderBrushItems
    {
      get { return (SolidColorBrush)GetValue(BorderBrushItemsProperty); }
      set { SetValue(BorderBrushItemsProperty, value); }
    }
    public static readonly DependencyProperty BorderBrushItemsProperty =
        DependencyProperty.Register("BorderBrushItems", typeof(SolidColorBrush), typeof(CustomExpander));

    public Thickness BorderThicknessItems
    {
      get { return (Thickness)GetValue(BorderThicknessItemsProperty); }
      set { SetValue(BorderThicknessItemsProperty, value); }
    }
    public static readonly DependencyProperty BorderThicknessItemsProperty =
        DependencyProperty.Register("BorderThicknessItems", typeof(Thickness), typeof(CustomExpander));









    #endregion


    public CustomExpander()
    {
      InitializeComponent();
      StaticProperties.SetCommonStyle(CustomExpanderStyle.Instance, this);
    }
  }
}
