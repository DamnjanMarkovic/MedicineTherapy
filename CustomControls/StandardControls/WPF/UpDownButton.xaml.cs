
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
using System.Threading;
using System.Runtime.InteropServices;

namespace CustomControls
{
    /// <summary>
    /// Interaction logic for UpDownButton.xaml
    /// </summary>
    public partial class UpDownButton : Button
    {
        #region Properties
        bool CurrentPositionIsLeft = false;
        #endregion

        #region DependencyProperties

        public Brush AdditionalTextColor
        {
            get { return (Brush)GetValue(AdditionalTextColorProperty); }
            set { SetValue(AdditionalTextColorProperty, value); }
        }
        public static readonly DependencyProperty AdditionalTextColorProperty =
            DependencyProperty.Register("AdditionalTextColor", typeof(Brush), typeof(UpDownButton));


        public Thickness BorderThicknessOnButtonRightClicked
        {
            get { return (Thickness)GetValue(BorderThicknessOnButtonRightClickedProperty); }
            set { SetValue(BorderThicknessOnButtonRightClickedProperty, value); }
        }
        public static readonly DependencyProperty BorderThicknessOnButtonRightClickedProperty =
            DependencyProperty.Register("BorderThicknessOnButtonRightClicked", typeof(Thickness), typeof(UpDownButton));


        public Thickness BorderThicknessOnButtonLeftClicked
        {
            get { return (Thickness)GetValue(BorderThicknessOnButtonLeftClickedProperty); }
            set { SetValue(BorderThicknessOnButtonLeftClickedProperty, value); }
        }
        public static readonly DependencyProperty BorderThicknessOnButtonLeftClickedProperty =
            DependencyProperty.Register("BorderThicknessOnButtonLeftClicked", typeof(Thickness), typeof(UpDownButton));

        public Thickness BorderThicknessOriginal
        {
            get { return (Thickness)GetValue(BorderThicknessOriginalProperty); }
            set { SetValue(BorderThicknessOriginalProperty, value); }
        }
        public static readonly DependencyProperty BorderThicknessOriginalProperty =
            DependencyProperty.Register("BorderThicknessOriginal", typeof(Thickness), typeof(UpDownButton));

        public double ButtonWidth
        {
            get { return (double)GetValue(ButtonWidthProperty); }
            set { SetValue(ButtonWidthProperty, value); }
        }
        public static readonly DependencyProperty ButtonWidthProperty =
            DependencyProperty.Register("ButtonWidth", typeof(double), typeof(UpDownButton));

        public string Unit
        {
            get { return (string)GetValue(UnitProperty); }
            set { SetValue(UnitProperty, value); }
        }
        public static readonly DependencyProperty UnitProperty =
            DependencyProperty.Register("Unit", typeof(string), typeof(UpDownButton));

        public string AdditionalTextUp
        {
            get { return (string)GetValue(AdditionalTextUpProperty); }
            set { SetValue(AdditionalTextUpProperty, value); }
        }
        public static readonly DependencyProperty AdditionalTextUpProperty =
            DependencyProperty.Register("AdditionalTextUp", typeof(string), typeof(UpDownButton));


        public SolidColorBrush BorderColorMouseOver
        {
            get { return (SolidColorBrush)GetValue(BorderColorMouseOverProperty); }
            set { SetValue(BorderColorMouseOverProperty, value); }
        }
        public static readonly DependencyProperty BorderColorMouseOverProperty =
            DependencyProperty.Register("BorderColorMouseOver", typeof(SolidColorBrush), typeof(UpDownButton));

        
        public SolidColorBrush TextColorMouseOver
        {
            get { return (SolidColorBrush)GetValue(TextColorMouseOverProperty); }
            set { SetValue(TextColorMouseOverProperty, value); }
        }
        public static readonly DependencyProperty TextColorMouseOverProperty =
            DependencyProperty.Register("TextColorMouseOver", typeof(SolidColorBrush), typeof(UpDownButton));

        public Brush BackgroundDisabled
        {
            get { return (Brush)GetValue(BackgroundDisabledProperty); }
            set { SetValue(BackgroundDisabledProperty, value); }
        }
        public static readonly DependencyProperty BackgroundDisabledProperty =
            DependencyProperty.Register("BackgroundDisabled", typeof(Brush), typeof(UpDownButton));


        public SolidColorBrush BorderColorDisabled
        {
            get { return (SolidColorBrush)GetValue(BorderColorDisabledProperty); }
            set { SetValue(BorderColorDisabledProperty, value); }
        }
        public static readonly DependencyProperty BorderColorDisabledProperty =
            DependencyProperty.Register("BorderColorDisabled", typeof(SolidColorBrush), typeof(UpDownButton));


        public SolidColorBrush TextColorDisabled
        {
            get { return (SolidColorBrush)GetValue(TextColorDisabledProperty); }
            set { SetValue(TextColorDisabledProperty, value); }
        }
        public static readonly DependencyProperty TextColorDisabledProperty =
            DependencyProperty.Register("TextColorDisabled", typeof(SolidColorBrush), typeof(UpDownButton));

        public Brush BackgroundChecked
        {
            get { return (Brush)GetValue(BackgroundCheckedProperty); }
            set { SetValue(BackgroundCheckedProperty, value); }
        }
        public static readonly DependencyProperty BackgroundCheckedProperty =
            DependencyProperty.Register("BackgroundChecked", typeof(Brush), typeof(UpDownButton));


        public SolidColorBrush BorderColorChecked
        {
            get { return (SolidColorBrush)GetValue(BorderColorCheckedProperty); }
            set { SetValue(BorderColorCheckedProperty, value); }
        }
        public static readonly DependencyProperty BorderColorCheckedProperty =
            DependencyProperty.Register("BorderColorChecked", typeof(SolidColorBrush), typeof(UpDownButton));


        public SolidColorBrush TextColorChecked
        {
            get { return (SolidColorBrush)GetValue(TextColorCheckedProperty); }
            set { SetValue(TextColorCheckedProperty, value); }
        }
        public static readonly DependencyProperty TextColorCheckedProperty =
            DependencyProperty.Register("TextColorChecked", typeof(SolidColorBrush), typeof(UpDownButton));


        public int CornerRadius
        {
            get { return (int)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(int), typeof(UpDownButton));

        public Brush BackgroundMouseOver
        {
            get { return (Brush)GetValue(BackgroundMouseOverProperty); }
            set { SetValue(BackgroundMouseOverProperty, value); }
        }
        public static readonly DependencyProperty BackgroundMouseOverProperty =
            DependencyProperty.Register("BackgroundMouseOver", typeof(Brush), typeof(UpDownButton));


        public Brush ButtonLeftBackgroundMouseOver
        {
            get { return (Brush)GetValue(ButtonLeftBackgroundMouseOverProperty); }
            set { SetValue(ButtonLeftBackgroundMouseOverProperty, value); }
        }
        public static readonly DependencyProperty ButtonLeftBackgroundMouseOverProperty =
            DependencyProperty.Register("ButtonLeftBackgroundMouseOver", typeof(Brush), typeof(UpDownButton));

        public Brush ButtonRightBackgroundMouseOver
        {
            get { return (Brush)GetValue(ButtonRightBackgroundMouseOverProperty); }
            set { SetValue(ButtonRightBackgroundMouseOverProperty, value); }
        }
        public static readonly DependencyProperty ButtonRightBackgroundMouseOverProperty =
            DependencyProperty.Register("ButtonRightBackgroundMouseOver", typeof(Brush), typeof(UpDownButton));

        public Brush CurrentBackground
        {
            get { return (Brush)GetValue(CurrentBackgroundProperty); }
            set { SetValue(CurrentBackgroundProperty, value); }
        }

        public static readonly DependencyProperty CurrentBackgroundProperty =
            DependencyProperty.Register("CurrentBackground", typeof(Brush), typeof(UpDownButton));


        public Brush BackgroundOriginal
        {
            get { return (Brush)GetValue(BackgroundOriginalProperty); }
            set { SetValue(BackgroundOriginalProperty, value); }
        }
        public static readonly DependencyProperty BackgroundOriginalProperty =
            DependencyProperty.Register("BackgroundOriginal", typeof(Brush), typeof(UpDownButton));

        
        public Canvas ButtonLeftCanvas
        {
            get { return (Canvas)GetValue(ButtonLeftCanvasProperty); }
            set { SetValue(ButtonLeftCanvasProperty, value); }
        }
        public static readonly DependencyProperty ButtonLeftCanvasProperty =
            DependencyProperty.Register("ButtonLeftCanvas", typeof(Canvas), typeof(UpDownButton));

        
        public Canvas ButtonRightCanvas
        {
            get { return (Canvas)GetValue(ButtonRightCanvasProperty); }
            set { SetValue(ButtonRightCanvasProperty, value); }
        }
        public static readonly DependencyProperty ButtonRightCanvasProperty =
            DependencyProperty.Register("ButtonRightCanvas", typeof(Canvas), typeof(UpDownButton));


        public Canvas ButtonRightCanvasOriginal
        {
            get { return (Canvas)GetValue(ButtonRightCanvasOriginalProperty); }
            set { SetValue(ButtonRightCanvasOriginalProperty, value); }
        }
        public static readonly DependencyProperty ButtonRightCanvasOriginalProperty =
            DependencyProperty.Register("ButtonRightCanvasOriginal", typeof(Canvas), typeof(UpDownButton));


        public Canvas ButtonRightCanvasMouseOver
        {
            get { return (Canvas)GetValue(ButtonRightCanvasMouseOverProperty); }
            set { SetValue(ButtonRightCanvasMouseOverProperty, value); }
        }
        public static readonly DependencyProperty ButtonRightCanvasMouseOverProperty =
            DependencyProperty.Register("ButtonRightCanvasMouseOver", typeof(Canvas), typeof(UpDownButton));

        
        public Canvas ButtonRightCanvasMouseClick
        {
            get { return (Canvas)GetValue(ButtonRightCanvasMouseClickProperty); }
            set { SetValue(ButtonRightCanvasMouseClickProperty, value); }
        }
        public static readonly DependencyProperty ButtonRightCanvasMouseClickProperty =
            DependencyProperty.Register("ButtonRightCanvasMouseClick", typeof(Canvas), typeof(UpDownButton));
        

        public Canvas ButtonLeftCanvasOriginal
        {
            get { return (Canvas)GetValue(ButtonLeftCanvasOriginalProperty); }
            set { SetValue(ButtonLeftCanvasOriginalProperty, value); }
        }
        public static readonly DependencyProperty ButtonLeftCanvasOriginalProperty =
            DependencyProperty.Register("ButtonLeftCanvasOriginal", typeof(Canvas), typeof(UpDownButton));


        public Canvas ButtonLeftCanvasMouseOver
        {
            get { return (Canvas)GetValue(ButtonLeftCanvasMouseOverProperty); }
            set { SetValue(ButtonLeftCanvasMouseOverProperty, value); }
        }
        public static readonly DependencyProperty ButtonLeftCanvasMouseOverProperty =
            DependencyProperty.Register("ButtonLeftCanvasMouseOver", typeof(Canvas), typeof(UpDownButton));


        public Canvas ButtonLeftCanvasMouseClick
        {
            get { return (Canvas)GetValue(ButtonLeftCanvasMouseClickProperty); }
            set { SetValue(ButtonLeftCanvasMouseClickProperty, value); }
        }

        public static readonly DependencyProperty ButtonLeftCanvasMouseClickProperty =
            DependencyProperty.Register("ButtonLeftCanvasMouseClick", typeof(Canvas), typeof(UpDownButton));
        

        public Brush MarkColor
        {
            get { return (Brush)GetValue(MarkColorProperty); }
            set { SetValue(MarkColorProperty, value); }
        }
        public static readonly DependencyProperty MarkColorProperty =
            DependencyProperty.Register("MarkColor", typeof(Brush), typeof(UpDownButton));


        public Brush MarkColorChecked
        {
            get { return (Brush)GetValue(MarkColorCheckedProperty); }
            set { SetValue(MarkColorCheckedProperty, value); }
        }
        public static readonly DependencyProperty MarkColorCheckedProperty =
            DependencyProperty.Register("MarkColorChecked", typeof(Brush), typeof(UpDownButton));

        public Brush MarkColorMouseOver
        {
            get { return (Brush)GetValue(MarkColorMouseOverProperty); }
            set { SetValue(MarkColorMouseOverProperty, value); }
        }
        public static readonly DependencyProperty MarkColorMouseOverProperty =
            DependencyProperty.Register("MarkColorMouseOver", typeof(Brush), typeof(UpDownButton));


        public ContentPresenter MouseOverContentPresenter
        {
            get { return (ContentPresenter)GetValue(MouseOverContentPresenterProperty); }
            set { SetValue(MouseOverContentPresenterProperty, value); }
        }
        public static readonly DependencyProperty MouseOverContentPresenterProperty =
            DependencyProperty.Register("MouseOverContentPresenter", typeof(ContentPresenter), typeof(UpDownButton));


        public ContentPresenter OriginalContent
        {
            get { return (ContentPresenter)GetValue(OriginalContentProperty); }
            set { SetValue(OriginalContentProperty, value); }
        }
        public static readonly DependencyProperty OriginalContentProperty =
            DependencyProperty.Register("OriginalContent", typeof(ContentPresenter), typeof(UpDownButton));



        public Color MarkColorMouseOverDropShadow
        {
            get { return (Color)GetValue(MarkColorMouseOverDropShadowProperty); }
            set { SetValue(MarkColorMouseOverDropShadowProperty, value); }
        }
        public static readonly DependencyProperty MarkColorMouseOverDropShadowProperty =
            DependencyProperty.Register("MarkColorMouseOverDropShadow", typeof(Color), typeof(UpDownButton));


        #endregion

        #region Constructor
        public UpDownButton()
        {
            InitializeComponent();
            StaticProperties.SetCommonStyle(UpDownButtonStyle.Instance, this);
            BorderThicknessOriginal = BorderThickness;
        }
        #endregion

        #region OnLoading
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Grid_Loaded;
            SetButtonCanvases();
            if (MarkColorMouseOver != null) SetContentValues();
        }
        #endregion

        #region Additional Functions
        private void SetButtonCanvases()
        {
            this.ButtonLeftCanvas = SetCanvasOnButton("ButtonLeftCanvas",
                ImagesPaths.TriangleDown.GetOutlinedPathGeometry(), MarkColor, false);
            this.ButtonLeftCanvasOriginal = this.ButtonLeftCanvas;
            this.ButtonLeftCanvasMouseClick = SetCanvasOnButton("ButtonLeftCanvasMouseClick",
                ImagesPaths.TriangleDown.GetOutlinedPathGeometry(), MarkColorChecked, true);
            this.ButtonLeftCanvasMouseOver = SetCanvasOnButton("ButtonLeftCanvasMouseOver",
                ImagesPaths.TriangleDown.GetOutlinedPathGeometry(), MarkColorMouseOver, true);

            this.ButtonRightCanvas = SetCanvasOnButton("ButtonRightCanvas",
                 ImagesPaths.TriangleUp.GetOutlinedPathGeometry(), MarkColor, false);
            this.ButtonRightCanvasOriginal = this.ButtonRightCanvas;
            this.ButtonRightCanvasMouseClick = SetCanvasOnButton("ButtonRightCanvasMouseClick",
                ImagesPaths.TriangleUp.GetOutlinedPathGeometry(), MarkColorChecked, true);
            this.ButtonRightCanvasMouseOver = SetCanvasOnButton("ButtonRightCanvasMouseOver",
                ImagesPaths.TriangleUp.GetOutlinedPathGeometry(), MarkColorMouseOver, true);

        }

        private Canvas SetCanvasOnButton(string Name, Geometry PathData, Brush Fill, bool withEffect)
        {
            Canvas canvas = new Canvas();
            Path path = new Path();
            canvas.Name = Name;
            path.Data = PathData;
            path.Name = Name;
            path.Fill = Fill;
            if (Name.Contains("MouseClick") && Fill != null)
            {
                path = AddStrokeToPath(path, Fill);
                path = AddEffectToPath(path, Fill);
            }
            if (Name.Contains("MouseOver") && Fill != null)
            {
                path = AddEffectToPath(path, Fill);
            }
            canvas.Children.Add(path);
            return canvas;
        }
        private Path AddStrokeToPath(Path path, Brush Fill)
        {
            path.Stroke = Fill;
            path.StrokeThickness = 4;
            return path;
        }
        private Path AddEffectToPath(Path path, Brush Fill)
        {
            path.Effect = ImagesHandling.SetDropShadowEffect(((SolidColorBrush)Fill).Color);
            return path;
        }

        private void SetContentValues() {
            MarkColorMouseOverDropShadow = (((SolidColorBrush)MarkColorMouseOver).Color);
            object content = this.Content;

            OriginalContent = new ContentPresenter(); 
            MouseOverContentPresenter = new ContentPresenter();

            if (content != null)
            {
                OriginalContent.Content = this.Content;
                var textEElement = new TextBlock();
                textEElement.Background = Brushes.Transparent;
                textEElement.HorizontalAlignment = HorizontalAlignment.Center;
                textEElement.VerticalAlignment = VerticalAlignment.Center;
                textEElement.Text = content as string;
                textEElement.Foreground = new SolidColorBrush(((SolidColorBrush)MarkColorMouseOver).Color);                
                MouseOverContentPresenter.Effect = ImagesHandling.SetDropShadowEffect(((SolidColorBrush)MarkColorMouseOver).Color);
                MouseOverContentPresenter.Content = textEElement;
            }
        }
        private void SetOriginalPathValues()
        {
            ButtonLeftCanvas = ButtonLeftCanvasOriginal;
            ButtonRightCanvas = ButtonRightCanvasOriginal;
        }
        private void SetOriginalValues()
        {
            BackgroundOriginal = Background;
            CurrentBackground = BackgroundOriginal;
        }
        #endregion

        #region Location determination
        private bool IsOverMainText(Point pos)
        {
            var mainLabel = CommonGenericFuncs.FindChild<ContentPresenter>(this, "labelMain");

            if (mainLabel.IsMouseOver)
            {
                return false;
            }
            return true;
        }
        private bool IsCurrentPositionLeft(Point pos)
        {
            if (pos.X < grid.Width / 2)
            {
                CurrentPositionIsLeft = true;
            }
            else
            {
                CurrentPositionIsLeft = false;
            }
            return CurrentPositionIsLeft;
        }
        #endregion

        #region Mouse Actions
        private void Button_MouseClicked(object sender, MouseButtonEventArgs e)
        {
            var pos = MouseUtilities.GetMousePosition(grid);
            if (IsCurrentPositionLeft(pos))
            {
                ButtonLeftCanvas = ButtonLeftCanvasMouseClick;
                CurrentBackground = ButtonLeftBackgroundMouseOver;
                Background = ButtonLeftBackgroundMouseOver;
                ButtonLeftClicked();
            }
            else
            {
                ButtonRightCanvas = ButtonRightCanvasMouseClick;
                CurrentBackground = ButtonRightBackgroundMouseOver;
                Background = ButtonRightBackgroundMouseOver;
                ButtonRightClicked();
            }
        }
        private void Button_MouseReleased(object sender, MouseButtonEventArgs e)
        {
            SetOriginalPathValues();
        }
        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            SetOriginalPathValues();
        }
        private void Button_MouseMove(object sender, MouseEventArgs e)
        {
            SetOriginalPathValues();
            var pos = MouseUtilities.GetMousePosition(grid);

            if (IsCurrentPositionLeft(pos))
            {
                ButtonLeftCanvas = ButtonLeftCanvasMouseOver;
            }
            else
            {
                ButtonRightCanvas = ButtonRightCanvasMouseOver;
            }
        }
        #endregion

        #region RoutedEvent creating, on right/left button clicked

        private void ButtonLeftClicked()
        {
            RoutedEventArgs args = new RoutedEventArgs(ButtonLeftClickedEvent);
            RaiseEvent(args);
            BorderThickness = BorderThicknessOnButtonLeftClicked;
        }
        public static readonly RoutedEvent ButtonLeftClickedEvent = EventManager.RegisterRoutedEvent("ButtonLeftClicked",
            RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(UpDownButton));

        public event RoutedEventHandler OnButtonLeftClicked
        {
            add { AddHandler(ButtonLeftClickedEvent, value); }
            remove { RemoveHandler(ButtonLeftClickedEvent, value); }
        }

        private void ButtonRightClicked()
        {
            RoutedEventArgs args = new RoutedEventArgs(ButtonRightClickedEvent);
            RaiseEvent(args);
            BorderThickness = BorderThicknessOnButtonRightClicked;
        }
        public static readonly RoutedEvent ButtonRightClickedEvent = EventManager.RegisterRoutedEvent("ButtonRightClicked",
            RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(UpDownButton));

        public event RoutedEventHandler OnButtonRightClicked
        {
            add { AddHandler(ButtonRightClickedEvent, value); }
            remove { RemoveHandler(ButtonRightClickedEvent, value); }
        }
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
        }
        #endregion

    

    #region MouseUtilities
    /// <summary>
    /// Internal class returning mouse cursor location.
    /// </summary>
    internal class MouseUtilities
    {
        [StructLayout(LayoutKind.Sequential)]
        private struct Win32Point
        {
            public Int32 X;
            public Int32 Y;
        };

        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(ref Win32Point pt);

        [DllImport("user32.dll")]
        private static extern bool ScreenToClient(IntPtr hwnd, ref Win32Point pt);

        public static Point GetMousePosition(Visual relativeTo)
        {
            Win32Point mouse = new Win32Point();
            GetCursorPos(ref mouse);
            return relativeTo.PointFromScreen(new Point((double)mouse.X, (double)mouse.Y));
        }
    }
        #endregion

    }
}
