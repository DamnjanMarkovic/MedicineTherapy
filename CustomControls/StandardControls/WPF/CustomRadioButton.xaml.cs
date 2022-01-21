
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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CustomControls
{
    /// <summary>
    /// Interaction logic for CustomRadioButton.xaml
    /// </summary>
    public partial class CustomRadioButton : RadioButton, System.Windows.IInputElement, IButton
    {
        #region Properties


        public UIElement ThisUIElement
        {
            get { return this; }
        }
        #endregion

        #region Dependency properties
        public int CornerRadius
        {
            get { return (int)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(int), typeof(CustomRadioButton), new PropertyMetadata(null));
        
        public Brush BackgroundDisabled
        {
            get { return (Brush)GetValue(BackgroundDisabledProperty); }
            set { SetValue(BackgroundDisabledProperty, value); }
        }
        public static readonly DependencyProperty BackgroundDisabledProperty =
            DependencyProperty.Register("BackgroundDisabled", typeof(Brush), typeof(CustomRadioButton));
    public Image ImageDisabled
    {
      get { return (Image)GetValue(ImageDisabledProperty); }
      set { SetValue(ImageDisabledProperty, value); }
    }
    public static readonly DependencyProperty ImageDisabledProperty =
        DependencyProperty.Register("ImageDisabled", typeof(Image), typeof(CustomRadioButton));
    public SolidColorBrush BorderColorDisabled
        {
            get { return (SolidColorBrush)GetValue(BorderColorDisabledProperty); }
            set { SetValue(BorderColorDisabledProperty, value); }
        }
        public static readonly DependencyProperty BorderColorDisabledProperty =
            DependencyProperty.Register("BorderColorDisabled", typeof(SolidColorBrush), typeof(CustomRadioButton));
        
        public SolidColorBrush TextColorDisabled
        {
            get { return (SolidColorBrush)GetValue(TextColorDisabledProperty); }
            set { SetValue(TextColorDisabledProperty, value); }
        }
        public static readonly DependencyProperty TextColorDisabledProperty =
            DependencyProperty.Register("TextColorDisabled", typeof(SolidColorBrush), typeof(CustomRadioButton));

        public Brush BackgroundMouseOver
        {
            get { return (Brush)GetValue(BackgroundMouseOverProperty); }
            set { SetValue(BackgroundMouseOverProperty, value); }
        }
        public static readonly DependencyProperty BackgroundMouseOverProperty =
            DependencyProperty.Register("BackgroundMouseOver", typeof(Brush), typeof(CustomRadioButton));


        public SolidColorBrush BorderColorMouseOver
        {
            get { return (SolidColorBrush)GetValue(BorderColorMouseOverProperty); }
            set { SetValue(BorderColorMouseOverProperty, value); }
        }
        public static readonly DependencyProperty BorderColorMouseOverProperty =
            DependencyProperty.Register("BorderColorMouseOver", typeof(SolidColorBrush), typeof(CustomRadioButton));

        public SolidColorBrush TextColorMouseOver
        {
            get { return (SolidColorBrush)GetValue(TextColorMouseOverProperty); }
            set { SetValue(TextColorMouseOverProperty, value); }
        }
        public static readonly DependencyProperty TextColorMouseOverProperty =
            DependencyProperty.Register("TextColorMouseOver", typeof(SolidColorBrush), typeof(CustomRadioButton));
        
        public Brush BackgroundChecked
        {
            get { return (Brush)GetValue(BackgroundCheckedProperty); }
            set { SetValue(BackgroundCheckedProperty, value); }
        }
        public static readonly DependencyProperty BackgroundCheckedProperty =
            DependencyProperty.Register("BackgroundChecked", typeof(Brush), typeof(CustomRadioButton));
        
        public SolidColorBrush BorderColorChecked
        {
            get { return (SolidColorBrush)GetValue(BorderColorCheckedProperty); }
            set { SetValue(BorderColorCheckedProperty, value); }
        }
        public static readonly DependencyProperty BorderColorCheckedProperty =
            DependencyProperty.Register("BorderColorChecked", typeof(SolidColorBrush), typeof(CustomRadioButton));
        
        public SolidColorBrush TextColorChecked
        {
            get { return (SolidColorBrush)GetValue(TextColorCheckedProperty); }
            set { SetValue(TextColorCheckedProperty, value); }
        }
        public static readonly DependencyProperty TextColorCheckedProperty =
            DependencyProperty.Register("TextColorChecked", typeof(SolidColorBrush), typeof(CustomRadioButton));
        
        public double DropShadowEffectBlur
        {
            get { return (double)GetValue(DropShadowEffectBlurProperty); }
            set { SetValue(DropShadowEffectBlurProperty, value); }
        }
        public static readonly DependencyProperty DropShadowEffectBlurProperty =
            DependencyProperty.Register("DropShadowEffectBlur", typeof(double), typeof(CustomRadioButton));
        
        public double DropShadowEffectOpacity
        {
            get { return (double)GetValue(DropShadowEffectOpacityProperty); }
            set { SetValue(DropShadowEffectOpacityProperty, value); }
        }
        public static readonly DependencyProperty DropShadowEffectOpacityProperty =
            DependencyProperty.Register("DropShadowEffectOpacity", typeof(double), typeof(CustomRadioButton));
        
        public Color DropShadowEffectColor
        {
            get { return (Color)GetValue(DropShadowEffectColorProperty); }
            set { SetValue(DropShadowEffectColorProperty, value); }
        }
        public static readonly DependencyProperty DropShadowEffectColorProperty =
            DependencyProperty.Register("DropShadowEffectColor", typeof(Color), typeof(CustomRadioButton));
        
        public double DropShadowEffectShadowDepth
        {
            get { return (double)GetValue(DropShadowEffectShadowDepthProperty); }
            set { SetValue(DropShadowEffectShadowDepthProperty, value); }
        }
        public static readonly DependencyProperty DropShadowEffectShadowDepthProperty =
            DependencyProperty.Register("DropShadowEffectShadowDepth", typeof(double), typeof(CustomRadioButton));

        public Image OriginalImageColored
        {
            get { return (Image)GetValue(OriginalImageColoredProperty); }
            set { SetValue(OriginalImageColoredProperty, value); }
        }
        public static readonly DependencyProperty OriginalImageColoredProperty =
            DependencyProperty.Register("OriginalImageColored", typeof(Image), typeof(CustomRadioButton));
        
        public Image ImageOnChecked
        {
            get { return (Image)GetValue(ImageOnCheckedProperty); }
            set { SetValue(ImageOnCheckedProperty, value); }
        }
        public static readonly DependencyProperty ImageOnCheckedProperty =
            DependencyProperty.Register("ImageOnChecked", typeof(Image), typeof(CustomRadioButton));
        
        public Image ImageOnMouseOver
        {
            get { return (Image)GetValue(ImageOnMouseOverProperty); }
            set { SetValue(ImageOnMouseOverProperty, value); }
        }
        public static readonly DependencyProperty ImageOnMouseOverProperty =
            DependencyProperty.Register("ImageOnMouseOver", typeof(Image), typeof(CustomRadioButton));
        
        public ContentPresenter CheckedContentPresenter
        {
            get { return (ContentPresenter)GetValue(CheckedContentPresenterProperty); }
            set { SetValue(CheckedContentPresenterProperty, value); }
        }
        public static readonly DependencyProperty CheckedContentPresenterProperty =
            DependencyProperty.Register("CheckedContentPresenter", typeof(ContentPresenter), typeof(CustomRadioButton));

    public ContentPresenter DisabledContentPresenter
    {
      get { return (ContentPresenter)GetValue(DisabledContentPresenterProperty); }
      set { SetValue(DisabledContentPresenterProperty, value); }
    }
    public static readonly DependencyProperty DisabledContentPresenterProperty =
        DependencyProperty.Register("DisabledContentPresenter", typeof(ContentPresenter), typeof(CustomRadioButton));

    public Grid CanvasDisabled
    {
      get { return (Grid)GetValue(CanvasDisabledProperty); }
      set { SetValue(CanvasDisabledProperty, value); }
    }
    public static readonly DependencyProperty CanvasDisabledProperty =
        DependencyProperty.Register("CanvasDisabled", typeof(Grid), typeof(CustomRadioButton));
    public ContentPresenter MouseOverContentPresenter
        {
            get { return (ContentPresenter)GetValue(MouseOverContentPresenterProperty); }
            set { SetValue(MouseOverContentPresenterProperty, value); }
        }
        public static readonly DependencyProperty MouseOverContentPresenterProperty =
            DependencyProperty.Register("MouseOverContentPresenter", typeof(ContentPresenter), typeof(CustomRadioButton));
        
        public Grid CanvasContent
        {
            get { return (Grid)GetValue(CanvasContentProperty); }
            set { SetValue(CanvasContentProperty, value); }
        }
        public static readonly DependencyProperty CanvasContentProperty =
            DependencyProperty.Register("CanvasContent", typeof(Grid), typeof(CustomRadioButton));
        
        public Grid CanvasMouseOver
        {
            get { return (Grid)GetValue(CanvasMouseOverProperty); }
            set { SetValue(CanvasMouseOverProperty, value); }
        }
        public static readonly DependencyProperty CanvasMouseOverProperty =
            DependencyProperty.Register("CanvasMouseOver", typeof(Grid), typeof(CustomRadioButton));
        
        public Grid CanvasChecked
        {
            get { return (Grid)GetValue(CanvasCheckedProperty); }
            set { SetValue(CanvasCheckedProperty, value); }
        }
        public static readonly DependencyProperty CanvasCheckedProperty =
            DependencyProperty.Register("CanvasChecked", typeof(Grid), typeof(CustomRadioButton));

        public Thickness MarginImage
        {
            get { return (Thickness)GetValue(MarginImageProperty); }
            set { SetValue(MarginImageProperty, value); }
        }
        public static readonly DependencyProperty MarginImageProperty =
            DependencyProperty.Register("MarginImage", typeof(Thickness), typeof(CustomRadioButton));
        
        public Geometry PathDataValue
        {
            get { return (Geometry)GetValue(PathDataValueProperty); }
            set { SetValue(PathDataValueProperty, value); }
        }
        public static readonly DependencyProperty PathDataValueProperty =
            DependencyProperty.Register("PathDataValue", typeof(Geometry), typeof(CustomRadioButton));

        public ContentPresenter KeyboardFocusedContentPresenter
        {
            get { return (ContentPresenter)GetValue(KeyboardFocusedContentPresenterProperty); }
            set { SetValue(KeyboardFocusedContentPresenterProperty, value); }
        }
        public static readonly DependencyProperty KeyboardFocusedContentPresenterProperty =
            DependencyProperty.Register("KeyboardFocusedContentPresenter", typeof(ContentPresenter), typeof(CustomRadioButton));

        public Grid CanvasKeyboardFocused
        {
            get { return (Grid)GetValue(CanvasKeyboardFocusedProperty); }
            set { SetValue(CanvasKeyboardFocusedProperty, value); }
        }
        public static readonly DependencyProperty CanvasKeyboardFocusedProperty =
            DependencyProperty.Register("CanvasKeyboardFocused", typeof(Grid), typeof(CustomRadioButton));

        public Image ImageOnKeyboardFocused
        {
            get { return (Image)GetValue(ImageOnKeyboardFocusedProperty); }
            set { SetValue(ImageOnKeyboardFocusedProperty, value); }
        }
        public static readonly DependencyProperty ImageOnKeyboardFocusedProperty =
            DependencyProperty.Register("ImageOnKeyboardFocused", typeof(Image), typeof(CustomRadioButton));

        public object Content
        {
            get { return (object)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }
        public static readonly DependencyProperty ContentProperty =
            DependencyProperty.Register("Content", typeof(object), typeof(CustomRadioButton),
                new FrameworkPropertyMetadata(new PropertyChangedCallback(OnContentChanged)));
        #endregion

        #region Events
        public event DependencyPropertyChangedEventHandler ContentChanged;

        #endregion

        #region Constructor

        public CustomRadioButton()
        {
            InitializeComponent();
            StaticProperties.SetCommonStyle(CustomRadioButtonStyle.Instance, this);
            ContentChanged += CustomButton_ContentChanged;
        }

        #endregion

        #region OnLoading
        private void RadioButton_Loaded(object sender, RoutedEventArgs e)
        {
            Loaded -= RadioButton_Loaded;
            IButtonValuesImplementation.SetButtonContent<CustomRadioButton>(this, null, ButtonHandling.Instantiating);
        }
        #endregion

        #region Content Changed
        private static void OnContentChanged(DependencyObject dObject, DependencyPropertyChangedEventArgs e)
        {
            CustomRadioButton thisButton = dObject as CustomRadioButton;
            thisButton?.ContentChanged?.Invoke(thisButton,
                  new DependencyPropertyChangedEventArgs(ContentProperty, e.OldValue, e.NewValue));
        }

        private void CustomButton_ContentChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            CustomRadioButton senderButton = sender as CustomRadioButton;
            IButtonValuesImplementation.SetButtonContent<CustomRadioButton>(senderButton, e.NewValue, ButtonHandling.Updating);
        }
        #endregion

    }
}


