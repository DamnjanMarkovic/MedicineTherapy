using Avanse.ClassLibraryHelpers;
using Avanse.GUI.WPF.Controls.Helpers;
using Leadtools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Avanse.GUI.WPF.Controls.ImageViewerWPF
{
    /// <summary>
    /// Interaction logic for ImageViewerPlayer.xaml
    /// </summary>
    public partial class ImageViewerPlayer : UserControl
    { 
    private ImageViewerWPF imageViewerWPF;
    private RasterImage rasterImage;
    private double animationFPS = 300;                 //1000 je 1 FPS
    public bool playingOngoing { get; set; } = false;
    public bool isControlLoaded { get; set; } = false;
    private delegate void NoArgDelegate();
    private delegate void OneArgDelegate(int arg);
    private int numberOfPagesForPlaying = 0;
    public int startPageAnimating { get; set; }
    public int endPageAnimating { get; set; }


    public ImageViewerPlayer(ImageViewerWPF imageViewerWPF)
    {
        InitializeComponent();
        this.imageViewerWPF = imageViewerWPF;
    }



    private void UserControl_Loaded(object sender, RoutedEventArgs e)
    {
        rasterImage = (RasterImage)imageViewerWPF.imageViewer.Image;
        rasterImage.Changed += RasterImage_Changed;
        SetPageNumbersInTextBox(rasterImage);
        startPageAnimating = imageViewerWPF.startPageAnimating;
        endPageAnimating = imageViewerWPF.endPageAnimating;
        slidersControl.Width = this.ActualWidth;
        panelTextBox.Width = this.ActualWidth;
        panelButtons.Width = this.ActualWidth;
        SetTextBoxesValues(1);
        isControlLoaded = true;
        SetImagePages(rasterImage);
    }

    private void RasterImage_Changed(object sender, RasterImageChangedEventArgs e)
    {
        var rasterImageSending = (RasterImage)sender;
        SetTextBoxesValues(rasterImageSending.Page);
        slidersControl.SliderMainValue = rasterImageSending.Page;
        SetPageNumbersInTextBox(rasterImageSending);
    }

    private void SetPageNumbersInTextBox(RasterImage rasterImage)
    {
        imageViewerWPF.textBoxPageNumber.Text = $"{rasterImage.Page} / {rasterImage.PageCount}";
    }

    /// <summary>
    /// set calues on selecting the cell
    /// </summary>
    /// <param name="selectedViewerCell"></param>
    private void SetImagePages(RasterImage rasterImage)
    {
        if (IsImageSingleFrame(rasterImage))
        {
            playerMainPanel.Visibility = Visibility.Hidden;
        }
        else
        {
            playerMainPanel.Visibility = Visibility.Visible;
            SetTrackBarMinimumMaximum(rasterImage);
            SetSlidersThumbValues(rasterImage);
            SetTextBoxesValues(rasterImage.Page);
        }
    }

    private bool IsImageSingleFrame(RasterImage rasterImage)
    {
        return rasterImage.PageCount == 1 ? true : false;
    }

    /// <summary>
    /// sets the length of the track bars
    /// </summary>
    /// <param name="selectedViewerCell"></param>
    private void SetTrackBarMinimumMaximum(RasterImage rasterImage)
    {
        slidersControl.Minimum = 1;
        slidersControl.Maximum = rasterImage.PageCount;
        slidersControl.MaximumSliderValue = rasterImage.PageCount;
    }

    /// <summary>
    /// set values for the slider thums
    /// </summary>
    /// <param name="selectedViewerCell"></param>



    private void SetSlidersThumbValues(RasterImage rasterImage)
    {
        slidersControl.SliderMainValue = rasterImage.Page;
        slidersControl.SliderStartValue = startPageAnimating;
        slidersControl.SliderEndValue = endPageAnimating;
        Console.WriteLine("");
    }


    private void SetTextBoxesValues(int trackBarValue)
    {
        sliderStarts.Text = $"1 (0:00)";
        sliderText.Text = $"{trackBarValue} ({(trackBarValue) / (1000 / animationFPS)} sec.)";
        sliderEnds.Text = $"{rasterImage.PageCount} ({rasterImage.PageCount / (1000 / animationFPS) } sec.)";
    }

    private void BtnBegining_Click(object sender, RoutedEventArgs e)
    {
        StopAnimation();
        rasterImage.Page = (int)slidersControl.SliderStartValue;
        slidersControl.SliderMainValue = rasterImage.Page;
    }


    private void BtnStepBack_Click(object sender, RoutedEventArgs e)
    {
        StopAnimation();
        if ((rasterImage.Page) > 1)
        {
            rasterImage.Page--;
        }

        else
        {
            rasterImage.Page = rasterImage.PageCount - 1;
        }
        slidersControl.SliderMainValue = rasterImage.Page;
    }


    private void BtnPlayStop_Click(object sender, RoutedEventArgs e)
    {
        if (!playingOngoing)
        {
            btnPlayStop.PathDataValue = ImagesPaths.Pause_01;
            IButtonValuesImplementation.SetButtonContent<CustomButton>(btnPlayStop);
            numberOfPagesForPlaying = (int)(slidersControl.SliderEndValue - slidersControl.SliderStartValue);
            NoArgDelegate animator = new NoArgDelegate(PlayAnimation);
            animator.BeginInvoke(null, null);
        }
        else
        {
            StopAnimation();
        }
    }


    private void PlayAnimation()
    {
        playingOngoing = true;
        while (playingOngoing)
        {
            for (int i = startPageAnimating; i < endPageAnimating; i++)
            {
                if (playingOngoing)
                {
                    btnPlayStop.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                                        new OneArgDelegate(ShowImageFrame), i);
                    Thread.Sleep((int)animationFPS);
                }
                else
                {
                    break;
                }
            }
        }
    }

    private void ShowImageFrame(int frameNumber)
    {
        rasterImage.Page = frameNumber + 1;
        slidersControl.SliderMainValue = frameNumber + 1;
    }
    private void BtnStepForward_Click(object sender, RoutedEventArgs e)
    {
        StopAnimation();
        if (rasterImage.Page < rasterImage.PageCount)
        {
            rasterImage.Page++;
        }
        else
        {
            rasterImage.Page = 1;
        }

        slidersControl.SliderMainValue = rasterImage.Page;
    }

    private void BtnEnd_Click(object sender, RoutedEventArgs e)
    {
        StopAnimation();
        rasterImage.Page = (int)(slidersControl.SliderEndValue - 1);
        slidersControl.SliderMainValue = MathCalculations.GetRoundedDoubleToInt(slidersControl.SliderEndValue, 0);

    }


    private void StopAnimation()
    {
        playingOngoing = false;
        //btnPlayStop.Dispatcher.InvokeShutdown();
        //btnPlayStop.Dispatcher.BeginInvokeShutdown(DispatcherPriority.Background);
        btnPlayStop.PathDataValue = ImagesPaths.Play_03;
        IButtonValuesImplementation.SetButtonContent<CustomButton>(btnPlayStop);
    }

    private void BtnCutSelectedFrames_Click(object sender, RoutedEventArgs e)
    {
        MessageBox.Show($"pocetni frejm je broj {(int)startPageAnimating}\n\ra krajnji {(int)endPageAnimating}");
    }

    private void SlidersControl_SliderMain_Value_Changed(object sender, RoutedEventArgs e)
    {
        var senderTrackBar = (CustomSlider)sender;
        var senderTrackBarValueInt = MathCalculations.GetRoundedDoubleToInt(senderTrackBar.SliderMainValue, 0);

        rasterImage.Page = senderTrackBarValueInt;
        SetTextBoxesValues(rasterImage.Page);
    }
    private void SlidersControl_SliderStart_Value_Changed(object sender, RoutedEventArgs e)
    {
        var senderSliderControl = (CustomSlider)sender;
        var senderSliderStartValueInt = MathCalculations.GetRoundedDoubleToInt(senderSliderControl.SliderStartValue, 0);
        if (isControlLoaded && rasterImage != null)
        {
            rasterImage.Page = senderSliderStartValueInt;
            startPageAnimating = senderSliderStartValueInt;
            SetTextBoxesValues(rasterImage.Page);
        }
    }

    private void SlidersControl_SliderEnd_Value_Changed(object sender, RoutedEventArgs e)
    {

        var senderSliderControl = (CustomSlider)sender;
        var senderSliderEndValueInt = MathCalculations.GetRoundedDoubleToInt(senderSliderControl.SliderEndValue, 0);

        if (isControlLoaded && rasterImage != null)
        {
            rasterImage.Page = senderSliderEndValueInt;
            endPageAnimating = senderSliderEndValueInt;
            SetTextBoxesValues(rasterImage.Page);
        }

    }

    private void BtnCutSingleFrame_Click(object sender, RoutedEventArgs e)
    {
        MessageBox.Show($"Hvata se frejm je broj {MathCalculations.GetRoundedDoubleToInt(rasterImage.Page + 1, 0)}");
    }




    //ovako bi bilo koristeci default-ne animacije
    //private void PlayAnimation()
    //{
    //    selectedViewerCell.Animation.Flags = MedicalViewerAnimationFlags.PlayForward;
    //    selectedViewerCell.Animation.AnimateAllSubCells = false;
    //    selectedViewerCell.Animation.Interval = (int)animationFPS;
    //    selectedViewerCell.Animation.Animated = true;
    //}
    //private void StopAnimation()
    //{
    //    selectedViewerCell.Animation.Animated = false;
    //    SetTrackPage(selectedViewerCell.ActiveSubCell);
    //}


}
}




