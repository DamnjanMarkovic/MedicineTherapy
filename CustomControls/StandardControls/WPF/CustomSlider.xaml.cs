
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
using System.Diagnostics;
using System.Windows.Controls.Primitives;

namespace CustomControls
{
  /// <summary>
  /// Interaction logic for CustomSlider.xaml
  /// </summary>
  public partial class CustomSlider : UserControl
  {
    #region Dependency Properties

    public Geometry PathDataValue
    {
      get { return (Geometry)GetValue(PathDataValueProperty); }
      set { SetValue(PathDataValueProperty, value); }
    }
    public static readonly DependencyProperty PathDataValueProperty =
        DependencyProperty.Register("PathDataValue", typeof(Geometry), typeof(CustomSlider), 
          new PropertyMetadata(ImagesPaths.Cine_Slajder_01));

    public Brush ThumbColor
    {
      get { return (Brush)GetValue(ThumbColorProperty); }
      set { SetValue(ThumbColorProperty, value); }
    }
    public static readonly DependencyProperty ThumbColorProperty =
        DependencyProperty.Register("ThumbColor", typeof(Brush), typeof(CustomSlider), 
          new PropertyMetadata((SolidColorBrush)new BrushConverter().ConvertFromString("#FFAECBD1")));

    public Brush ThumbColorMouseOver
    {
      get { return (Brush)GetValue(ThumbColorMouseOverProperty); }
      set { SetValue(ThumbColorMouseOverProperty, value); }
    }
    public static readonly DependencyProperty ThumbColorMouseOverProperty =
        DependencyProperty.Register("ThumbColorMouseOver", typeof(Brush), typeof(CustomSlider),
          new PropertyMetadata((SolidColorBrush)new BrushConverter().ConvertFromString("#00bfdf")));

    public Thickness MarginImage
    {
      get { return (Thickness)GetValue(MarginImageProperty); }
      set { SetValue(MarginImageProperty, value); }
    }
    public static readonly DependencyProperty MarginImageProperty =
        DependencyProperty.Register("MarginImage", typeof(Thickness), typeof(CustomSlider), 
          new PropertyMetadata(new Thickness(0,0,0,0)));



    public int ThumbWidth
    {
      get { return (int)GetValue(ThumbWidthProperty); }
      set { SetValue(ThumbWidthProperty, value); }
    }
    public static readonly DependencyProperty ThumbWidthProperty =
        DependencyProperty.Register("ThumbWidth", 
          typeof(int), typeof(CustomSlider), new PropertyMetadata(16));



    public int ThumbHeight
    {
      get { return (int)GetValue(ThumbHeightProperty); }
      set { SetValue(ThumbHeightProperty, value); }
    }
    public static readonly DependencyProperty ThumbHeightProperty =
        DependencyProperty.Register("ThumbHeight", typeof(int), 
          typeof(CustomSlider), new PropertyMetadata(30));



    public Thickness ThumbStartMargin
    {
      get { return (Thickness)GetValue(ThumbStartMarginProperty); }
      set { SetValue(ThumbStartMarginProperty, value); }
    }
    public static readonly DependencyProperty ThumbStartMarginProperty =
        DependencyProperty.Register("ThumbStartMargin", typeof(Thickness), typeof(CustomSlider), 
          new PropertyMetadata(new Thickness(-8,0,0,0)));



    public Thickness ThumbMainMargin
    {
      get { return (Thickness)GetValue(ThumbMainMarginProperty); }
      set { SetValue(ThumbMainMarginProperty, value); }
    }
    public static readonly DependencyProperty ThumbMainMarginProperty =
        DependencyProperty.Register("ThumbMainMargin", typeof(Thickness), typeof(CustomSlider), 
          new PropertyMetadata(new Thickness(-8, 0, 0, 0)));


    public Thickness ThumbEndMargin
    {
      get { return (Thickness)GetValue(ThumbEndMarginProperty); }
      set { SetValue(ThumbEndMarginProperty, value); }
    }
    public static readonly DependencyProperty ThumbEndMarginProperty =
        DependencyProperty.Register("ThumbEndMargin", typeof(Thickness), typeof(CustomSlider), 
          new PropertyMetadata(new Thickness(8, 0, 0, 0)));



    public Brush ThumbMainColor
    {
      get { return (Brush)GetValue(ThumbMainColorProperty); }
      set { SetValue(ThumbMainColorProperty, value); }
    }
    public static readonly DependencyProperty ThumbMainColorProperty =
        DependencyProperty.Register("ThumbMainColor", typeof(Brush), typeof(CustomSlider),
          new PropertyMetadata((SolidColorBrush)new BrushConverter().ConvertFromString("#00bfdf")));





    public double Minimum
    {
      get { return (double)GetValue(MinimumProperty); }
      set
      {
        _preventRaiseVal_end = true;
        _preventRaiseVal_start = true;
        _preventRaiseVal_main = true;
        SetValue(MinimumProperty, value);
        _preventRaiseVal_end = false;
        _preventRaiseVal_start = false;
        _preventRaiseVal_main = false;
      }
    }
    public static readonly DependencyProperty MinimumProperty =
        DependencyProperty.Register("Minimum", typeof(double), typeof(CustomSlider), new UIPropertyMetadata(0d, new PropertyChangedCallback(PropertyChanged)));

    public double Maximum
    {
      get { return (double)GetValue(MaximumProperty); }
      set
      {
        _preventRaiseVal_end = true;
        _preventRaiseVal_start = true;
        _preventRaiseVal_main = true;
        SetValue(MaximumProperty, value);
        _preventRaiseVal_end = false;
        _preventRaiseVal_start = false;
        _preventRaiseVal_main = false;
      }
    }
    public static readonly DependencyProperty MaximumProperty =
        DependencyProperty.Register("Maximum", typeof(double), typeof(CustomSlider), new UIPropertyMetadata(1d, new PropertyChangedCallback(PropertyChanged)));

    public double MaximumValue
    {
      get { return (double)GetValue(MaximumValueProperty); }
      set
      {
        _preventRaiseVal_end = true;
        _preventRaiseVal_start = true;
        _preventRaiseVal_main = true;
        SetValue(MaximumValueProperty, value);
        _preventRaiseVal_end = false;
        _preventRaiseVal_start = false;
        _preventRaiseVal_main = false;
      }
    }
    public static readonly DependencyProperty MaximumValueProperty =
        DependencyProperty.Register("MaximumValue", typeof(double), typeof(CustomSlider));

    #region visual props
    public double MainSliderThumbWidth
    {
      get { return (double)GetValue(MainSliderThumbWidthProperty); }
      set { SetValue(MainSliderThumbWidthProperty, value); }
    }
    public static readonly DependencyProperty MainSliderThumbWidthProperty =
        DependencyProperty.Register("MainSliderThumbWidth", typeof(double), typeof(CustomSlider), new PropertyMetadata(5d));
    
    public double MainSliderThumbHeight
    {
      get { return (double)GetValue(MainSliderThumbHeightProperty); }
      set { SetValue(MainSliderThumbHeightProperty, value); }
    }
    public static readonly DependencyProperty MainSliderThumbHeightProperty =
        DependencyProperty.Register("MainSliderThumbHeight", typeof(double), typeof(CustomSlider), new PropertyMetadata(18d));
    
    public Visibility MainSliderVisibility
    {
      get { return (Visibility)GetValue(MainSliderVisibilityProperty); }
      set { SetValue(MainSliderVisibilityProperty, value); }
    }
    public static readonly DependencyProperty MainSliderVisibilityProperty =
        DependencyProperty.Register("MainSliderVisibility", typeof(Visibility), typeof(CustomSlider), new PropertyMetadata(Visibility.Visible));

    public Visibility EndSliderVisibility
    {
      get { return (Visibility)GetValue(EndSliderVisibilityProperty); }
      set { SetValue(EndSliderVisibilityProperty, value); }
    }
    public static readonly DependencyProperty EndSliderVisibilityProperty =
        DependencyProperty.Register("EndSliderVisibility", typeof(Visibility), typeof(CustomSlider), new PropertyMetadata(Visibility.Visible));

    public Visibility StartSliderVisibility
    {
      get { return (Visibility)GetValue(StartSliderVisibilityProperty); }
      set { SetValue(StartSliderVisibilityProperty, value); }
    }
    public static readonly DependencyProperty StartSliderVisibilityProperty =
        DependencyProperty.Register("StartSliderVisibility", typeof(Visibility), typeof(CustomSlider), new PropertyMetadata(Visibility.Visible));
    
    public Brush SliderLineColor
    {
      get { return (Brush)GetValue(SliderLineColorProperty); }
      set { SetValue(SliderLineColorProperty, value); }
    }
    public static readonly DependencyProperty SliderLineColorProperty =
        DependencyProperty.Register("SliderLineColor", typeof(Brush), typeof(CustomSlider), new PropertyMetadata(Brushes.Silver));
    
    public Brush MainSliderThumbColor
    {
      get { return (Brush)GetValue(MainSliderThumbColorProperty); }
      set { SetValue(MainSliderThumbColorProperty, value); }
    }
    public static readonly DependencyProperty MainSliderThumbColorProperty =
        DependencyProperty.Register("MainSliderThumbColor", typeof(Brush), typeof(CustomSlider), 
          new PropertyMetadata((SolidColorBrush)new BrushConverter().ConvertFromString("#FFAECBD1")));

    #endregion


    #endregion

    #region Property Changing
    public class SliderValueChangedRoutedEventArgs : RoutedEventArgs
    {
      public double oldValue;
      public double newValue;

      public SliderValueChangedRoutedEventArgs(RoutedEvent routedEvent, double oldValue, double newValue) : base(routedEvent)
      {
        this.oldValue = oldValue;
        this.newValue = newValue;
      }
    }

    private static void PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      CustomSlider slider = (CustomSlider)d;
      slider.UpdateMarkedFramesBorder();
    }

    public static readonly DependencyProperty MainValueProperty =
        DependencyProperty.Register("MainValue", typeof(double), typeof(CustomSlider), new UIPropertyMetadata(1d, new PropertyChangedCallback(PropertyChanged)));
    private void Main_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
      if (_preventRaiseVal_main) return;
      RaiseEvent(new SliderValueChangedRoutedEventArgs(OnMainValueChangedEvent, e.OldValue, e.NewValue));
    }
    public static readonly RoutedEvent OnMainValueChangedEvent = EventManager.RegisterRoutedEvent("OnMainValueChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(CustomSlider));
    public event RoutedEventHandler OnMainValueChanged
    {
      add { AddHandler(OnMainValueChangedEvent, value); }
      remove { RemoveHandler(OnMainValueChangedEvent, value); }
    }


    public static readonly DependencyProperty StartValueProperty =
        DependencyProperty.Register("StartValue", typeof(double), typeof(CustomSlider), new UIPropertyMetadata(1d, new PropertyChangedCallback(PropertyChanged)));
    private void Start_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
      if (_preventRaiseVal_start) return;
      RaiseEvent(new SliderValueChangedRoutedEventArgs(OnStartValueChangedEvent, e.OldValue, e.NewValue));
    }
    public static readonly RoutedEvent OnStartValueChangedEvent = EventManager.RegisterRoutedEvent("OnStartValueChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(CustomSlider));
    public event RoutedEventHandler OnStartValueChanged
    {
      add { AddHandler(OnStartValueChangedEvent, value); }
      remove { RemoveHandler(OnStartValueChangedEvent, value); }
    }


    public static readonly DependencyProperty EndValueProperty =
        DependencyProperty.Register("EndValue", typeof(double), typeof(CustomSlider), new UIPropertyMetadata(1d, new PropertyChangedCallback(PropertyChanged)));
    private void End_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
      if (_preventRaiseVal_end) return;
      RaiseEvent(new SliderValueChangedRoutedEventArgs(OnEndValueChangedEvent, e.OldValue, e.NewValue));
    }
    public static readonly RoutedEvent OnEndValueChangedEvent = EventManager.RegisterRoutedEvent("OnEndValueChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(CustomSlider));
    public event RoutedEventHandler OnEndValueChanged
    {
      add { AddHandler(OnEndValueChangedEvent, value); }
      remove { RemoveHandler(OnEndValueChangedEvent, value); }
    }
    
    

    #endregion

    public bool FreeSlidersMoving = false;
    private bool _preventRaiseVal_main = false;
    private bool _changeMainVal_noCondition = false;
    private double _mainValueConfirmed = 0;
    public double MainValue
    {
      get { return (double)GetValue(MainValueProperty); }
      set
      {
        _mainValueConfirmed = value;
        if (this.IsMouseCaptureWithin && !_changeMainVal_noCondition) return;
        //System.Diagnostics.Debug.WriteLine("MainValue postaje --------------  " + value.ToString());
        _preventRaiseVal_main = true;
        SetValue(MainValueProperty, value);
        _preventRaiseVal_main = false;
      }
    }


    private bool _preventRaiseVal_start = false;
    private bool _changeStartVal_noCondition = false;
    private double _startValueConfirmed = 0;
    public double StartValue
    {
      get { return (double)GetValue(StartValueProperty); }
      set
      {
        _startValueConfirmed = value;
        if (this.IsMouseCaptureWithin && !_changeStartVal_noCondition) return;
        //System.Diagnostics.Debug.WriteLine("MainValue postaje --------------  " + value.ToString());
        _preventRaiseVal_start = true;
        SetValue(StartValueProperty, value);
        _preventRaiseVal_start = false;
      }
    }

    public void SetStartValueNoAsk(double value)
    {
      _changeStartVal_noCondition = true;
      StartValue = value;
      _changeStartVal_noCondition = false;
    }

    public void SetEndValueNoAsk(double value)
    {
      _changeEndVal_noCondition = true;
      EndValue = value;
      _changeEndVal_noCondition = false;
    }

    private bool _preventRaiseVal_end = false;
    private bool _changeEndVal_noCondition = false;
    private double _endValueConfirmed = 0;
    public double EndValue
    {
      get { return (double)GetValue(EndValueProperty); }
      set
      {
        _endValueConfirmed = value;
        if (this.IsMouseCaptureWithin && !_changeEndVal_noCondition) return;
        _preventRaiseVal_end = true;
        SetValue(EndValueProperty, value);
        _preventRaiseVal_end = false;
      }
    }


    #region Constructor
    public CustomSlider()
    {
      this.InitializeComponent();

    }
    #endregion


    public void UpdateMarkedFramesBorder()
    {
      //sliderMain.Value = MainValue;
      //sliderStart.Value = StartValue;
      //sliderEnd.Value = EndValue;

      if (Maximum > Minimum) // zasto ovo
      {
        double mainPoint = (this.ActualWidth * (MainValue - Minimum)) / (Maximum - Minimum);
        double lowerPoint = (this.ActualWidth * (StartValue - Minimum)) / (Maximum - Minimum);
        double upperPoint = (this.ActualWidth * (EndValue - Minimum)) / (Maximum - Minimum);
        if (this.ActualWidth > 0) upperPoint = this.ActualWidth - upperPoint;
        //if (upperPoint < lowerPoint) lowerPoint = upperPoint;
        progressBorder.Margin = new Thickness(lowerPoint, LayoutRoot.ActualHeight / 2 + 3, upperPoint, LayoutRoot.ActualHeight / 2 - 6);

        ThumbStartMargin = new Thickness(-ThumbWidth / 2 + (lowerPoint / this.ActualWidth) * ThumbWidth, 0, 0, 0);
        ThumbEndMargin = new Thickness(ThumbWidth / 2 - (upperPoint / this.ActualWidth) * ThumbWidth, 0, 0, 0);
        ThumbMainMargin = new Thickness(-ThumbWidth / 2 + (mainPoint / this.ActualWidth) * ThumbWidth, 0, 0, 0);
      }
    }









    #region mouse up/down on sliders

    public static readonly RoutedEvent OnStartOrEndMouseUpEvent = EventManager.RegisterRoutedEvent("OnStartOrEndMouseUp", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(CustomSlider));

    public event RoutedEventHandler OnStartOrEndMouseUp
    {
      add { AddHandler(OnStartOrEndMouseUpEvent, value); }
      remove { RemoveHandler(OnStartOrEndMouseUpEvent, value); }
    }


    private void Start_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
      StartOrEndMouseUp();
    }



    private void End_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
      StartOrEndMouseUp();
    }

    private void StartOrEndMouseUp()
    {
      _changeEndVal_noCondition = true;
      if (!FreeSlidersMoving) this.EndValue = _endValueConfirmed;
      _changeEndVal_noCondition = false;
      _changeStartVal_noCondition = true;
      if (!FreeSlidersMoving)  this.StartValue = _startValueConfirmed;
      _changeStartVal_noCondition = false;
      RaiseEvent(new RoutedEventArgs(OnStartOrEndMouseUpEvent));
    }

    private void Main_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
      _changeMainVal_noCondition = true;
      this.MainValue = _mainValueConfirmed;
      _changeMainVal_noCondition = false;
    }



    #endregion

    private void UserControl_Loaded(object sender, RoutedEventArgs e)
    {
      UpdateMarkedFramesBorder();
    }
  }
}
