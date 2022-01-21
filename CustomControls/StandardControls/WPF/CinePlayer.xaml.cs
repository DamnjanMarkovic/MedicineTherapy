using Avanse.GUI.Controls;
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
using Avanse.IProviders;

namespace Avanse.GUI.Controls
{

    /// <summary>
    /// Interaction logic for CinePlayer_05.xaml
    /// </summary>
    public partial class CinePlayer : UserControl
    {

        private ICineViewer _viewer;
        public ICineViewer Viewer
        {
            set
            {
                _viewer = value;
                _viewer.OnFrameCollectionChanged += viewer_OnFrameCollectionChanged;
                _viewer.OnActiveFrameChanged += viewer_OnActiveFrameChanged;
                viewer_OnFrameCollectionChanged(null, new FramesArgs(_viewer.FrameCount, _viewer.ActiveFrame, _viewer.FrameAnimatingStart,_viewer.FrameAnimatingEnd));
            }
        }

    
        private double animationFPS = 100;                 //1000 je 1 FPS
        public bool playingOngoing { get; set; } = false;
        public bool isControlLoaded { get; set; } = false;
        private delegate void NoArgDelegate();
        private delegate void OneArgDelegate(int arg);
        private int numberOfPagesForPlaying = 0;


        public CinePlayer()
        {
            InitializeComponent();            
        }


        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            slidersControl.Width = this.ActualWidth;
            panelTextBox.Width = this.ActualWidth;
            panelButtons.Width = this.ActualWidth;

            if (!isControlLoaded)
            {
                SetTextBoxesValues(1);
                isControlLoaded = true;
            }
        }


        private void viewer_OnFrameCollectionChanged(object sender, FramesArgs e)
        {
            if (playingOngoing) StopAnimation();
            if (e.Frames <= 1)
            {
                playerMainPanel.Visibility = Visibility.Hidden;
            }
            else
            {
                playerMainPanel.Visibility = Visibility.Visible;
                SetTrackBarMinimumMaximum(e.Frames);
                slidersControl.SliderMainValue = e.ActiveFrame;
                slidersControl.SliderStartValue = e.AnimatingFrameStart;
                slidersControl.SliderEndValue = e.AnimatingFrameEnd;
                slidersControl.UpdateSlider();
                SetTextBoxesValues(e.ActiveFrame);
            }
        }

        private void viewer_OnActiveFrameChanged(object sender, FramesArgs e)
        {
            SetTextBoxesValues(e.ActiveFrame);
            slidersControl.SliderMainValue = e.ActiveFrame;
        }

        /// <summary>
        /// sets the length of the track bars
        /// </summary>
        /// <param name="selectedViewerCell"></param>
        private void SetTrackBarMinimumMaximum(int frames)
        {
            slidersControl.Minimum = 1;
            slidersControl.Maximum = frames;
            slidersControl.MaximumSliderValue = frames;
        }

        /// <summary>
        /// set values for the slider thums
        /// </summary>
        /// <param name="selectedViewerCell"></param>



      

        private void SetTextBoxesValues(int trackBarValue)
        {
            if (_viewer == null) return;
            sliderStarts.Text = $"1 (0:00)";
            sliderText.Text = $"{trackBarValue} ({(trackBarValue) / (1000 / animationFPS)} sec.)";
            int frames = _viewer.FrameCount;
            sliderEnds.Text = $"{frames} ({frames / (1000 / animationFPS) } sec.)";
        }

        private void BtnBegining_Click(object sender, RoutedEventArgs e)
        {
            if (playingOngoing) StopAnimation();
            _viewer.ActiveFrame = (int)(slidersControl.SliderStartValue );
            slidersControl.SliderMainValue = (int)Math.Round(slidersControl.SliderStartValue);
        }

        private void BtnStepBack_Click(object sender, RoutedEventArgs e)
        {
            if (playingOngoing) StopAnimation();
            if ((_viewer.ActiveFrame) > 1)
            {
                _viewer.ActiveFrame--;
            }

            else
            {
                _viewer.ActiveFrame = _viewer.FrameCount ;
            }
            slidersControl.SliderMainValue = _viewer.ActiveFrame ;
        }


        private void BtnPlayStop_Click(object sender, RoutedEventArgs e)
        {
            if (!playingOngoing)
            {
                SetImageToPlayButton(ImagesPaths.Pause_01);
                numberOfPagesForPlaying = (int)(slidersControl.SliderEndValue - slidersControl.SliderStartValue);
                NoArgDelegate animator = new NoArgDelegate(PlayAnimation);
                animator.BeginInvoke(null, null);
            }
            else
            {
                StopAnimation();
            }
        }

        private void SetImageToPlayButton(Geometry imagePathArrived)
        {
            Path path = new Path() { Data =  imagePathArrived};
            var grid = new Grid();
            grid.Children.Add(path);
            btnPlayStop.Content = grid;
        }

        private void PlayAnimation()
        {
            playingOngoing = true;
            while (playingOngoing)
            {
                for (int i = _viewer.FrameAnimatingStart; i < _viewer.FrameAnimatingEnd; i++)
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
            _viewer.ActiveFrame = frameNumber;
            slidersControl.SliderMainValue = frameNumber ;
        }
        private void BtnStepForward_Click(object sender, RoutedEventArgs e)
        {
            if (playingOngoing) StopAnimation();
            if (_viewer.ActiveFrame < _viewer.FrameCount )
            {
                _viewer.ActiveFrame++;
            }
            else
            {
                _viewer.ActiveFrame = 1;
            }

            slidersControl.SliderMainValue = _viewer.ActiveFrame ;
        }

        private void BtnEnd_Click(object sender, RoutedEventArgs e)
        {
            if (playingOngoing) StopAnimation();
            _viewer.ActiveFrame = (int)(slidersControl.SliderEndValue );
            slidersControl.SliderMainValue = (int)Math.Round(slidersControl.SliderEndValue);

        }

        private void StopAnimation()
        {
            playingOngoing = false;
            SetImageToPlayButton(ImagesPaths.Play_03);
        }

        private void BtnCutSelectedFrames_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"pocetni frejm je broj {(int)_viewer.FrameAnimatingStart}, \n\ra krajnji {(int)_viewer.FrameAnimatingEnd}");
        }

        private void SlidersControl_SliderMain_Value_Changed(object sender, RoutedEventArgs e)
        {
            var senderTrackBar = (CustomSlider)sender;
            var senderTrackBarValueInt = (int)Math.Round(senderTrackBar.SliderMainValue);

            _viewer.ActiveFrame = senderTrackBarValueInt ;
            SetTextBoxesValues(_viewer.ActiveFrame);
        }
        private void SlidersControl_SliderStart_Value_Changed(object sender, RoutedEventArgs e)
        {
            var senderSliderControl = (CustomSlider)sender;
            var senderSliderStartValueInt = (int)Math.Round(senderSliderControl.SliderStartValue);
            if (isControlLoaded && _viewer != null)
            {
                _viewer.ActiveFrame = senderSliderStartValueInt ;
                _viewer.FrameAnimatingStart = senderSliderStartValueInt;
                SetTextBoxesValues(_viewer.ActiveFrame );
            }
        }

        private void SlidersControl_SliderEnd_Value_Changed(object sender, RoutedEventArgs e)
        {

            var senderSliderControl = (CustomSlider)sender;
            var senderSliderEndValueInt = (int)Math.Round(senderSliderControl.SliderEndValue);

            if (isControlLoaded && _viewer != null)
            {
                _viewer.ActiveFrame = senderSliderEndValueInt ;
                _viewer.FrameAnimatingEnd = senderSliderEndValueInt;
                SetTextBoxesValues(_viewer.ActiveFrame );
            }

        }

        private void BtnCutSingleFrame_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Hvata se frejm je broj {(int)Math.Round((double)(_viewer.ActiveFrame ))}");
        }

    }
}

