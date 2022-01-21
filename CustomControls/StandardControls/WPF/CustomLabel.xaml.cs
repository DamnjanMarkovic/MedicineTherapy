
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
    /// Interaction logic for CustomLabel.xaml
    /// </summary>
    public partial class CustomLabel : Label
    {
        #region Dependency Properties

        public Brush BackgroundValueEntered
        {
            get { return (Brush)GetValue(BackgroundValueEnteredProperty); }
            set { SetValue(BackgroundValueEnteredProperty, value); }
        }
        public static readonly DependencyProperty BackgroundValueEnteredProperty =
            DependencyProperty.Register("BackgroundValueEntered", typeof(Brush), typeof(CustomLabel));


        public int CornerRadius
        {
            get { return (int)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(int), typeof(CustomLabel), new PropertyMetadata(null));

        public Brush BackgroundMouseOver
        {
            get { return (Brush)GetValue(BackgroundMouseOverProperty); }
            set { SetValue(BackgroundMouseOverProperty, value); }
        }
        public static readonly DependencyProperty BackgroundMouseOverProperty =
            DependencyProperty.Register("BackgroundMouseOver", typeof(Brush), typeof(CustomLabel), new PropertyMetadata(null));

        public SolidColorBrush BorderColorMouseOver
        {
            get { return (SolidColorBrush)GetValue(BorderColorMouseOverProperty); }
            set { SetValue(BorderColorMouseOverProperty, value); }
        }
        public static readonly DependencyProperty BorderColorMouseOverProperty =
            DependencyProperty.Register("BorderColorMouseOver", typeof(SolidColorBrush), typeof(CustomLabel), new PropertyMetadata(null));

        public SolidColorBrush TextColorMouseOver
        {
            get { return (SolidColorBrush)GetValue(TextColorMouseOverProperty); }
            set { SetValue(TextColorMouseOverProperty, value); }
        }
        public static readonly DependencyProperty TextColorMouseOverProperty =
            DependencyProperty.Register("TextColorMouseOver", typeof(SolidColorBrush), typeof(CustomLabel), new PropertyMetadata(null));

        public Brush BackgroundDisabled
        {
            get { return (Brush)GetValue(BackgroundDisabledProperty); }
            set { SetValue(BackgroundDisabledProperty, value); }
        }
        public static readonly DependencyProperty BackgroundDisabledProperty =
            DependencyProperty.Register("BackgroundDisabled", typeof(Brush), typeof(CustomLabel));

        public SolidColorBrush BorderColorDisabled
        {
            get { return (SolidColorBrush)GetValue(BorderColorDisabledProperty); }
            set { SetValue(BorderColorDisabledProperty, value); }
        }
        public static readonly DependencyProperty BorderColorDisabledProperty =
            DependencyProperty.Register("BorderColorDisabled", typeof(SolidColorBrush), typeof(CustomLabel));

        public SolidColorBrush TextColorDisabled
        {
            get { return (SolidColorBrush)GetValue(TextColorDisabledProperty); }
            set { SetValue(TextColorDisabledProperty, value); }
        }
        public static readonly DependencyProperty TextColorDisabledProperty =
            DependencyProperty.Register("TextColorDisabled", typeof(SolidColorBrush), typeof(CustomLabel));
        #endregion

        #region Constructor
        public CustomLabel()
        {
            InitializeComponent();
            StaticProperties.SetCommonStyle(CustomLabelStyle.Instance, this);
        }
        #endregion

     }
}
