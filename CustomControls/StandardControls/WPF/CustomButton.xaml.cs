
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for CustomButton.xaml
    /// </summary>
    public partial class CustomButton : Button, IButton
    {

        #region Dependency properties

    public string TextOnEmptyField
        {
            get { return (string)GetValue(TextOnEmptyFieldProperty); }
            set { SetValue(TextOnEmptyFieldProperty, value); }
        }
        public static readonly DependencyProperty TextOnEmptyFieldProperty =
            DependencyProperty.Register("TextOnEmptyField", typeof(string), typeof(CustomButton));


        public int CornerRadius
        {
            get { return (int)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(int), typeof(CustomButton));

    public Image ImageDisabled
    {
      get { return (Image)GetValue(ImageDisabledProperty); }
      set { SetValue(ImageDisabledProperty, value); }
    }
    public static readonly DependencyProperty ImageDisabledProperty =
        DependencyProperty.Register("ImageDisabled", typeof(Image), typeof(CustomButton));
    public SolidColorBrush BorderColorMouseOver
        {
            get { return (SolidColorBrush)GetValue(BorderColorMouseOverProperty); }
            set { SetValue(BorderColorMouseOverProperty, value); }
        }
        public static readonly DependencyProperty BorderColorMouseOverProperty =
            DependencyProperty.Register("BorderColorMouseOver", typeof(SolidColorBrush), typeof(CustomButton));

        public Brush BackgroundMouseOver
        {
            get { return (Brush)GetValue(BackgroundMouseOverProperty); }
            set { SetValue(BackgroundMouseOverProperty, value); }
        }
        public static readonly DependencyProperty BackgroundMouseOverProperty =
            DependencyProperty.Register("BackgroundMouseOver", typeof(Brush), typeof(CustomButton));


        public SolidColorBrush TextColorMouseOver
        {
            get { return (SolidColorBrush)GetValue(TextColorMouseOverProperty); }
            set { SetValue(TextColorMouseOverProperty, value); }
        }
        public static readonly DependencyProperty TextColorMouseOverProperty =
            DependencyProperty.Register("TextColorMouseOver", typeof(SolidColorBrush), typeof(CustomButton));
        

        public Brush BackgroundDisabled
        {
            get { return (Brush)GetValue(BackgroundDisabledProperty); }
            set { SetValue(BackgroundDisabledProperty, value); }
        }
        public static readonly DependencyProperty BackgroundDisabledProperty =
            DependencyProperty.Register("BackgroundDisabled", typeof(Brush), typeof(CustomButton));


        public SolidColorBrush BorderColorDisabled
        {
            get { return (SolidColorBrush)GetValue(BorderColorDisabledProperty); }
            set { SetValue(BorderColorDisabledProperty, value); }
        }
        public static readonly DependencyProperty BorderColorDisabledProperty =
            DependencyProperty.Register("BorderColorDisabled", typeof(SolidColorBrush), typeof(CustomButton));


        public SolidColorBrush TextColorDisabled
        {
            get { return (SolidColorBrush)GetValue(TextColorDisabledProperty); }
            set { SetValue(TextColorDisabledProperty, value); }
        }
        public static readonly DependencyProperty TextColorDisabledProperty =
            DependencyProperty.Register("TextColorDisabled", typeof(SolidColorBrush), typeof(CustomButton));



        public Brush BackgroundChecked
        {
            get { return (Brush)GetValue(BackgroundCheckedProperty); }
            set { SetValue(BackgroundCheckedProperty, value); }
        }
        public static readonly DependencyProperty BackgroundCheckedProperty =
            DependencyProperty.Register("BackgroundChecked", typeof(Brush), typeof(CustomButton));


        public SolidColorBrush BorderColorChecked
        {
            get { return (SolidColorBrush)GetValue(BorderColorCheckedProperty); }
            set { SetValue(BorderColorCheckedProperty, value); }
        }
        public static readonly DependencyProperty BorderColorCheckedProperty =
            DependencyProperty.Register("BorderColorChecked", typeof(SolidColorBrush), typeof(CustomButton));


        public SolidColorBrush TextColorChecked
        {
            get { return (SolidColorBrush)GetValue(TextColorCheckedProperty); }
            set { SetValue(TextColorCheckedProperty, value); }
        }
        public static readonly DependencyProperty TextColorCheckedProperty =
            DependencyProperty.Register("TextColorChecked", typeof(SolidColorBrush), typeof(CustomButton));
        

        public ContentPresenter CheckedContentPresenter
        {
            get { return (ContentPresenter)GetValue(CheckedContentPresenterProperty); }
            set { SetValue(CheckedContentPresenterProperty, value); }
        }
        public static readonly DependencyProperty CheckedContentPresenterProperty =
            DependencyProperty.Register("CheckedContentPresenter", typeof(ContentPresenter), typeof(CustomButton));


        public ContentPresenter MouseOverContentPresenter
        {
            get { return (ContentPresenter)GetValue(MouseOverContentPresenterProperty); }
            set { SetValue(MouseOverContentPresenterProperty, value); }
        }
        public static readonly DependencyProperty MouseOverContentPresenterProperty =
            DependencyProperty.Register("MouseOverContentPresenter", typeof(ContentPresenter), typeof(CustomButton));

        public ContentPresenter DisabledContentPresenter
    {
            get { return (ContentPresenter)GetValue(DisabledContentPresenterProperty); }
            set { SetValue(DisabledContentPresenterProperty, value); }
        }
        public static readonly DependencyProperty DisabledContentPresenterProperty =
            DependencyProperty.Register("DisabledContentPresenter", typeof(ContentPresenter), typeof(CustomButton));

        public Grid CanvasDisabled
    {
          get { return (Grid)GetValue(CanvasDisabledProperty); }
          set { SetValue(CanvasDisabledProperty, value); }
        }
        public static readonly DependencyProperty CanvasDisabledProperty =
            DependencyProperty.Register("CanvasDisabled", typeof(Grid), typeof(CustomButton));


        public ContentPresenter KeyboardFocusedContentPresenter
        {
            get { return (ContentPresenter)GetValue(KeyboardFocusedContentPresenterProperty); }
            set { SetValue(KeyboardFocusedContentPresenterProperty, value); }
        }
        public static readonly DependencyProperty KeyboardFocusedContentPresenterProperty =
            DependencyProperty.Register("KeyboardFocusedContentPresenter", typeof(ContentPresenter), typeof(CustomButton));

        public Grid CanvasKeyboardFocused
        {
            get { return (Grid)GetValue(CanvasKeyboardFocusedProperty); }
            set { SetValue(CanvasKeyboardFocusedProperty, value); }
        }
        public static readonly DependencyProperty CanvasKeyboardFocusedProperty =
            DependencyProperty.Register("CanvasKeyboardFocused", typeof(Grid), typeof(CustomButton));


        public Grid CanvasMouseOver
        {
            get { return (Grid)GetValue(CanvasMouseOverProperty); }
            set { SetValue(CanvasMouseOverProperty, value); }
        }
        public static readonly DependencyProperty CanvasMouseOverProperty =
            DependencyProperty.Register("CanvasMouseOver", typeof(Grid), typeof(CustomButton));


        public Grid CanvasChecked
        {
            get { return (Grid)GetValue(CanvasCheckedProperty); }
            set { SetValue(CanvasCheckedProperty, value); }
        }
        public static readonly DependencyProperty CanvasCheckedProperty =
            DependencyProperty.Register("CanvasChecked", typeof(Grid), typeof(CustomButton));

        public Geometry PathDataValue
        {
            get { return (Geometry)GetValue(PathDataValueProperty); }
            set { SetValue(PathDataValueProperty, value); }
        }

        public static readonly DependencyProperty PathDataValueProperty =
            DependencyProperty.Register("PathDataValue", typeof(Geometry), typeof(CustomButton));

        public Image ImageOnChecked
        {
            get { return (Image)GetValue(ImageOnCheckedProperty); }
            set { SetValue(ImageOnCheckedProperty, value); }
        }
        public static readonly DependencyProperty ImageOnCheckedProperty =
            DependencyProperty.Register("ImageOnChecked", typeof(Image), typeof(CustomButton));

        public Image ImageOnMouseOver
        {
            get { return (Image)GetValue(ImageOnMouseOverProperty); }
            set { SetValue(ImageOnMouseOverProperty, value); }
        }
        public static readonly DependencyProperty ImageOnMouseOverProperty =
            DependencyProperty.Register("ImageOnMouseOver", typeof(Image), typeof(CustomButton));

        public Image ImageOnKeyboardFocused
        {
            get { return (Image)GetValue(ImageOnKeyboardFocusedProperty); }
            set { SetValue(ImageOnKeyboardFocusedProperty, value); }
        }
        public static readonly DependencyProperty ImageOnKeyboardFocusedProperty =
            DependencyProperty.Register("ImageOnKeyboardFocused", typeof(Image), typeof(CustomButton));


        public Thickness MarginImage
        {
            get { return (Thickness)GetValue(MarginImageProperty); }
            set { SetValue(MarginImageProperty, value); }
        }
        public static readonly DependencyProperty MarginImageProperty =
            DependencyProperty.Register("MarginImage", typeof(Thickness), typeof(CustomButton));
        
        
        public Grid CanvasContent
        {
            get { return (Grid)GetValue(CanvasContentProperty); }
            set { SetValue(CanvasContentProperty, value); }
        }
        public static readonly DependencyProperty CanvasContentProperty =
            DependencyProperty.Register("CanvasContent", typeof(Grid), typeof(CustomButton));

        public object Content
        {
            get { return (object)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }

        public static readonly DependencyProperty ContentProperty =
            DependencyProperty.Register("Content", typeof(object), typeof(CustomButton), 
                new FrameworkPropertyMetadata(new PropertyChangedCallback(OnContentChanged)));

        #endregion

        #region Events
        public event DependencyPropertyChangedEventHandler ContentChanged;
        #endregion        

        #region Constructor

        public CustomButton()
        {
            InitializeComponent();
            StaticProperties.SetCommonStyle(CustomButtonStyle.Instance, this);
        }
        #endregion

        #region OnLoading
        private void Button_Loaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Button_Loaded;
            IButtonValuesImplementation.SetButtonContent<CustomButton>(this, null, ButtonHandling.Instantiating);
            ContentChanged += CustomButton_ContentChanged;
            MouseEnter += CustomButton_MouseEnter;
            Click += CustomButton_Click;

            SetBackgroundsTransparent();

        }

        private void SetBackgroundsTransparent()
        {

            if (this.Background == Brushes.Transparent)
            {
              this.BackgroundChecked = Brushes.Transparent;
              this.BackgroundMouseOver= Brushes.Transparent;
            }

        }
        #endregion

        #region Content Changed
        private static void OnContentChanged(DependencyObject dObject, DependencyPropertyChangedEventArgs e)
        {
            var thisButton = dObject as CustomButton;

            if (e != null)
            {
                thisButton?.ContentChanged?.Invoke(thisButton,
                    new DependencyPropertyChangedEventArgs(ContentProperty, e.OldValue, e.NewValue));
            }
        }
        private void CustomButton_ContentChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var senderButton = sender as CustomButton;
            IButtonValuesImplementation.SetButtonContent<CustomButton>(senderButton, e.OldValue, ButtonHandling.Updating);
        }
        #endregion

        #region Focus Helpers
        private void CustomButton_Click(object sender, RoutedEventArgs e)
        {
            Keyboard.ClearFocus();
        }

        private void CustomButton_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Focus();
            Keyboard.ClearFocus();
        }

        #endregion
    }
}
