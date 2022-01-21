
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CustomControls
{
    public enum ButtonHandling
    {
        Instantiating,
        Updating
    }

    public static class IButtonValuesImplementation
    {
        private static readonly Type TTypeCustomButton = typeof(CustomButton);
        private static readonly Type TTypeCustomCheckBox = typeof(CustomCheckBox);
        private static readonly Type TTypeCustomRadioButton = typeof(CustomRadioButton);       

        public static T SetButtonContent<T>(T button, object oldContent, ButtonHandling buttonHandling)
        {
            Type TType = typeof(T);

            var buttonArrived = button as IButton;

            if (TType == TTypeCustomButton)
            {
                var customButton = buttonArrived as CustomButton;
                return (T)Convert.ChangeType(SetValues(customButton, oldContent, buttonHandling), TTypeCustomButton);
            }
            else if (TType == TTypeCustomCheckBox)
            {
                var customButton = buttonArrived as CustomCheckBox;
                return (T)Convert.ChangeType(SetValues(customButton, oldContent, buttonHandling), TTypeCustomCheckBox);
            }
            else if (TType == TTypeCustomRadioButton)
            {
                var customButton = buttonArrived as CustomRadioButton;
                return (T)Convert.ChangeType(SetValues(customButton, oldContent, buttonHandling), TTypeCustomRadioButton);
            }

            return default(T);
        }

        private static object SetValues(IButton customButton, object oldContent, ButtonHandling buttonHandling)
        {
            if (customButton.CheckedContentPresenter == null) customButton.CheckedContentPresenter = new ContentPresenter();
            if (customButton.MouseOverContentPresenter == null) customButton.MouseOverContentPresenter = new ContentPresenter();
            if (customButton.KeyboardFocusedContentPresenter == null) customButton.KeyboardFocusedContentPresenter = new ContentPresenter();
            if (customButton.DisabledContentPresenter == null) customButton.DisabledContentPresenter = new ContentPresenter();


        switch (buttonHandling)
            {
                case ButtonHandling.Instantiating:

                    object content = customButton.Content;

                    //check if content is set as text

                    if (content != null && content is string)
                    {
                        SetTextValues(customButton, content);
                    }

                    //check if content is set as image

                    else if (content != null && content is Image)
                    {
                        BitmapSource source = (content as Image).Source as BitmapSource;
                        SetImageValues(customButton, source);
                    }
                    //if nor string nor the image/images is set, check if PathDataValue exists and set Geometric shapes

                    else if (customButton.PathDataValue != null)
                    {
                        var pathValue = customButton.PathDataValue;
                        SetPathValues(customButton, pathValue);
                    }

                    return customButton;

                case ButtonHandling.Updating:

                    if (oldContent != null && customButton.Content is string)
                    {
                        SetTextValues(customButton, customButton.Content);
                    }

                    else if (oldContent != null && customButton.Content is Image)
                    {
                        BitmapSource source = (customButton.Content as Image).Source as BitmapSource;

                        if (source != null)
                        {
                            customButton.ImageOnChecked = ImagesHandling.ColorBitmapSourceIntoMediaColor(source, customButton.TextColorChecked.Color);
                            customButton.CheckedContentPresenter.Content = customButton.ImageOnChecked;
                            customButton.ImageOnMouseOver = ImagesHandling.ColorBitmapSourceIntoMediaColor(source, customButton.TextColorMouseOver.Color);
                            customButton.MouseOverContentPresenter.Content = customButton.ImageOnMouseOver;
                            customButton.ImageOnKeyboardFocused = ImagesHandling.ColorBitmapSourceIntoMediaColor(source, customButton.TextColorMouseOver.Color);
                            customButton.KeyboardFocusedContentPresenter.Content = customButton.ImageOnKeyboardFocused;
                            customButton.ImageDisabled = ImagesHandling.ColorBitmapSourceIntoMediaColor(source, customButton.TextColorDisabled.Color);
                            customButton.DisabledContentPresenter.Content = customButton.ImageDisabled;
                        }
                    }

                    else if (oldContent != null && customButton.Content is Grid)
                    {
                        SetPathValues(customButton, oldContent);
                    }

                    return customButton;

                default:
                    return null;
            }

        }

        private static Path GetPathValues(IButton customButton, Geometry data)
        {
            Path path = new Path();
            path.Data = data;
            path.Fill = customButton.Foreground;
            path.Stretch = Stretch.Uniform;
            path.Margin = customButton.MarginImage;
            return path;
        }

        private static void SetPathValues(IButton customButton, object oldPathGrid)
        {
            customButton.CheckedContentPresenter = new ContentPresenter();
            customButton.MouseOverContentPresenter = new ContentPresenter();
            customButton.KeyboardFocusedContentPresenter = new ContentPresenter();
            customButton.DisabledContentPresenter = new ContentPresenter();

            Path pathInCustomButton = CommonGenericFuncs.GetChildOfType<Path>(customButton.Content as Grid);
            Path oldPathValue = CommonGenericFuncs.GetChildOfType<Path>(oldPathGrid as Grid);

            if (customButton.Content == null)
            {
                customButton.CanvasContent = new Grid();
                customButton.CanvasContent.Children.Add(GetPathValues(customButton, customButton.PathDataValue));
                customButton.Content = customButton.CanvasContent;
            }
            else if (pathInCustomButton != null && oldPathValue == null || oldPathValue != null && pathInCustomButton.Data != oldPathValue.Data)
            {
                customButton.CanvasContent = new Grid();
                customButton.CanvasContent.Children.Add(GetPathValues(customButton, pathInCustomButton.Data));
                customButton.Content = customButton.CanvasContent;
            }

            pathInCustomButton = CommonGenericFuncs.GetChildOfType<Path>(customButton.Content as Grid);

            Path pathchecked = new Path();
            pathchecked.Data = pathInCustomButton.Data;
            pathchecked.Fill = customButton.TextColorChecked;
            pathchecked.Stretch = Stretch.Uniform;
            pathchecked.Margin = customButton.MarginImage;
            if (customButton.CanvasChecked == null) customButton.CanvasChecked = new Grid();
            customButton.CanvasChecked.Children.Clear();
            customButton.CanvasChecked.Children.Add(pathchecked);
            if (customButton.TextColorChecked != null)
            {
                customButton.CanvasChecked.Effect = ImagesHandling.SetDropShadowEffect(customButton.TextColorChecked.Color);
                customButton.CheckedContentPresenter.Content = customButton.CanvasChecked;
            }


            Path pathMouseOver = new Path();
            pathMouseOver.Data = pathInCustomButton.Data;
            pathMouseOver.Stretch = Stretch.Uniform;
            pathMouseOver.Margin = customButton.MarginImage;
            pathMouseOver.Fill = customButton.TextColorMouseOver;
            //pathMouseOver.Fill = customButton.Foreground;
            //      pathMouseOver.Opacity = 0.4;
            if (customButton.CanvasMouseOver == null) customButton.CanvasMouseOver = new Grid();
            customButton.CanvasMouseOver.Children.Clear();
            customButton.CanvasMouseOver.Children.Add(pathMouseOver);

            Path pathKeyboardFocused = new Path();
            pathKeyboardFocused.Data = pathInCustomButton.Data;
            pathKeyboardFocused.Stretch = Stretch.Uniform;
            pathKeyboardFocused.Margin = customButton.MarginImage;
            pathKeyboardFocused.Fill = customButton.TextColorMouseOver;
            if (customButton.CanvasKeyboardFocused == null) customButton.CanvasKeyboardFocused = new Grid();
            customButton.CanvasKeyboardFocused.Children.Clear();
            customButton.CanvasKeyboardFocused.Children.Add(pathKeyboardFocused);

            if (customButton.TextColorMouseOver != null)
            {
                customButton.CanvasMouseOver.Effect = ImagesHandling.SetDropShadowEffect(customButton.TextColorMouseOver.Color);
                customButton.MouseOverContentPresenter.Content = customButton.CanvasMouseOver;
                customButton.CanvasKeyboardFocused.Effect = ImagesHandling.SetDropShadowEffect(customButton.TextColorMouseOver.Color);
                customButton.KeyboardFocusedContentPresenter.Content = customButton.CanvasKeyboardFocused;
            }
            Path pathDisabled = new Path();
            pathDisabled.Data = pathInCustomButton.Data;
            pathDisabled.Stretch = Stretch.Uniform;
            pathDisabled.Margin = customButton.MarginImage;
            pathDisabled.Fill = customButton.TextColorDisabled;
            if (customButton.CanvasDisabled == null) customButton.CanvasDisabled = new Grid();
            customButton.CanvasDisabled.Children.Clear();
            customButton.CanvasDisabled.Children.Add(pathDisabled);

            if (customButton.TextColorDisabled != null)
            {
              customButton.DisabledContentPresenter.Content = customButton.CanvasDisabled;
            }
          }

        private static void SetImageValues(IButton customButton, BitmapSource source)
        {
            if (source != null)
            {
                //if there is no image set, 
                //we will color the arrived image and use that one

                customButton.CheckedContentPresenter.Content = (customButton.ImageOnChecked != null) ?
                    customButton.ImageOnChecked :
                    ImagesHandling.ColorBitmapSourceIntoMediaColor(source, customButton.TextColorChecked.Color);

                customButton.MouseOverContentPresenter.Content = (customButton.ImageOnMouseOver != null) ?
                    customButton.ImageOnMouseOver :
                    ImagesHandling.ColorBitmapSourceIntoMediaColor(source, customButton.TextColorMouseOver.Color);

                customButton.KeyboardFocusedContentPresenter.Content = (customButton.ImageOnKeyboardFocused != null) ?
                    customButton.ImageOnKeyboardFocused :
                    ImagesHandling.ColorBitmapSourceIntoMediaColor(source, customButton.TextColorMouseOver.Color);

                customButton.DisabledContentPresenter.Content = (customButton.ImageDisabled != null) ?
                customButton.ImageDisabled :
                ImagesHandling.ColorBitmapSourceIntoMediaColor(source, customButton.TextColorDisabled.Color);
      }
           
        }

        private static void SetTextValues(IButton customButton, object content)
        {
            TextBlock textEElement = new TextBlock();
            textEElement.Background = Brushes.Transparent;

            TextBlock textEElementChecked = new TextBlock();
            textEElementChecked.Background = Brushes.Transparent;
            textEElementChecked.Text = content as string;
            textEElementChecked.Foreground = customButton.TextColorChecked;
            customButton.CheckedContentPresenter.Content = textEElementChecked;

            TextBlock textEElementDissabled = new TextBlock();
            //textEElementDissabled.Background = Brushes.Transparent;
            textEElementDissabled.Text = content as string;
            textEElementDissabled.Foreground = customButton.TextColorChecked;
            if (customButton.TextColorDisabled != null) 
              customButton.DisabledContentPresenter.Content = textEElementDissabled;

            TextBlock textEElementMouseOver = new TextBlock();
            textEElementMouseOver.Text = content as string;
            textEElementMouseOver.Foreground = customButton.TextColorMouseOver;

            TextBlock textElementKeyboardFocused = new TextBlock();
            textElementKeyboardFocused.Text = content as string;
            textElementKeyboardFocused.Foreground = customButton.TextColorMouseOver;


            if (customButton.TextColorMouseOver != null)
            {
                customButton.MouseOverContentPresenter.Effect = ImagesHandling.SetDropShadowEffect(customButton.TextColorMouseOver.Color);
                customButton.MouseOverContentPresenter.Content = textEElementMouseOver;
                customButton.KeyboardFocusedContentPresenter.Effect = ImagesHandling.SetDropShadowEffect(customButton.TextColorMouseOver.Color);
                customButton.KeyboardFocusedContentPresenter.Content = textElementKeyboardFocused;
            }
        }
    }
}
