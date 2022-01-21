using Leadtools;
using Leadtools.Annotations.Automation;
using Leadtools.Annotations.Engine;
using Leadtools.Annotations.Rendering;
using Leadtools.Annotations.Wpf;
using Leadtools.Codecs;
using Leadtools.Controls;
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

namespace Avanse.GUI.WPF.Controls.ImageViewerWPF
{
    /// <summary>
    /// Interaction logic for ImageViewerWPF.xaml
    /// </summary>
    public partial class ImageViewerWPF : UserControl
    {
        private IAnnAutomationControl _automationControl;
        public Leadtools.Controls.ImageViewer imageViewer { get; set; }
        private AnnAutomationManager _automationManager;
        private AnnAutomation _activeAutomation;
        private ImageViewerPanZoomInteractiveMode _panZoomInteractiveMode;
        private AutomationInteractiveMode _automationInteractiveMode;
        private ImageViewerMagnifyGlassInteractiveMode _magnifyGlassInteractiveMode;
        private AutomationManagerHelper _managerHelper;
        private List<IAnnPackage> _loadedPackages = new List<IAnnPackage>();

        public RasterImage rasterImage { get; set; }
        public int startPageAnimating { get; set; }
        public int endPageAnimating { get; set; }


        public ImageViewerWPF()
        {

            InitializeComponent();

            imageViewer = new Leadtools.Controls.ImageViewer();

            var defaultImageFile = @"Resources\00.dcm";
            if (File.Exists(defaultImageFile))
            {
                LoadFile(defaultImageFile, false);
            }
            var automationControl = new ImageViewerAutomationControl();
            //var automationControl = new D2DImageViewerAutomationControl();        //ovako je bilo u originalu
            automationControl.ImageViewer = imageViewer;
            _automationControl = automationControl;
            //imageViewer.Width = double.NaN;
            //imageViewer.Height = double.NaN;
            imageViewer.AutoResetOptions = ImageViewerAutoResetOptions.All;
            imageViewer.ViewHorizontalAlignment = ControlAlignment.Center;
            imageViewer.ViewVerticalAlignment = ControlAlignment.Center;
            imageViewer.Background = new SolidColorBrush(Colors.Black);
            _mainPanel.Children.Add(imageViewer);
            imageViewer.Loaded += new RoutedEventHandler(_viewer_Loaded);





        }

        void _viewer_Loaded(object sender, RoutedEventArgs e)
        {
            _panZoomInteractiveMode = new ImageViewerPanZoomInteractiveMode();
            _magnifyGlassInteractiveMode = new ImageViewerMagnifyGlassInteractiveMode();
            _automationInteractiveMode = new AutomationInteractiveMode();

            ImageViewerInteractiveMode[] modes =
            {
               _automationInteractiveMode,
               _panZoomInteractiveMode,
               _magnifyGlassInteractiveMode
            };

            imageViewer.InteractiveModes.BeginUpdate();
            foreach (var mode in modes)
            {
                mode.IsEnabled = false;

                var spyglass = mode as ImageViewerSpyGlassInteractiveMode;
                if (spyglass != null)
                {
                    mode.IdleCursor = Cursors.Cross;
                    spyglass.Shape = ImageViewerSpyGlassShape.Rectangle;
                }

                mode.AutoItemMode = ImageViewerAutoItemMode.None;
                imageViewer.InteractiveModes.Add(mode);
            }

            _automationInteractiveMode.IsEnabled = true;
            _automationInteractiveMode.MouseButtons = MouseButtons.Left | MouseButtons.Right;
            imageViewer.InteractiveModes.EndUpdate();

            InitAutomation();

            //ovo ucitava sliku  
            //var defaultImageFile = @"Resources\00.dcm";
            //if (File.Exists(defaultImageFile))
            //{
            //    //LoadFile(defaultImageFile, false);
            //}

        }

        private void LoadFile(string fileName, bool loadAnnotations)
        {
            try
            {
                using (RasterCodecs codecs = new RasterCodecs())
                {
                    imageViewer.UseDpi = false;
                    RasterImage image = codecs.Load(fileName, 0, Leadtools.Codecs.CodecsLoadByteOrder.BgrOrGray, 1, 13);
                    imageViewer.Image = image;
                    if ((imageViewer.Image != null) && (imageViewer.Image.PageCount > 0))
                    {
                        endPageAnimating = imageViewer.Image.PageCount;
                        startPageAnimating = 1;
                    }
                    _automationControl.AutomationDataProvider = new RasterImageAutomationDataProvider(image);

                }

                if (_activeAutomation != null)
                {
                    _activeAutomation.Container.Size = _activeAutomation.Container.Mapper.SizeToContainerCoordinates(LeadSizeD.Create(imageViewer.Image.ImageWidth, imageViewer.Image.ImageHeight));

                    _activeAutomation.Invalidate(LeadRectD.Empty);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }

        private void InitAutomation()
        {
            _automationManager = new AnnAutomationManager();
            _automationManager.EditContentAfterDraw = true;
            _automationManager.EditTextAfterDraw = true;
            _automationManager.RestrictDesigners = true;
            _automationManager.CreateDefaultObjects();

            _automationManager.RenderingEngine = new AnnD2DRenderingEngine();

            _managerHelper = new AutomationManagerHelper(_automationManager);

            AnnAutomationObjects automationObjects = _automationManager.Objects;


            _managerHelper.CreateToolBar();
            _annToolbarTray.ToolBars.Add(_managerHelper.ToolBar);

            _automationInteractiveMode.AutomationControl = _automationControl;


            _activeAutomation = new AnnAutomation(_automationManager, _automationControl);
            _activeAutomation.Active = true;
            _activeAutomation.Container.IsVisible = true;




            _annToolbarTray.ToolBars.Clear();
            _managerHelper.CreateToolBar();
            _annToolbarTray.ToolBars.Add(_managerHelper.ToolBar);

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }
    }
}

