
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
    /// Interaction logic for CustomComboBox.xaml
    /// </summary>
    public partial class CustomComboBox : ComboBox
    {
        #region Properties

        public UIElement ThisUIElement
        {
            get { return this; }
        }

        private Brush OriginalBackground { get; set; }
        private Brush OriginalForeground { get; set; }
        private Brush OriginalBorderBrush { get; set; }

        public Color TextColorDisabledColor { get; set; }

        #endregion

        #region Dependency properties
        public SolidColorBrush BorderBrushItems
        {
            get { return (SolidColorBrush)GetValue(BorderBrushItemsProperty); }
            set { SetValue(BorderBrushItemsProperty, value); }
        }
        public static readonly DependencyProperty BorderBrushItemsProperty =
            DependencyProperty.Register("BorderBrushItems", typeof(SolidColorBrush), typeof(CustomComboBox));
        
        public string TextOnEmptyField
        {
            get { return (string)GetValue(TextOnEmptyFieldProperty); }
            set { SetValue(TextOnEmptyFieldProperty, value); }
        }
        public static readonly DependencyProperty TextOnEmptyFieldProperty =
            DependencyProperty.Register("TextOnEmptyField", typeof(string), typeof(CustomComboBox));

        public bool ManualResetEnabled
        {
            get { return (bool)GetValue(ManualResetEnabledProperty); }
            set { SetValue(ManualResetEnabledProperty, value); }
        }
        public static readonly DependencyProperty ManualResetEnabledProperty =
            DependencyProperty.Register("ManualResetEnabled", typeof(bool), typeof(CustomComboBox));
        
        public int CornerRadius
        {
            get { return (int)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(int), typeof(CustomComboBox));
        
        public Thickness BorderThicknessItems
        {
            get { return (Thickness)GetValue(BorderThicknessItemsProperty); }
            set { SetValue(BorderThicknessItemsProperty, value); }
        }
        public static readonly DependencyProperty BorderThicknessItemsProperty =
            DependencyProperty.Register("BorderThicknessItems", typeof(Thickness), typeof(CustomComboBox));
        
        public Brush BackgroundMouseOverItems
        {
            get { return (Brush)GetValue(BackgroundMouseOverItemsProperty); }
            set { SetValue(BackgroundMouseOverItemsProperty, value); }
        }
        public static readonly DependencyProperty BackgroundMouseOverItemsProperty =
            DependencyProperty.Register("BackgroundMouseOverItems", typeof(Brush), typeof(CustomComboBox));
        
        public Brush BackgroundItems
        {
            get { return (Brush)GetValue(BackgroundItemsProperty); }
            set { SetValue(BackgroundItemsProperty, value); }
        }
        public static readonly DependencyProperty BackgroundItemsProperty =
            DependencyProperty.Register("BackgroundItems", typeof(Brush), typeof(CustomComboBox));
        
        public SolidColorBrush BorderColorMouseOver
        {
            get { return (SolidColorBrush)GetValue(BorderColorMouseOverProperty); }
            set { SetValue(BorderColorMouseOverProperty, value); }
        }
        public static readonly DependencyProperty BorderColorMouseOverProperty =
            DependencyProperty.Register("BorderColorMouseOver", typeof(SolidColorBrush), typeof(CustomComboBox));

        public Brush BackgroundMouseOver
        {
            get { return (Brush)GetValue(BackgroundMouseOverProperty); }
            set { SetValue(BackgroundMouseOverProperty, value); }
        }
        public static readonly DependencyProperty BackgroundMouseOverProperty =
            DependencyProperty.Register("BackgroundMouseOver", typeof(Brush), typeof(CustomComboBox));
        
        public SolidColorBrush TextColorMouseOver
        {
            get { return (SolidColorBrush)GetValue(TextColorMouseOverProperty); }
            set { SetValue(TextColorMouseOverProperty, value); }
        }
        public static readonly DependencyProperty TextColorMouseOverProperty =
            DependencyProperty.Register("TextColorMouseOver", typeof(SolidColorBrush), typeof(CustomComboBox));

        public Brush BackgroundDisabled
        {
            get { return (Brush)GetValue(BackgroundDisabledProperty); }
            set { SetValue(BackgroundDisabledProperty, value); }
        }
        public static readonly DependencyProperty BackgroundDisabledProperty =
            DependencyProperty.Register("BackgroundDisabled", typeof(Brush), typeof(CustomComboBox));
        
        public SolidColorBrush BorderColorDisabled
        {
            get { return (SolidColorBrush)GetValue(BorderColorDisabledProperty); }
            set { SetValue(BorderColorDisabledProperty, value); }
        }
        public static readonly DependencyProperty BorderColorDisabledProperty =
            DependencyProperty.Register("BorderColorDisabled", typeof(SolidColorBrush), typeof(CustomComboBox));
        
        public SolidColorBrush TextColorDisabled
        {
            get { return (SolidColorBrush)GetValue(TextColorDisabledProperty); }
            set { SetValue(TextColorDisabledProperty, value); }
        }
        public static readonly DependencyProperty TextColorDisabledProperty =
            DependencyProperty.Register("TextColorDisabled", typeof(SolidColorBrush), typeof(CustomComboBox));

        public Brush BackgroundChecked
        {
            get { return (Brush)GetValue(BackgroundCheckedProperty); }
            set { SetValue(BackgroundCheckedProperty, value); }
        }
        public static readonly DependencyProperty BackgroundCheckedProperty =
            DependencyProperty.Register("BackgroundChecked", typeof(Brush), typeof(CustomComboBox));
        
        public Brush BackgroundItemsChecked
        {
            get { return (Brush)GetValue(BackgroundItemsCheckedProperty); }
            set { SetValue(BackgroundItemsCheckedProperty, value); }
        }public static readonly DependencyProperty BackgroundItemsCheckedProperty =
            DependencyProperty.Register("BackgroundItemsChecked", typeof(Brush), typeof(CustomComboBox));

        public SolidColorBrush TextItemsColorChecked
        {
            get { return (SolidColorBrush)GetValue(TextItemsColorCheckedProperty); }
            set { SetValue(TextItemsColorCheckedProperty, value); }
        }
        public static readonly DependencyProperty TextItemsColorCheckedProperty =
            DependencyProperty.Register("TextItemsColorChecked", typeof(SolidColorBrush), typeof(CustomComboBox));
        
        public SolidColorBrush BorderColorChecked
        {
            get { return (SolidColorBrush)GetValue(BorderColorCheckedProperty); }
            set { SetValue(BorderColorCheckedProperty, value); }
        }
        public static readonly DependencyProperty BorderColorCheckedProperty =
            DependencyProperty.Register("BorderColorChecked", typeof(SolidColorBrush), typeof(CustomComboBox));
        
        public SolidColorBrush TextColorChecked
        {
            get { return (SolidColorBrush)GetValue(TextColorCheckedProperty); }
            set { SetValue(TextColorCheckedProperty, value); }
        }
        public static readonly DependencyProperty TextColorCheckedProperty =
            DependencyProperty.Register("TextColorChecked", typeof(SolidColorBrush), typeof(CustomComboBox));
        
        public SolidColorBrush TextColorPlaceHolder
        {
            get { return (SolidColorBrush)GetValue(TextColorPlaceHolderProperty); }
            set { SetValue(TextColorPlaceHolderProperty, value); }
        }
        public static readonly DependencyProperty TextColorPlaceHolderProperty =
            DependencyProperty.Register("TextColorPlaceHolder", typeof(SolidColorBrush), typeof(CustomComboBox));



    public Thickness MarginImage
    {
      get { return (Thickness)GetValue(MarginImageProperty); }
      set { SetValue(MarginImageProperty, value); }
    }
    public static readonly DependencyProperty MarginImageProperty =
        DependencyProperty.Register("MarginImage", typeof(Thickness), typeof(CustomComboBox), 
          new PropertyMetadata(new Thickness(0)));


    public Thickness MarginImageChecked
    {
      get { return (Thickness)GetValue(MarginImageCheckedProperty); }
      set { SetValue(MarginImageCheckedProperty, value); }
    }
    public static readonly DependencyProperty MarginImageCheckedProperty =
        DependencyProperty.Register("MarginImageChecked", typeof(Thickness), typeof(CustomComboBox), 
          new PropertyMetadata(new Thickness(0)));



    public Geometry PathData
    {
      get { return (Geometry)GetValue(PathDataProperty); }
      set { SetValue(PathDataProperty, value); }
    }
    public static readonly DependencyProperty PathDataProperty =
        DependencyProperty.Register("PathData", typeof(Geometry), typeof(CustomComboBox), 
          new PropertyMetadata(ImagesPaths.TriangleExpander));


    public Geometry PathDataChecked
    {
      get { return (Geometry)GetValue(PathDataCheckedProperty); }
      set { SetValue(PathDataCheckedProperty, value); }
    }
    public static readonly DependencyProperty PathDataCheckedProperty =
        DependencyProperty.Register("PathDataChecked", typeof(Geometry), typeof(CustomComboBox), 
          new PropertyMetadata(ImagesPaths.TriangleExpanderChecked));


    public Brush ForegroundChecked
    {
      get { return (Brush)GetValue(ForegroundCheckedProperty); }
      set { SetValue(ForegroundCheckedProperty, value); }
    }
    public static readonly DependencyProperty ForegroundCheckedProperty =
        DependencyProperty.Register("ForegroundChecked", typeof(Brush), typeof(CustomComboBox), 
          new PropertyMetadata(Brushes.White));






    #endregion

    #region Constructor
    public CustomComboBox()
        {
            InitializeComponent();
            StaticProperties.SetCommonStyle(CustomComboBoxStyle.Instance, this);
            SelectionChanged += CustomComboBox_SelectionChanged;
            SetOriginalValues();

        }
        #endregion

        #region OnLoading
        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            Loaded -= ComboBox_Loaded;
            if (this.SelectedIndex < 1) SetOriginalValues();

    }
    private void SetOriginalValues()
        {
            OriginalBackground = Background;
            OriginalForeground = Foreground;
            OriginalBorderBrush = BorderBrush;
        }
        #endregion

        #region Content Changed

        private void CustomComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CustomComboBox comboBoxSelectionChanged = (CustomComboBox)sender;
            int itemSelected = comboBoxSelectionChanged.SelectedIndex;
            if ((itemSelected == 0 && ManualResetEnabled) || comboBoxSelectionChanged.SelectedValue == null)
            {
                Background = OriginalBackground;
                Foreground = OriginalForeground;
                BorderBrush = OriginalBorderBrush;
            }
            else
            {
                Background = BackgroundChecked;
                Foreground = TextColorChecked;
                BorderBrush = BorderColorChecked;
            }
        }

        #endregion

    }
}

