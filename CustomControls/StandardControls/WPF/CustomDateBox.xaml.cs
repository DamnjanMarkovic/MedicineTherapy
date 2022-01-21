
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Interaction logic for CustomDateBox.xaml
    /// </summary>
    public partial class CustomDateBox : DatePicker, IInputElement
    {
        #region Properties
        public bool IsDatePickerOpened { get; set; } = false;
        public DatePickerTextBox datePickerTextBox { get; set; }
        public CustomButton toggleButton { get; set; }

        public UIElement ThisUIElement
        {
            get { return this; }
        }
        public Brush BackgroundOriginal { get; set; }
        public Brush BorderBrushOriginal { get; set; }
        public Brush ForegroundOriginal { get; set; }
        private bool DateEntered { get; set; } = true;
        #endregion

        #region Dependency Properties
        public Geometry DataDatePickerButton
        {
            get { return (Geometry)GetValue(DataDatePickerButtonProperty); }
            set { SetValue(DataDatePickerButtonProperty, value); }
        }
        public static readonly DependencyProperty DataDatePickerButtonProperty =
            DependencyProperty.Register("DataDatePickerButton", typeof(Geometry), typeof(CustomDateBox), 
                new PropertyMetadata(SetDefaultPathValue()));
        private static object SetDefaultPathValue()
        {
            Geometry arrowRight = Geometry.Parse("M 0 0 L 6 6 L 0 12");
            return arrowRight;
        }
               
        public string TextOnEmptyField
        {
            get { return (string)GetValue(TextOnEmptyFieldProperty); }
            set { SetValue(TextOnEmptyFieldProperty, value); }
        }
        public static readonly DependencyProperty TextOnEmptyFieldProperty =
            DependencyProperty.Register("TextOnEmptyField", typeof(string), typeof(CustomDateBox));

        public Brush BackgroundValueEntered
        {
            get { return (Brush)GetValue(BackgroundValueEnteredProperty); }
            set { SetValue(BackgroundValueEnteredProperty, value); }
        }
        public static readonly DependencyProperty BackgroundValueEnteredProperty =
            DependencyProperty.Register("BackgroundValueEntered", typeof(Brush), typeof(CustomDateBox));

        public Brush TextColorValueEntered
        {
            get { return (Brush)GetValue(TextColorValueEnteredProperty); }
            set { SetValue(TextColorValueEnteredProperty, value); }
        }
        public static readonly DependencyProperty TextColorValueEnteredProperty =
            DependencyProperty.Register("TextColorValueEntered", typeof(Brush), typeof(CustomDateBox));

        public Brush BorderColorValueEntered
        {
            get { return (Brush)GetValue(BorderColorValueEnteredProperty); }
            set { SetValue(BorderColorValueEnteredProperty, value); }
        }
        public static readonly DependencyProperty BorderColorValueEnteredProperty =
            DependencyProperty.Register("BorderColorValueEntered", typeof(Brush), typeof(CustomDateBox));

        public Visibility CalendarVisibility
        {
            get { return (Visibility)GetValue(CalendarVisibilityProperty); }
            set { SetValue(CalendarVisibilityProperty, value); }
        }
        public static readonly DependencyProperty CalendarVisibilityProperty =
            DependencyProperty.Register("CalendarVisibility", typeof(Visibility), typeof(CustomDateBox));        

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(CustomDateBox));
        
        public SolidColorBrush TextColorPlaceHolder
        {
            get { return (SolidColorBrush)GetValue(TextColorPlaceHolderProperty); }
            set { SetValue(TextColorPlaceHolderProperty, value); }
        }
        public static readonly DependencyProperty TextColorPlaceHolderProperty =
            DependencyProperty.Register("TextColorPlaceHolder", typeof(SolidColorBrush), typeof(CustomDateBox));
        
        public int CornerRadius
        {
            get { return (int)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(int), typeof(CustomDateBox));
        
        public Brush BackgroundMouseOver
        {
            get { return (Brush)GetValue(BackgroundMouseOverProperty); }
            set { SetValue(BackgroundMouseOverProperty, value); }
        }
        public static readonly DependencyProperty BackgroundMouseOverProperty =
            DependencyProperty.Register("BackgroundMouseOver", typeof(Brush), typeof(CustomDateBox));
        
        public SolidColorBrush BorderColorMouseOver
        {
            get { return (SolidColorBrush)GetValue(BorderColorMouseOverProperty); }
            set { SetValue(BorderColorMouseOverProperty, value); }
        }
        public static readonly DependencyProperty BorderColorMouseOverProperty =
            DependencyProperty.Register("BorderColorMouseOver", typeof(SolidColorBrush), typeof(CustomDateBox));
        
        public SolidColorBrush TextColorMouseOver
        {
            get { return (SolidColorBrush)GetValue(TextColorMouseOverProperty); }
            set { SetValue(TextColorMouseOverProperty, value); }
        }
        public static readonly DependencyProperty TextColorMouseOverProperty =
            DependencyProperty.Register("TextColorMouseOver", typeof(SolidColorBrush), typeof(CustomDateBox));
        
        public Brush BackgroundDisabled
        {
            get { return (Brush)GetValue(BackgroundDisabledProperty); }
            set { SetValue(BackgroundDisabledProperty, value); }
        }
        public static readonly DependencyProperty BackgroundDisabledProperty =
            DependencyProperty.Register("BackgroundDisabled", typeof(Brush), typeof(CustomDateBox));
        
        public SolidColorBrush TextColorDisabled
        {
            get { return (SolidColorBrush)GetValue(TextColorDisabledProperty); }
            set { SetValue(TextColorDisabledProperty, value); }
        }
        public static readonly DependencyProperty TextColorDisabledProperty =
            DependencyProperty.Register("TextColorDisabled", typeof(SolidColorBrush), typeof(CustomDateBox));
        
        public SolidColorBrush CaretBrush
        {
            get { return (SolidColorBrush)GetValue(CaretBrushProperty); }
            set { SetValue(CaretBrushProperty, value); }
        }
        public static readonly DependencyProperty CaretBrushProperty =
            DependencyProperty.Register("CaretBrush", typeof(SolidColorBrush), typeof(SolidColorBrush));
        
        public Brush BorderColorDisabled
        {
            get { return (Brush)GetValue(BorderColorDisabledProperty); }
            set { SetValue(BorderColorDisabledProperty, value); }
        }
        public static readonly DependencyProperty BorderColorDisabledProperty =
            DependencyProperty.Register("BorderColorDisabled", typeof(Brush), typeof(CustomDateBox));

        #endregion

        #region Constructor
        public CustomDateBox()
        {
            InitializeComponent();
            StaticProperties.SetCommonStyle(CustomDateBoxStyle.Instance, this);
            this.CalendarClosed += CustomDateBox_CalendarClosed;
            this.CalendarOpened += CustomDateBox_CalendarOpened;
            SetOriginalValues();
        }

        private void SetOriginalValues()
        {
            BackgroundOriginal = Background;
            BorderBrushOriginal = BorderBrush;
            ForegroundOriginal = Foreground;
        }
        #endregion

        #region OnLoading
        private void DatePicker_Loaded(object sender, RoutedEventArgs e)
        {
            Loaded -= DatePicker_Loaded;
            datePickerTextBox = CommonGenericFuncs.FindChild<DatePickerTextBox>(this, "PART_TextBox");
            toggleButton = CommonGenericFuncs.FindChild<CustomButton>(this, "toggleButton");
            if (toggleButton != null)
            toggleButton.Background = Brushes.Transparent;
        }
        #endregion

        #region Content Changed

        #region Ensure that only one selection will occur.
        //Two Clicks are happening: Calendar and DatePicker Selection changed. 
        //Setting a flag will provide only one raising of the event.

        public bool IsHandled { get; set; } = false;
        protected override void OnSelectedDateChanged(SelectionChangedEventArgs e)
        {
            if (IsHandled)
            {
                IsHandled = false;
            }
            else
            {
                base.OnSelectedDateChanged(e);
                IsHandled = true;
            }
        }
        #endregion

        private void DateValueChanged(object sender, RoutedEventArgs e)
        {
            if (Text == "")
            {
                IfTextIsNullStyleValues();
            }
            else if (Text != null)
            {
                IfTextIsNotNullStyleValues();
            }
        }
        private void CustomDateBox_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Text == "")
            {
                IfTextIsNullStyleValues();
            }
            else if (Text != null)
            {
                IfTextIsNotNullStyleValues();
            }
        }
        private void IfTextIsNullStyleValues()
        {
            BorderBrush = BorderBrushOriginal;
            Foreground = ForegroundOriginal;
            Background = BackgroundOriginal;
        }
        private void IfTextIsNotNullStyleValues()
        {
            Foreground = TextColorValueEntered;
            BorderBrush = BorderColorValueEntered;
            Background = BackgroundValueEntered;
        }
        
        #endregion

        #region On Calendar Opened / Closed
        private void CustomDateBox_CalendarOpened(object sender, RoutedEventArgs e)
        {
            Path path = new Path() { Data = Geometry.Parse("M 0 0 L 12 0 L 6 6") };
            var grid = new Grid();
            grid.Children.Add(path);
            toggleButton.Content = grid;
        }
        private void CustomDateBox_CalendarClosed(object sender, RoutedEventArgs e)
        {
            Path path = new Path() { Data = Geometry.Parse("M 0 0 L 6 6 L 0 12") };
            var grid = new Grid();
            grid.Children.Add(path);
            toggleButton.Content = grid;
        }

        #endregion

        #region OnClearDateBox
        private void PART_ClearDateBox(object sender, RoutedEventArgs e)
        {
            this.Text = "";
            IfTextIsNullStyleValues();
            this.IsDropDownOpen = false;
            SetFocusToTheNextField();
        }
        private void SetFocusToTheNextField()
        {
            TraversalRequest traversalRequest = new TraversalRequest(FocusNavigationDirection.Next);
            if (datePickerTextBox != null)
                datePickerTextBox.MoveFocus(traversalRequest);
        }
        #endregion

        #region MoveBetweenDaysFunction
        private void MoveBetweenDays_Click(object sender, RoutedEventArgs e)
        {
            var senderButton = (CustomButton)sender;

            switch (senderButton.Name.ToString())
            {
                case "buttonYesterday":
                    this.Text = DateTime.Now.AddDays(-1).ToShortDateString();
                    this.SelectedDate = DateTime.Now.AddDays(-1);
                    break;
                case "buttonToday":
                    this.Text = DateTime.Now.ToShortDateString();
                    this.SelectedDate = DateTime.Now;
                    break;
                case "buttonTomorrow":
                    this.Text = DateTime.Now.AddDays(1).ToShortDateString();
                    this.SelectedDate = DateTime.Now.AddDays(1);
                    break;

                default:
                    break;
            }
            SetFocusToTheNextField();
            this.IsDropDownOpen = false;
        }
        #endregion

    }

}

