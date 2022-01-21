
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Threading;
using System.Xml.Serialization;

namespace CustomControls
{
    /// <summary>
    /// Interaction logic for CustomTextBox.xaml
    /// </summary>
    public partial class CustomTextBox: TextBox
    {
        #region Properties
        


        public UIElement ThisUIElement
        {
            get { return this; }
        }

        private bool IsValueEntered = false;

        public string TextOnEmptyField { get; set; }

        public Brush BackgroundOriginal { get; set; }
        public Brush BorderOriginal { get; set; }
        public Brush ForegroundOriginal { get; set; }

        private MaskType mask = MaskType.Any;
        public MaskType Mask
        {
            get
            {
                return mask;
            }
            set
            {
                mask = value;
            }
        }

    #endregion

    #region Dependency Properties

    public Brush BackgroundValueEntered
        {
            get { return (Brush)GetValue(BackgroundValueEnteredProperty); }
            set { SetValue(BackgroundValueEnteredProperty, value); }
        }
        public static readonly DependencyProperty BackgroundValueEnteredProperty =
            DependencyProperty.Register("BackgroundValueEntered", typeof(Brush), typeof(CustomTextBox),
              new PropertyMetadata(CustomTextBoxStyle.Instance.BackgroundValueEntered));

        public Brush TextColorValueEntered
        {
            get { return (Brush)GetValue(TextColorValueEnteredProperty); }
            set { SetValue(TextColorValueEnteredProperty, value); }
        }
        public static readonly DependencyProperty TextColorValueEnteredProperty =
            DependencyProperty.Register("TextColorValueEntered", typeof(Brush), typeof(CustomTextBox),
              new PropertyMetadata(CustomTextBoxStyle.Instance.TextColorValueEntered));

    public Brush BorderColorValueEntered
        {
            get { return (Brush)GetValue(BorderColorValueEnteredProperty); }
            set { SetValue(BorderColorValueEnteredProperty, value); }
        }
        public static readonly DependencyProperty BorderColorValueEnteredProperty =
            DependencyProperty.Register("BorderColorValueEntered", typeof(Brush), typeof(CustomTextBox),
              new PropertyMetadata(CustomTextBoxStyle.Instance.BorderColorValueEntered));

    public int CornerRadius
        {
            get { return (int)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(int), typeof(CustomTextBox),
              new PropertyMetadata(CustomTextBoxStyle.Instance.CornerRadius));

    public SolidColorBrush TextColorPlaceHolder
        {
            get { return (SolidColorBrush)GetValue(TextColorPlaceHolderProperty); }
            set { SetValue(TextColorPlaceHolderProperty, value); }
        }
        public static readonly DependencyProperty TextColorPlaceHolderProperty =
            DependencyProperty.Register("TextColorPlaceHolder", typeof(SolidColorBrush), typeof(CustomTextBox),
              new PropertyMetadata(CustomTextBoxStyle.Instance.TextColorPlaceHolder));

    public Brush BackgroundMouseOver
        {
            get { return (Brush)GetValue(BackgroundMouseOverProperty); }
            set { SetValue(BackgroundMouseOverProperty, value); }
        }
        public static readonly DependencyProperty BackgroundMouseOverProperty =
            DependencyProperty.Register("BackgroundMouseOver", typeof(Brush), typeof(CustomTextBox),
              new PropertyMetadata(CustomTextBoxStyle.Instance.BackgroundMouseOver));

    public SolidColorBrush BorderColorMouseOver
        {
            get { return (SolidColorBrush)GetValue(BorderColorMouseOverProperty); }
            set { SetValue(BorderColorMouseOverProperty, value); }
        }
        public static readonly DependencyProperty BorderColorMouseOverProperty =
            DependencyProperty.Register("BorderColorMouseOver", typeof(SolidColorBrush), typeof(CustomTextBox),
              new PropertyMetadata(CustomTextBoxStyle.Instance.BorderColorMouseOver));

    public SolidColorBrush TextColorMouseOver
        {
            get { return (SolidColorBrush)GetValue(TextColorMouseOverProperty); }
            set { SetValue(TextColorMouseOverProperty, value); }
        }
        public static readonly DependencyProperty TextColorMouseOverProperty =
            DependencyProperty.Register("TextColorMouseOver", typeof(SolidColorBrush), typeof(CustomTextBox),
              new PropertyMetadata(CustomTextBoxStyle.Instance.TextColorMouseOver));

    public Brush BackgroundDisabled
        {
            get { return (Brush)GetValue(BackgroundDisabledProperty); }
            set { SetValue(BackgroundDisabledProperty, value); }
        }
        public static readonly DependencyProperty BackgroundDisabledProperty =
            DependencyProperty.Register("BackgroundDisabled", typeof(Brush), typeof(CustomTextBox),
              new PropertyMetadata(CustomTextBoxStyle.Instance.BackgroundDisabled));

    public SolidColorBrush TextColorDisabled
        {
            get { return (SolidColorBrush)GetValue(TextColorDisabledProperty); }
            set { SetValue(TextColorDisabledProperty, value); }
        }
        public static readonly DependencyProperty TextColorDisabledProperty =
            DependencyProperty.Register("TextColorDisabled", typeof(SolidColorBrush), typeof(CustomTextBox),
              new PropertyMetadata(CustomTextBoxStyle.Instance.TextColorDisabled));

    public SolidColorBrush BorderColorDisabled
        {
            get { return (SolidColorBrush)GetValue(BorderColorDisabledProperty); }
            set { SetValue(BorderColorDisabledProperty, value); }
        }
        public static readonly DependencyProperty BorderColorDisabledProperty =
            DependencyProperty.Register("BorderColorDisabled", typeof(SolidColorBrush), typeof(CustomTextBox),
              new PropertyMetadata(CustomTextBoxStyle.Instance.BorderColorDisabled));

    public Brush CaretBrush
        {
            get { return (Brush)GetValue(CaretBrushProperty); }
            set { SetValue(CaretBrushProperty, value); }
        }
        public static readonly DependencyProperty CaretBrushProperty =
            DependencyProperty.Register("CaretBrush", typeof(Brush), typeof(CustomTextBox),
              new PropertyMetadata(CustomTextBoxStyle.Instance.CaretBrush));

    #endregion

    #region Constructor

    public CustomTextBox()
        {
            InitializeComponent();
            StaticProperties.SetCommonStyle(CustomTextBoxStyle.Instance, this);
        }

        #endregion

        #region ContentChanged

        private void CustomTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Text == "")
            {
                BorderBrush = BorderOriginal;
                Foreground = ForegroundOriginal;
                Background = BackgroundOriginal;
                IsValueEntered = false;
            }
            else
            {
                ChangeColorBasedOnTextInput();
            }
        }
        private void ChangeColorBasedOnTextInput()
        {
            Foreground = TextColorValueEntered;
            BorderBrush = BorderColorValueEntered;
            Background = BackgroundValueEntered;
        }

        #endregion

        #region OnLoading
        private void TextBox_Loaded(object sender, RoutedEventArgs e)
        {
            Loaded -= TextBox_Loaded;
            SetOriginalValues();
            if (this.Text != null && this.Text != "")
            {
                ChangeColorBasedOnTextInput();
            }

        }
        private void SetOriginalValues()
        {
            BorderOriginal = BorderBrush;
            ForegroundOriginal = Foreground;
            BackgroundOriginal = Background;
        }
        #endregion
    }

    #region Enum MaskType
    public enum MaskType
    {
        Any,
        Integer,
        Decimal
    }
    #endregion

}

