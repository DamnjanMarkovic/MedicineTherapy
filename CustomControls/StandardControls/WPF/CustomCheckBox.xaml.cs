
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
    /// Interaction logic for CustomCheckBox.xaml
    /// </summary>
    public partial class CustomCheckBox : CheckBox, IButton
    {
        #region Dependency properties
        public Brush BackgroundMouseOver
        {
            get { return (Brush)GetValue(BackgroundMouseOverProperty); }
            set { SetValue(BackgroundMouseOverProperty, value); }
        }
        public static readonly DependencyProperty BackgroundMouseOverProperty =
            DependencyProperty.Register("BackgroundMouseOver", typeof(Brush), typeof(CustomCheckBox));

        public SolidColorBrush BorderColorMouseOver
        {
            get { return (SolidColorBrush)GetValue(BorderColorMouseOverProperty); }
            set { SetValue(BorderColorMouseOverProperty, value); }
        }
        public static readonly DependencyProperty BorderColorMouseOverProperty =
            DependencyProperty.Register("BorderColorMouseOver", typeof(SolidColorBrush), typeof(CustomCheckBox));
        
        public SolidColorBrush TextColorMouseOver
        {
            get { return (SolidColorBrush)GetValue(TextColorMouseOverProperty); }
            set { SetValue(TextColorMouseOverProperty, value); }
        }
        public static readonly DependencyProperty TextColorMouseOverProperty =
            DependencyProperty.Register("TextColorMouseOver", typeof(SolidColorBrush), typeof(CustomCheckBox));

  
        public Brush BackgroundChecked
        {
            get { return (Brush)GetValue(BackgroundCheckedProperty); }
            set { SetValue(BackgroundCheckedProperty, value); }
        }
        public static readonly DependencyProperty BackgroundCheckedProperty =
            DependencyProperty.Register("BackgroundChecked", typeof(Brush), typeof(CustomCheckBox));

        public SolidColorBrush BorderColorChecked
        {
            get { return (SolidColorBrush)GetValue(BorderColorCheckedProperty); }
            set { SetValue(BorderColorCheckedProperty, value); }
        }
        public static readonly DependencyProperty BorderColorCheckedProperty =
            DependencyProperty.Register("BorderColorChecked", typeof(SolidColorBrush), typeof(CustomCheckBox));
        
        public SolidColorBrush TextColorChecked
        {
            get { return (SolidColorBrush)GetValue(TextColorCheckedProperty); }
            set { SetValue(TextColorCheckedProperty, value); }
        }
        public static readonly DependencyProperty TextColorCheckedProperty =
            DependencyProperty.Register("TextColorChecked", typeof(SolidColorBrush), typeof(CustomCheckBox));
        
        public Brush BackgroundDisabled
        {
            get { return (Brush)GetValue(BackgroundDisabledProperty); }
            set { SetValue(BackgroundDisabledProperty, value); }
        }
        public static readonly DependencyProperty BackgroundDisabledProperty =
            DependencyProperty.Register("BackgroundDisabled", typeof(Brush), typeof(CustomCheckBox));
        public SolidColorBrush BorderColorDisabled
        {
            get { return (SolidColorBrush)GetValue(BorderColorDisabledProperty); }
            set { SetValue(BorderColorDisabledProperty, value); }
        }
        public static readonly DependencyProperty BorderColorDisabledProperty =
            DependencyProperty.Register("BorderColorDisabled", typeof(SolidColorBrush), typeof(CustomCheckBox));
        
        public SolidColorBrush TextColorDisabled
        {
            get { return (SolidColorBrush)GetValue(TextColorDisabledProperty); }
            set { SetValue(TextColorDisabledProperty, value); }
        }
        public static readonly DependencyProperty TextColorDisabledProperty =
            DependencyProperty.Register("TextColorDisabled", typeof(SolidColorBrush), typeof(CustomCheckBox));
        
        public Brush MarkCheckedColor
        {
            get { return (Brush)GetValue(MarkCheckedColorProperty); }
            set { SetValue(MarkCheckedColorProperty, value); }
        }
        public static readonly DependencyProperty MarkCheckedColorProperty =
            DependencyProperty.Register("MarkCheckedColor", typeof(Brush), typeof(CustomCheckBox));

        public ContentPresenter KeyboardFocusedContentPresenter
        {
            get { return (ContentPresenter)GetValue(KeyboardFocusedContentPresenterProperty); }
            set { SetValue(KeyboardFocusedContentPresenterProperty, value); }
        }
        public static readonly DependencyProperty KeyboardFocusedContentPresenterProperty =
            DependencyProperty.Register("KeyboardFocusedContentPresenter", typeof(ContentPresenter), typeof(CustomCheckBox));

        public Grid CanvasKeyboardFocused
        {
            get { return (Grid)GetValue(CanvasKeyboardFocusedProperty); }
            set { SetValue(CanvasKeyboardFocusedProperty, value); }
        }
        public static readonly DependencyProperty CanvasKeyboardFocusedProperty =
            DependencyProperty.Register("CanvasKeyboardFocused", typeof(Grid), typeof(CustomCheckBox));

    public Image ImageDisabled
    {
      get { return (Image)GetValue(ImageDisabledProperty); }
      set { SetValue(ImageDisabledProperty, value); }
    }
    public static readonly DependencyProperty ImageDisabledProperty =
        DependencyProperty.Register("ImageDisabled", typeof(Image), typeof(CustomCheckBox));
    public Image ImageOnKeyboardFocused
        {
            get { return (Image)GetValue(ImageOnKeyboardFocusedProperty); }
            set { SetValue(ImageOnKeyboardFocusedProperty, value); }
        }
        public static readonly DependencyProperty ImageOnKeyboardFocusedProperty =
            DependencyProperty.Register("ImageOnKeyboardFocused", typeof(Image), typeof(CustomCheckBox));
        
        public SolidColorBrush ForegroundColorInvertedBackground
        {
            get { return (SolidColorBrush)GetValue(ForegroundColorInvertedBackgroundProperty); }
            set { SetValue(ForegroundColorInvertedBackgroundProperty, value); }
        }
        public static readonly DependencyProperty ForegroundColorInvertedBackgroundProperty =
            DependencyProperty.Register("ForegroundColorInvertedBackground", typeof(SolidColorBrush), typeof(Brush));
        
        public Image ImageOnChecked
        {
            get { return (Image)GetValue(ImageOnCheckedProperty); }
            set { SetValue(ImageOnCheckedProperty, value); }
        }
        public static readonly DependencyProperty ImageOnCheckedProperty =
            DependencyProperty.Register("ImageOnChecked", typeof(Image), typeof(CustomCheckBox));
        
        public int CornerRadius
        {
            get { return (int)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(int), typeof(CustomCheckBox));

        public ContentPresenter CheckedContentPresenter
        {
            get { return (ContentPresenter)GetValue(CheckedContentPresenterProperty); }
            set { SetValue(CheckedContentPresenterProperty, value); }
        }
        public static readonly DependencyProperty CheckedContentPresenterProperty =
            DependencyProperty.Register("CheckedContentPresenter", typeof(ContentPresenter), typeof(CustomCheckBox));
        
        public ContentPresenter MouseOverContentPresenter
        {
            get { return (ContentPresenter)GetValue(MouseOverContentPresenterProperty); }
            set { SetValue(MouseOverContentPresenterProperty, value); }
        }
        public static readonly DependencyProperty MouseOverContentPresenterProperty =
            DependencyProperty.Register("MouseOverContentPresenter", typeof(ContentPresenter), typeof(CustomCheckBox));
        
        public Grid CanvasContent
        {
            get { return (Grid)GetValue(CanvasContentProperty); }
            set { SetValue(CanvasContentProperty, value); }
        }
        public static readonly DependencyProperty CanvasContentProperty =
            DependencyProperty.Register("CanvasContent", typeof(Grid), typeof(CustomCheckBox));
    public ContentPresenter DisabledContentPresenter
    {
      get { return (ContentPresenter)GetValue(DisabledContentPresenterProperty); }
      set { SetValue(DisabledContentPresenterProperty, value); }
    }
    public static readonly DependencyProperty DisabledContentPresenterProperty =
        DependencyProperty.Register("DisabledContentPresenter", typeof(ContentPresenter), typeof(CustomCheckBox));

    public Grid CanvasDisabled
    {
      get { return (Grid)GetValue(CanvasDisabledProperty); }
      set { SetValue(CanvasDisabledProperty, value); }
    }
    public static readonly DependencyProperty CanvasDisabledProperty =
        DependencyProperty.Register("CanvasDisabled", typeof(Grid), typeof(CustomCheckBox));

    public Grid CanvasMouseOver
        {
            get { return (Grid)GetValue(CanvasMouseOverProperty); }
            set { SetValue(CanvasMouseOverProperty, value); }
        }
        public static readonly DependencyProperty CanvasMouseOverProperty =
            DependencyProperty.Register("CanvasMouseOver", typeof(Grid), typeof(CustomCheckBox));
        
        public Grid CanvasChecked
        {
            get { return (Grid)GetValue(CanvasCheckedProperty); }
            set { SetValue(CanvasCheckedProperty, value); }
        }
        public static readonly DependencyProperty CanvasCheckedProperty =
            DependencyProperty.Register("CanvasChecked", typeof(Grid), typeof(CustomCheckBox));

        public Geometry PathDataValue
        {
            get { return (Geometry)GetValue(PathDataValueProperty); }
            set { SetValue(PathDataValueProperty, value); }
        }

        public static readonly DependencyProperty PathDataValueProperty =
            DependencyProperty.Register("PathDataValue", typeof(Geometry), typeof(CustomCheckBox));

        public Image ImageOnMouseOver
        {
            get { return (Image)GetValue(ImageOnMouseOverProperty); }
            set { SetValue(ImageOnMouseOverProperty, value); }
        }
        public static readonly DependencyProperty ImageOnMouseOverProperty =
            DependencyProperty.Register("ImageOnMouseOver", typeof(Image), typeof(CustomCheckBox));
        
        public Thickness MarginImage
        {
            get { return (Thickness)GetValue(MarginImageProperty); }
            set { SetValue(MarginImageProperty, value); }
        }

        public static readonly DependencyProperty MarginImageProperty =
            DependencyProperty.Register("MarginImage", typeof(Thickness), typeof(CustomCheckBox));

        private static void OnContentChanged(DependencyObject dObject, DependencyPropertyChangedEventArgs e)
        {
            var thisButton = dObject as CustomCheckBox;
            thisButton?.ContentChanged?.Invoke(thisButton,
                  new DependencyPropertyChangedEventArgs(ContentProperty, e.OldValue, e.NewValue));
        }

        public object Content
        {
            get { return (object)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }
        public static readonly DependencyProperty ContentProperty =
            DependencyProperty.Register("Content", typeof(object), typeof(CustomCheckBox),
                new FrameworkPropertyMetadata(new PropertyChangedCallback(OnContentChanged)));
        #endregion

        #region Events
        public event DependencyPropertyChangedEventHandler ContentChanged;
        #endregion

        #region Constructor
        public CustomCheckBox()
        {
            InitializeComponent();
            StaticProperties.SetCommonStyle(CustomCheckBoxStyle.Instance, this);
            ContentChanged += CustomButton_ContentChanged;
        }
        #endregion

        #region OnLoading
        private void CheckBox_Loaded(object sender, RoutedEventArgs e)
        {
            Loaded -= CheckBox_Loaded;
            if (Foreground == CustomCheckBoxStyle.Instance.Foreground)
                Foreground = new SolidColorBrush(ImagesHandling.ReturnInvertedMediaColor((Background as SolidColorBrush).Color));
            if (ForegroundColorInvertedBackground == null && BackgroundChecked != null)
                ForegroundColorInvertedBackground = new SolidColorBrush(ImagesHandling.ReturnInvertedMediaColor((BackgroundChecked as SolidColorBrush).Color));

            IButtonValuesImplementation.SetButtonContent<CustomCheckBox>(this, null, ButtonHandling.Instantiating);
        }
        #endregion

        #region Content Changed
        private void CustomButton_ContentChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var senderButton = sender as CustomCheckBox;
            IButtonValuesImplementation.SetButtonContent<CustomCheckBox>(senderButton, e.NewValue, ButtonHandling.Updating);
        }

        #endregion        

    }
}

