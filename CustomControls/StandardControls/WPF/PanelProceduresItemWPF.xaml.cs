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
using System.Drawing;
using System.Drawing.Drawing2D;
using Avanse.Core5.Base;
using Color = System.Drawing.Color;
using Pen = System.Drawing.Pen;
using Rectangle = System.Drawing.Rectangle;
using Brush = System.Drawing.Brush;
using Avanse.GUI.Controls;

namespace Avanse.GUI.WPF.Controls.StandardControls.WPF_02
{
    /// <summary>
    /// Interaction logic for PanelProceduresItemWPF.xaml
    /// </summary>
    public partial class PanelProceduresItemWPF : StackPanel
    {
        public PanelProceduresItemWPF()
        {
            InitializeComponent();
        }
    }
}


//        internal delegate void EventCheckedChangedDelegate(PanelProceduresItemWPF item);
//        internal EventCheckedChangedDelegate EventCheckedChanged;

//        internal delegate void EventCollapseChangedDelegate(PanelProceduresItemWPF item);
//        internal EventCollapseChangedDelegate EventCollapseChanged;

//        internal delegate List<Bitmap> EventGetGroupImagesDelegate(TUniqueId groupID);
//        internal EventGetGroupImagesDelegate EventGetGroupImages;

//        internal delegate bool EventCanDecheckOnClickDelegate();
//        internal EventCanDecheckOnClickDelegate EventCanDecheckOnClick;

//        internal delegate bool EventGetMarkDelegate(PanelProceduresItemWPF item);
//        internal EventGetMarkDelegate EventGetMark;

//        internal bool Collapsed = false;
//        internal int SortingIndex = 1;
//        internal bool GroupRepresent = false;


//        holds specific procedure data
//    internal PanelProcedureItemData Data;
//        internal PanelProceduresProperties Props;
//        internal PanelProceduresMode Mode = PanelProceduresMode.WorkList;

//     checked
//    private bool _checked = false;

//        internal PanelProceduresItemWPF(PanelProceduresMode parentMode, PanelProceduresProperties parentProperties,
//            PanelProcedureItemData data)
//        {
//            InitializeComponent();
//            this.Mode = parentMode;
//            this.Props = new PanelProceduresProperties(parentProperties);
//            this.MouseDown += PanelProcedureItem_MouseDown;
//            if (this.Mode == PanelProceduresMode.WorkList) this.MouseDoubleClick += PanelProcedureItem_MouseDoubleClick;
//            this.Data = data;
//            this.Data.FlagsChanged += FlagsChaged;

//        }



//        internal bool Checked
//        {
//            get
//            {
//                switch (Mode)
//                {
//                    case PanelProceduresMode.WorkList:
//                        return TGlobal.WorkList[this.Data.ID.StudyID][this.Data.ID.SeriesID][this.Data.ID.ImageID].Active;
//                    default:
//                        return _checked;
//                }

//            }
//            set
//            {
//                switch (Mode)
//                {
//                    case PanelProceduresMode.WorkList:
//                        TGlobalDispatch.SetActiveImage(this.Data.ID.StudyID, this.Data.ID.SeriesID, this.Data.ID.ImageID, value);
//                        break;
//                    default:
//                        if (_checked != value)
//                        {
//                            _checked = value;
//                            if (value)
//                            {
//                                this.UpdateLayout();
//                            }
//                            EventCheckedChanged?.Invoke(this);
//                            if (!value && this.Props.SlowDeCheck)//todo umesto mode
//                            {
//                                AsyncRefresh();
//                                return;
//                            }
//                            if (!value) this.UpdateLayout();
//                        }
//                        break;
//                }

//            }
//        }

//        private async void AsyncRefresh()
//        {
//            Task delay = Task.Delay(100);
//            await delay;
//            this.UpdateLayout();
//        }
//        visual properties taken from parent list

//    private void FlagsChaged()
//        {
//            this.UpdateLayout();
//        }

//        private void PanelProcedureItem_MouseDown(object sender, MouseEventArgs e)
//        {

//            switch (e.Button)
//            {
//                case MouseButtons.Left:
//                    if (EventGetMark?.Invoke(this) == true) return;

//                    switch (this.Mode)
//                    {
//                        case PanelProceduresMode.WorkList:
//                            TGlobalDispatch.SetActiveImage(this.Data.ID.StudyID, this.Data.ID.SeriesID, this.Data.ID.ImageID, true);
//                            break;
//                        case PanelProceduresMode.APRSelection:

//                            checks the item; do not allow decheck on click
//                            if (!Checked) Checked = true;
//                            else if (EventCanDecheckOnClick?.Invoke() == true) Checked = false;
//                            break;
//                    }

//                    break;


//            }

//        }

//        private void PanelProcedureItem_MouseDoubleClick(object sender, MouseEventArgs e)
//        {

//            switch (e.Button)
//            {
//                case MouseButtons.Left:
//                    if (string.IsNullOrEmpty(this.Data.GroupID)) return; // if group is not set, collapsing is N/A
//                    Collapsed = !Collapsed;
//                    EventCollapseChanged?.Invoke(this);
//                    break;

//            }
//        }


//        protected override void OnPaint(PaintEventArgs e)
//        {
//            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
//            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
//            e.Graphics.Clear(this.BackColor);

//            int offset = 0;
//            if (this.Data.APRSelection == EAPRSelectionType.Procedure)
//            {
//                offset = Props.FrameRectangle.Height / 8; int indent = (int)Math.Floor((float)offset / 2);

//            }
//            int wmp = Props.FrameRectangle.Width - offset;
//            int hmp = Props.FrameRectangle.Height - offset;

//            System.Drawing.Rectangle imageRectangle = new System.Drawing.Rectangle(Props.FrameRectangle.X + Props.FrameWidth, Props.FrameRectangle.Y + Props.FrameWidth, wmp - 2 * Props.FrameWidth, hmp - 2 * Props.FrameWidth);
//            bool hilighted = false;

//            #region Image
//            switch (Props.DisplayStyle)
//            {
//                case PanelProceduresDisplayStyle.TextOnly:
//                    break;

//                case PanelProceduresDisplayStyle.ThumbnailAndText:


//                    black thumb background
//                    System.Drawing.Brush brushBlack = new SolidBrush(System.Drawing.Color.FromArgb(Props.ThumbAlpha, System.Drawing.Color.Black));
//                    e.Graphics.FillRectangle(brushBlack, imageRectangle);
//                    brushBlack.Dispose();
//                    thumb image
//                     collapsed group representer
//                    if ((this.Collapsed && this.GroupRepresent) || (this.ThumbImages != null && this.ThumbImages.Count > 1))
//                    {
//                        List<Bitmap> bitmaps = null;
//                        if (this.Collapsed && this.GroupRepresent)
//                            bitmaps = EventGetGroupImages?.Invoke(this.Data.ID.StudyID);
//                        else
//                            bitmaps = this.ThumbImages;

//                        if (bitmaps != null)
//                        {
//                            for (int i = 0; i < bitmaps.Count && i < 4; i++)
//                            {
//                                if (bitmaps[i] == null) continue;
//                                System.Drawing.Rectangle r = new System.Drawing.Rectangle(imageRectangle.X + (i % 2) * imageRectangle.Width / 2, imageRectangle.Y + (i / 2) * imageRectangle.Height / 2, imageRectangle.Width / 2, imageRectangle.Height / 2);
//                                e.Graphics.DrawImage(bitmaps[i], r);
//                            }


//                        }

//                    }
//                    else if (this.ThumbImages != null && this.ThumbImages.Count == 1 && this.ThumbImages[0] != null)
//                    {
//                        e.Graphics.DrawImage(this.ThumbImages[0], imageRectangle);
//                    }

//                    break;
//            }
//            #endregion


//            hilight
//            if (this.Collapsed && this.GroupRepresent && !Props.ColorHilightOnCollapse.Equals(Color.Transparent))
//            {
//                System.Drawing.Brush brushHilight = new SolidBrush(Props.ColorHilightOnCollapse);
//                Brush brushHilight = new SolidBrush(Color.FromArgb(60, 0, 0, 255 - this.BackColor.B));
//                e.Graphics.FillRectangle(brushHilight, imageRectangle);
//                brushHilight.Dispose();
//                hilighted = true;

//            }

//            if (this.Data.APRSelection == EAPRSelectionType.Procedure && !Props.ColorHilightAPRProcedure.Equals(Color.Transparent))
//            {
//                System.Drawing.Brush brushHilight = new SolidBrush(Props.ColorHilightAPRProcedure);
//                Brush brushHilight = new SolidBrush(Color.FromArgb(60, 0, 0, 255 - this.BackColor.B));
//                e.Graphics.FillRectangle(brushHilight, imageRectangle);
//                brushHilight.Dispose();
//                hilighted = true;
//            }

//            if (!hilighted && !Props.ColorHilight.Equals(Color.Transparent))
//            {
//                System.Drawing.Brush brushHilight = new SolidBrush(Props.ColorHilight);
//                e.Graphics.FillRectangle(brushHilight, imageRectangle);
//                brushHilight.Dispose();
//            }

//            frame
//            #region Frame
//            if (_checked) // nije mi lose ovako bez okvira - samo selected uokvirujem
//                Pen penFrame = new Pen(Checked ? Props.FrameColorSelected : Props.FrameColor, Props.FrameWidth);
//            penFrame.Alignment = PenAlignment.Inset;
//            if (this.Data.APRSelection == EAPRSelectionType.Procedure)
//            {
//                int indent = (int)Math.Floor((float)offset / 2);

//                e.Graphics.DrawRectangle(penFrame, new Rectangle(Props.FrameRectangle.X, Props.FrameRectangle.Y, wmp, hmp));
//                e.Graphics.DrawLine(penFrame, indent, hmp + indent, wmp + indent, hmp + indent);
//                e.Graphics.DrawLine(penFrame, wmp + indent, indent, wmp + indent, hmp + indent);
//                e.Graphics.DrawLine(penFrame, 2 * indent, hmp + 2 * indent, wmp + 2 * indent, hmp + 2 * indent);
//                e.Graphics.DrawLine(penFrame, wmp + 2 * indent, 2 * indent, wmp + 2 * indent, hmp + 2 * indent);
//            }
//            else
//            {
//                e.Graphics.DrawRectangle(penFrame, new Rectangle(Props.FrameRectangle.X, Props.FrameRectangle.Y, Props.FrameRectangle.Width - 1, Props.FrameRectangle.Height - 1));
//            }
//            penFrame.Dispose();


//            multi frame

//        if (!this.Collapsed && this.MultiFrame > 1)
//            {
//                int _miniSquare = 6;
//                int _offsetFromFrame = 2;
//                Region borderRgn = new Region(Props.FrameRectangle);
//                Rectangle holeRect = new Rectangle(Props.FrameRectangle.X + Props.FrameWidth + _offsetFromFrame, Props.FrameRectangle.Y + Props.FrameWidth + _offsetFromFrame - 2 * _miniSquare, _miniSquare, _miniSquare);
//                Rectangle holeRect1 = new Rectangle(Props.FrameRectangle.X + Props.FrameWidth + _offsetFromFrame + 1, Props.FrameRectangle.Y + Props.FrameWidth + _offsetFromFrame - 2 * _miniSquare + 1, _miniSquare - 2, _miniSquare - 2);

//                while (holeRect.Y + 2 * _miniSquare < Props.FrameRectangle.Bottom - Props.FrameWidth - _offsetFromFrame)
//                {
//                    holeRect1.Y += 2 * _miniSquare;
//                    borderRgn.Xor(holeRect1);
//                    holeRect.Y += 2 * _miniSquare;
//                    borderRgn.Xor(holeRect);
//                }
//                borderRgn.Xor(Props.FrameRectangle);
//                Brush brshScopyBorder = new SolidBrush(Checked ? Props.MultiFrameSquareMarksColorSelected : Props.MultiFrameSquareMarksColor);
//                e.Graphics.FillRegion(brshScopyBorder, borderRgn);

//                int a = 20;
//                PointF center = new PointF(Props.FrameRectangle.X + Props.FrameRectangle.Width / 2, Props.FrameRectangle.Y + Props.FrameRectangle.Height / 2);

//                PointF[] pointsTriangle = new PointF[] {new PointF(center.X - a * (float) Math.Sqrt(3)/4,center.Y - a/2),
//                                                            new PointF(center.X - a * (float) Math.Sqrt(3)/4,center.Y + a/2),
//                                                            new PointF(center.X + a * (float) Math.Sqrt(3)/4,center.Y)};

//                Brush brshWhite = new SolidBrush(Color.White);
//                Pen penBlack = new Pen(Color.Black, 2);
//                e.Graphics.FillRectangle(brshBlack, center.X - a * (float)Math.Sqrt(3) / 4 - 5, center.Y - a / 2 - 4, a + 10, a + 10);
//                e.Graphics.FillPolygon(brshWhite, pointsTriangle);

//                e.Graphics.DrawPolygon(penBlack, pointsTriangle);
//                e.Graphics.DrawLine(penFrame, Props.FrameRectangle.X + Props.FrameWidth + 2 * _offsetFromFrame + _miniSquare + (float)Props.FrameWidth / 2, Props.FrameRectangle.Y + Props.FrameWidth,
//                    Props.FrameRectangle.X + Props.FrameWidth + 2 * _offsetFromFrame + _miniSquare + (float)Props.FrameWidth / 2, Props.FrameRectangle.Y - Props.FrameWidth + Props.FrameRectangle.Height);

//                borderRgn.Translate(Props.FrameRectangle.Width - 2 * Props.FrameWidth - 2 * _offsetFromFrame - _miniSquare, 0);
//                e.Graphics.FillRegion(brshScopyBorder, borderRgn);
//                brshScopyBorder.Dispose();
//                brshWhite.Dispose();
//                penBlack.Dispose();

//            }

//            #endregion

//            ONLY FOR TESTING REMOVE LATER
//#if false
//                StringFormat snformatt = new StringFormat(StringFormat.GenericTypographic);
//                snformatt.Alignment = StringAlignment.Center;
//                snformatt.LineAlignment = StringAlignment.Center;
//                Brush brushTest = new SolidBrush(Color.Red);
//                e.Graphics.DrawString(Data.ID.StudyID.ToString(), Props.MarkLongAnatomyTextFont, brushTest, Props.FrameRectangle, snformatt);
//                snformatt.Dispose();
//                brushTest.Dispose();
//#endif

//           display flags: only if not collapsed
//            #region Flags 
//            if (!this.Collapsed)
//            {
//                if (this.Data.Flags.HasFlag(PanelProcedureItemFlags.StoredInPACS))
//                {
//                    e.Graphics.DrawImage(Properties.Resources.Stored, imageRectangle.X, imageRectangle.Y, Props.MarkWidth, Props.MarkWidth);
//                }
//                else if (this.Data.Flags.HasFlag(PanelProcedureItemFlags.StoringInPACS))
//                {
//                    e.Graphics.DrawImage(Properties.Resources.Storing, imageRectangle.X, imageRectangle.Y, Props.MarkWidth, Props.MarkWidth);
//                }

//                if (this.Data.Flags.HasFlag(PanelProcedureItemFlags.Marked))
//                {
//                    e.Graphics.DrawImage(Properties.Resources.Selected, imageRectangle.X, imageRectangle.Bottom - Props.MarkWidth, Props.MarkWidth, Props.MarkWidth);
//                }

//                if (this.Data.Flags.HasFlag(PanelProcedureItemFlags.Demo))
//                {
//                    Brush brushDemoText = new SolidBrush(Props.MarkDemoTextColor);
//                    StringFormat snformat = new StringFormat(StringFormat.GenericTypographic);
//                    snformat.Alignment = Props.DisplayStyle == PanelProceduresDisplayStyle.ThumbnailAndText ? StringAlignment.Near : StringAlignment.Far;
//                    Rectangle demoRect = new Rectangle(imageRectangle.X, imageRectangle.Y + imageRectangle.Height / 2, imageRectangle.Width, imageRectangle.Height / 2); ;
//                    if (!this.Data.Flags.HasFlag(PanelProcedureItemFlags.Marked))
//                    {
//                        snformat.LineAlignment = StringAlignment.Far;
//                    }
//                    else
//                    {
//                        snformat.LineAlignment = StringAlignment.Near;
//                    }
//                    e.Graphics.DrawString(Props.MarkDemoText, Props.MarkDemoTextFont, brushDemoText, demoRect, snformat);
//                    brushDemoText.Dispose();
//                    snformat.Dispose();
//                }

//                if (this.Data.Flags.HasFlag(PanelProcedureItemFlags.HasSortingIndex))
//                {
//                    Brush brushNumeratedRect = new SolidBrush(Props.MarkNumeratingRectangleColor);
//                    Brush brushNumeratedText = new SolidBrush(Props.MarkNumeratingTextColor);
//                    StringFormat snformat = new StringFormat(StringFormat.GenericTypographic);
//                    snformat.Alignment = StringAlignment.Center;
//                    snformat.LineAlignment = StringAlignment.Center;
//                    Rectangle numeratedRect = new Rectangle(imageRectangle.Right - Props.MarkWidth, imageRectangle.Bottom - Props.MarkWidth, Props.MarkWidth, Props.MarkWidth);
//                    e.Graphics.FillRectangle(brushNumeratedRect, numeratedRect);
//                    e.Graphics.DrawString(SortingIndex.ToString() + ".", Props.MarkNumeratingTextFont, brushNumeratedText, numeratedRect, snformat);
//                    brushNumeratedRect.Dispose();
//                    brushNumeratedText.Dispose();
//                    snformat.Dispose();
//                }

//                if (this.Data.Flags.HasFlag(PanelProcedureItemFlags.LongAnatomySingle))
//                {
//                    Brush brushLARect = new SolidBrush(Props.MarkLongAnatomyRectangleColor);
//                    Brush brushLAText = new SolidBrush(Props.MarkLongAnatomyTextColor);
//                    StringFormat snformat = new StringFormat(StringFormat.GenericTypographic);
//                    snformat.Alignment = StringAlignment.Center;
//                    snformat.LineAlignment = StringAlignment.Center;
//                    Rectangle LARect = new Rectangle(imageRectangle.Right - Props.MarkWidth, imageRectangle.Y, Props.MarkWidth, Props.MarkWidth);
//                    e.Graphics.FillRectangle(brushLARect, LARect);
//                    e.Graphics.DrawString(Data.FlagedLongAnatomySingleNumber.ToString() + ".", Props.MarkLongAnatomyTextFont, brushLAText, LARect, snformat);
//                    brushLARect.Dispose();
//                    brushLAText.Dispose();
//                    snformat.Dispose();
//                }
//                else if (this.Data.Flags.HasFlag(PanelProcedureItemFlags.LongAnatomyStiched))
//                {
//                    Rectangle LARect = new Rectangle(imageRectangle.Right - Props.MarkWidth, imageRectangle.Y, Props.MarkWidth, Props.MarkWidth);
//                    Brush brushLARect = new SolidBrush(Props.MarkLongAnatomyRectangleColor);
//                    e.Graphics.FillRectangle(brushLARect, LARect);
//                    e.Graphics.DrawImage(Properties.Resources.Stitched, LARect);
//                    brushLARect.Dispose();
//                }
//            }
//            #endregion

//            text
//            #region Text  
//        StringFormat sformat = new StringFormat(StringFormat.GenericTypographic);
//            sformat.Alignment = Props.DisplayStyle == PanelProceduresDisplayStyle.ThumbnailAndText ? StringAlignment.Center : StringAlignment.Near;
//            sformat.LineAlignment = Props.DisplayStyle == PanelProceduresDisplayStyle.ThumbnailAndText ? StringAlignment.Near : StringAlignment.Center;
//            sformat.Trimming = StringTrimming.Word;
//            sformat.FormatFlags = StringFormatFlags.LineLimit;
//            Brush brushText = new SolidBrush(Props.ForeColor);
//            e.Graphics.DrawString(this.Collapsed ? (string.IsNullOrEmpty(Data.ID.StudyID) ? Data.ID.StudyID.ToString() : this.GroupDescription) : this.ItemDescription, this.Font, brushText, Props.TextRectangle, sformat);
//            brushText.Dispose();
//            sformat.Dispose();
//            #endregion

//            base.OnPaint(e);
//        }

//        internal List<Bitmap> ThumbImages
//        {
//            get
//            {
//                switch (Mode)
//                {
//                    case PanelProceduresMode.WorkList:
//                        return new List<Bitmap>() { TGlobal.WorkList[Data.ID.StudyID][Data.ID.SeriesID][Data.ID.ImageID].ThumbImage };
//                    case PanelProceduresMode.APRSelection:
//                        return this.Data.APRThumbImages;

//                    default:
//                        return null;

//                }
//            }

//        }

//        internal string ItemDescription
//        {
//            get
//            {
//                switch (Mode)
//                {
//                    case PanelProceduresMode.WorkList:
//                        return TGlobal.WorkList[Data.ID.StudyID][Data.ID.SeriesID][Data.ID.ImageID].Description;
//                    case PanelProceduresMode.APRSelection:
//                        return this.Data.APRDescription;

//                    default:
//                        return "";

//                }
//            }

//        }

//        internal DateTime? AcqDateTime
//        {
//            get
//            {
//                switch (Mode)
//                {
//                    case PanelProceduresMode.WorkList:
//                        return TGlobal.WorkList[Data.ID.StudyID][Data.ID.SeriesID][Data.ID.ImageID].StartAcquisition;

//                    default:
//                        return null;

//                }
//            }

//        }

//        internal int MultiFrame
//        {
//            get
//            {
//                switch (Mode)
//                {
//                    case PanelProceduresMode.WorkList:
//                        WorkListImage image = TGlobal.WorkList[Data.ID.StudyID][Data.ID.SeriesID][Data.ID.ImageID];
//                        if (image.AppMode == EAPRAppMode.FL) return 2;
//                        return image.Count();

//                    case PanelProceduresMode.APRSelection:
//                        return this.Data.APRAppMode == EAPRAppMode.FL ? 2 : 1;

//                    default:
//                        return 1;


//                }
//            }

//        }

//        internal string GroupDescription
//        {
//            get
//            {
//                switch (Mode)
//                {
//                    case PanelProceduresMode.WorkList:
//                        return TGlobal.WorkList[Data.ID.StudyID].StudyDescription;

//                    default:
//                        return "";

//                }
//            }

//        }

//        internal string AccessionNumber
//        {
//            get
//            {
//                switch (Mode)
//                {
//                    case PanelProceduresMode.WorkList:
//                        return TGlobal.WorkList[Data.ID.StudyID].AccessionNumber;

//                    default:
//                        return "";

//                }
//            }

//        }


//    }

//    internal class CompareItems : IComparer<PanelProceduresItemWPF>
//    {
//        private SortType sortType = SortType.Manual;

//        public CompareItems(SortType type)
//        {
//            this.sortType = type;
//        }
//        private int? ExtractSortingIndex(PanelProceduresItemWPF item)
//        {
//            if (item.Data.Flags.HasFlag(PanelProcedureItemFlags.HasSortingIndex))
//                return item.SortingIndex;

//            return null;
//        }


//        int IComparer<PanelProceduresItemWPF>.Compare(PanelProceduresItemWPF x, PanelProceduresItemWPF y)
//        {
//            switch (sortType)
//            {
//                case SortType.Manual:
//                    int? xValue = ExtractSortingIndex(x);
//                    int? yValue = ExtractSortingIndex(y);
//                    if (xValue == null && yValue == null) return 0;
//                    if (xValue == null && yValue != null) return 1;
//                    if (xValue != null && yValue == null) return -1;
//                    if (xValue < yValue) return -1;
//                    if (xValue > yValue) return 1;
//                    break;


//                case SortType.ByName:

//                    return string.Compare(x.ItemDescription, y.ItemDescription);

//                case SortType.ByGroup:

//                    if (x.Data.ID.StudyID < y.Data.ID.StudyID) return -1;
//                    if (x.Data.ID.StudyID > y.Data.ID.StudyID) return 1;
//                    if (x.Data.ID.SeriesID < y.Data.ID.SeriesID) return -1;
//                    if (x.Data.ID.SeriesID > y.Data.ID.SeriesID) return 1;
//                    return 0;

//                case SortType.ByAcqTime:
//                    DateTime? xacqdt = x.AcqDateTime;
//                    DateTime? yacqdt = y.AcqDateTime;
//                    if (xacqdt == null && yacqdt == null) return 0;
//                    if (xacqdt == null) return -1;
//                    if (yacqdt == null) return 1;
//                    return DateTime.Compare((DateTime)xacqdt, (DateTime)yacqdt);

//                case SortType.ByAccNumber:
//                    return string.Compare(x.AccessionNumber, y.AccessionNumber);
//            }


//            return 0;
//        }


//    }
//}
