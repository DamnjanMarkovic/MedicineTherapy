using Avanse.Core5.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
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
using Point = System.Drawing.Point;
using Size = System.Drawing.Size;

namespace Avanse.GUI.WPF.Controls.StandardControls.WPF_02
{
    /// <summary>
    /// Interaction logic for PanelProceduresScrollableWPF.xaml
    /// </summary>
    public partial class PanelProceduresScrollableWPF : StackPanel
    {
        public PanelProceduresScrollableWPF()
        {
            InitializeComponent();
        }
    }
}


//        public PanelProceduresScrollableWPF(IContainer container)
//        {
//            container.Add(this);
//            InitializeComponent();
//            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
//              ControlStyles.OptimizedDoubleBuffer |
//              ControlStyles.UserPaint, true);

//            TGlobalDispatch.OnInfoGlobalInit += TGlobalDispatch_OnInfoGlobalInit;
//        }

//        public PanelProceduresScrollableWPF()
//        {
//            InitializeComponent();
//            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
//              ControlStyles.OptimizedDoubleBuffer |
//              ControlStyles.UserPaint, true);

//            TGlobalDispatch.OnInfoGlobalInit += TGlobalDispatch_OnInfoGlobalInit;
//        }



//        [Category("Avanse")]
//        public PanelProceduresMode MainMode { get; set; } = PanelProceduresMode.WorkList;

//        [Category("Avanse"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
//        public PanelProceduresProperties Properties { get; set; } = new PanelProceduresProperties();
//        [Category("Avanse")]
//        public Size ItemSize { get; set; } = new Size(100, 130);

//        [Category("Avanse")]
//        public int MinWidth { get; set; } = 0;
//        [Category("Avanse")]
//        public int MaxWidth { get; set; } = 500;


//        [Category("Avanse")]
//        public ContextMenuOptions ContextMenuOptions
//        {
//            get
//            {
//                return contextMenuOptions;
//            }

//            set
//            {
//                contextMenuOptions = value;
//                InitializeContextMenu();
//            }
//        }

//        //void UI.IUIStyle.InitStyle(Avanse.UI.UIStyle uistyle)
//        //{
//        //    this.BackColor = uistyle.GetBackColor(BackColor);
//        //    this.Properties.ForeColor = uistyle.GetForeColor(ForeColor);
//        //    //this.Properties.BackgroundColor = this.BackColor;
//        //}

//        private void TGlobalDispatch_OnInfoGlobalInit(bool succeeded)
//        {
//            switch (MainMode)
//            {
//                case PanelProceduresMode.WorkList:
//                    TGlobal.WorkList.OnFrameAdded += Worklist_OnFrameAdded;
//                    TGlobal.WorkList.OnFrameRemoved += Worklist_OnFrameRemoved;
//                    TGlobal.WorkList.OnImageAdded += Worklist_OnImageAdded;
//                    TGlobal.WorkList.OnImageRemoved += Worklist_OnImageRemoved;
//                    TGlobal.WorkList.OnSeriesAdded += Worklist_OnSeriesAdded;
//                    TGlobal.WorkList.OnSeriesRemoved += Worklist_OnSeriesRemoved;
//                    TGlobal.WorkList.OnStudyAdded += Worklist_OnStudyAdded;
//                    TGlobal.WorkList.OnStudyRemoved += Worklist_OnStudyRemoved;
//                    TGlobal.WorkList.OnImageChanged += WorkList_OnImageChanged;
//                    TGlobal.WorkList.OnImageActiveChanged += WorkList_OnImageChanged;
//                    TGlobal.WorkList.OnStudyChanged += WorkList_OnStudyChanged;
//                    break;

//                case PanelProceduresMode.APRSelection:
//                    TGlobalDispatch.OnSetAPRSelection += TGlobal_OnSetAPRSelection;
//                    // TGlobal.APRManager.OnAPREntryClearAll += APRManager_OnAPREntryClearAll;
//                    break;

//            }

//        }

//        public int ItemsCount
//        {
//            get => this.Controls.Count;

//        }

//        public delegate void EventItemCheckedChangedDelegate(PanelProcedureItemID ID, bool checkedStatus);
//        public EventItemCheckedChangedDelegate EventItemCheckedChanged;

//        public delegate void EventNeedScrollDelegate(bool need);
//        public EventNeedScrollDelegate EventNeedScroll;

//        public delegate void EventPrintDelegate(List<PanelProcedureItemID> IDs);
//        public EventPrintDelegate EventPrint;

//        public delegate void EventSetDoseDelegate(List<PanelProcedureItemID> IDs);
//        public EventSetDoseDelegate EventSetDose;

//        public delegate bool EventCopyPasteDelegate(PanelProcedureItemID IDcopied, PanelProcedureItemID IDpasted);
//        public EventCopyPasteDelegate EventCopyPaste;

//        public delegate void EventItemsCountChangedDelegate(int num);
//        public EventItemsCountChangedDelegate EventItemsCountChanged;

//        #region privates
//        private List<PanelProcedureItemID> itemsIDs = new List<PanelProcedureItemID>();
//        private List<PanelProcedureItemID> itemsIDsOriginal = new List<PanelProcedureItemID>();
//        private Point firstItemLocation = new Point(0, 0);
//        private ContextMenuOptions contextMenuOptions = ContextMenuOptions.None;

//        private PanelProcedureItemID? contextMenuItemIDClicked = null;
//        private PanelProcedureItemID? contextMenuItemIDCopy = null;

//        private bool inManualSorting = false;
//        private int manualCurrentSortingIndex = 1;
//        private bool inMarkingItems = false;
//        #endregion

//        #region ### WorkList Event handlers ###

//        private void Worklist_OnStudyRemoved(WorkListStudy study)
//        {
//            Debug.Print("Worklist_OnWorkListStudyRemoved    : " + study.UniqueStudyId + " : " + ((IUniqueId)study).GetUniqUeIdPath());
//        }
//        private void Worklist_OnStudyAdded(WorkListStudy study)
//        {
//            Debug.Print("Worklist_OnWorkListStudyAdded      : " + study.UniqueStudyId + " : " + ((IUniqueId)study).GetUniqUeIdPath());
//        }
//        private void Worklist_OnSeriesRemoved(WorkListSeries series)
//        {
//            Debug.Print("Worklist_OnWorkListSeriesRemoved   : " + series.UniqueSeriesId + " : " + ((IUniqueId)series).GetUniqUeIdPath());
//        }
//        private void Worklist_OnSeriesAdded(WorkListSeries series)
//        {
//            Debug.Print("Worklist_OnWorkListSeriesRemoved   : " + series.UniqueSeriesId + " : " + ((IUniqueId)series).GetUniqUeIdPath());
//        }
//        private void Worklist_OnImageRemoved(WorkListImage image)
//        {
//            Debug.Print("Worklist_OnWorkListImageRemoved    : " + image.UniqueImageId + " : " + ((IUniqueId)image).GetUniqUeIdPath());
//            if (image != null && image.Study != null && image.Series != null)
//                this.ItemRemove(image.Study.UniqueStudyId, image.Series.UniqueSeriesId, image.UniqueImageId);
//        }
//        private void Worklist_OnImageAdded(WorkListImage image)
//        {
//            Debug.Print("Worklist_OnWorkListImageAdded      : " + image.UniqueImageId + " : " + ((IUniqueId)image).GetUniqUeIdPath());
//            this.ItemAdd(new PanelProcedureItemData(new PanelProcedureItemID(image.Study.UniqueStudyId, image.Series.UniqueSeriesId, image.UniqueImageId), PanelProcedureItemFlags.None), AddNewItemPosition.AsLast);
//        }

//        private void WorkList_OnImageChanged(WorkListImage image)
//        {
//            if (image.Study == null || image.Series == null) return;
//            PanelProcedureItemID id = new PanelProcedureItemID(image.Study.UniqueId, image.Series.UniqueId, image.UniqueId);
//            foreach (Control pitem in this.Controls)
//            {
//                if (pitem is PanelProceduresItemWPF)
//                {
//                    if (((PanelProceduresItemWPF)pitem).Data.ID == id && (!((PanelProceduresItemWPF)pitem).Collapsed || ((PanelProceduresItemWPF)pitem).GroupRepresent))
//                    {
//                        pitem.Refresh();
//                        return;
//                    }
//                }
//            }
//        }

//        //private void WorkList_OnImageActiveChange(WorkListImage image)
//        //{
//        //    this.Refresh();
//        //}

//        private void WorkList_OnStudyChanged(WorkListStudy study)
//        {
//            foreach (Control pitem in this.Controls)
//            {
//                if (pitem is PanelProceduresItemWPF)
//                {
//                    if (((PanelProceduresItemWPF)pitem).Data.ID.StudyID == study.UniqueId && (!((PanelProceduresItemWPF)pitem).Collapsed || ((PanelProceduresItemWPF)pitem).GroupRepresent))
//                    {
//                        pitem.Refresh();

//                    }
//                }
//            }
//        }

//        private void Worklist_OnFrameRemoved(WorkListFrame item)
//        {
//            Debug.Print("Worklist_OnWorkListFrameRemoved    : " + item.UniqueFrameId + " : " + ((IUniqueId)item).GetUniqUeIdPath());
//        }
//        private void Worklist_OnFrameAdded(WorkListFrame item)
//        {
//            Debug.Print("Worklist_OnWorkListFrameAdded      : " + item.UniqueFrameId + " : " + ((IUniqueId)item).GetUniqUeIdPath());
//        }

//        #endregion

//        #region APR Selection Event handlers
//        private void TGlobal_OnSetAPRSelection(List<TAPRSelectionData> aprs)
//        {
//            this.ItemsRemoveAll();
//            foreach (TAPRSelectionData apr in aprs)
//            {
//                PanelProcedureItemData aprdata = new PanelProcedureItemData(new PanelProcedureItemID(new TUniqueId(1), new TUniqueId(1), apr.ID), PanelProcedureItemFlags.None);
//                aprdata.APRThumbImages = apr.ThumbImages;
//                aprdata.APRDescription = apr.Description;
//                aprdata.APRSelection = apr.SelectionType;
//                aprdata.APRAppMode = apr.AppMode;
//                aprdata.APRSide = apr.Side;
//                aprdata.APRId = apr.APRId;
//                this.ItemAdd(aprdata, AddNewItemPosition.AsLast);
//            }
//        }
//        #endregion

//        #region ### Manipulation with control items ###
//        /// <summary>
//        ///  Add new item to the list
//        /// </summary>
//        /// <param name="data">new item data</param>
//        /// <param name="position">where to place item</param>
//        /// <returns>item ID</returns>
//        public PanelProcedureItemID ItemAdd(PanelProcedureItemData data, AddNewItemPosition position)
//        {
//            //if (data.ID == -1) data.ID = GetUniqueID();

//            PanelProceduresItemWPF item = new PanelProceduresItemWPF(this.MainMode, this.Properties, data);
//            item.EventCheckedChanged += Item_EventCheckedChanged;
//            item.EventCollapseChanged += Item_EventCollapseChanged;
//            item.EventGetGroupImages += Item_EventGetGroupImages;
//            item.EventCanDecheckOnClick += Item_EventCanDecheckOnClick;
//            item.EventGetMark += Item_getMark;
//            item.ContextMenuStrip = this.ContextMenuStrip;

//            foreach (Control pitem in this.Controls)
//            {
//                if (pitem is PanelProceduresItemWPF && ((PanelProceduresItemWPF)pitem).Data.ID.StudyID == data.ID.StudyID)
//                {
//                    item.Collapsed = ((PanelProceduresItemWPF)pitem).Collapsed;
//                    break;
//                }
//            }


//            SetControlsParameters pars = new SetControlsParameters
//            {
//                procedureItem = item
//            };

//            if (position == AddNewItemPosition.AfterFirstChecked && MainMode != PanelProceduresMode.WorkList) position = AddNewItemPosition.AsLast;
//            switch (position)
//            {
//                case AddNewItemPosition.AsLast:
//                    SetControls(SetControlsType.AddItem, pars);
//                    break;

//                case AddNewItemPosition.AfterFirstChecked:
//                    PanelProceduresItemWPF itemAfter = this.PanelProcedureItemChecked;
//                    if (itemAfter != null && itemAfter.Collapsed) // if group is collapsed, add item after last in the group 
//                    {
//                        for (int i = itemsIDs.Count - 1; i >= 0; i--)
//                        {
//                            PanelProceduresItemWPF itemByID = this[itemsIDs[i]];
//                            if (itemByID.Data.ID.StudyID == itemAfter.Data.ID.StudyID)
//                            {
//                                itemAfter = itemByID;
//                                break;
//                            }

//                        }

//                    }

//                    pars.toSetAfterItem = itemAfter;
//                    SetControls(SetControlsType.AddItem, pars);
//                    break;
//            }

//            return item.Data.ID;

//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="studyID"></param>
//        /// <param name="seriesID"></param>
//        /// <param name="imageID"></param>
//        public void ItemRemove(TUniqueId studyID, TUniqueId seriesID, TUniqueId imageID)
//        {
//            if (this.MainMode != PanelProceduresMode.WorkList) return;
//            PanelProceduresItemWPF item = this[studyID, seriesID, imageID];
//            if (item == null || item.Collapsed) return; // do not allow removing collapsed item

//            //check other item ovo treba da radi WL
//            //if (item.Checked && this.ItemsCheckMode == PanelProceduresCheckMode.Single && this.LeaveOneCheckedInSingleCheckMode)
//            //{
//            //    int place = GetItemIndex(item.Data.ID);
//            //    if (place != -1)
//            //    {
//            //        if (place < itemsIDs.Count - 1) // if possible check item bellow
//            //            CheckGroupRepresent(this[itemsIDs[place + 1]]);
//            //        else if (place > 0) // if not, check above
//            //            CheckGroupRepresent(this[itemsIDs[place - 1]]);
//            //    }
//            //}

//            SetControlsParameters pars = new SetControlsParameters
//            {
//                procedureItem = item
//            };
//            SetControls(SetControlsType.RemoveItem, pars);
//        }

//        /// <summary>
//        /// Remove all
//        /// </summary>
//        public void ItemsRemoveAll()
//        {
//            itemsIDs.Clear();
//            itemsIDsOriginal.Clear();
//            this.Controls.Clear();
//            EventItemsCountChanged?.Invoke(this.Controls.Count);
//            firstItemLocation = new Point(0, 0);
//            DeallocateSpace(null);
//            EventNeedScroll?.Invoke(false);

//            LeaveManualSorting();



//        }

//        /// <summary>
//        /// set flag on item
//        /// </summary>
//        /// <param name="itemID">item ID</param>
//        /// <param name="flag">flag to set or remove</param>
//        /// <param name="set">true to set, false to remove</param>
//        public void SetFlagOnItemByID(PanelProcedureItemID itemID, PanelProcedureItemFlags flag, bool set)
//        {
//            PanelProceduresItemWPF item = this[itemID];
//            if (item != null)
//            {
//                if (set)
//                    item.Data.Flags |= flag;
//                else
//                    item.Data.Flags &= ~flag;
//            }
//        }

//        /// <summary>
//        /// set flag on checked items
//        /// </summary>
//        /// <param name="flag">flag to set or remove</param>
//        /// <param name="set">true to set, false to remove</param>
//        public void SetFlagOnItemsChecked(PanelProcedureItemFlags flag, bool set)
//        {
//            List<PanelProceduresItemWPF> items = this.PanelProcedureItemsChecked;
//            foreach (PanelProceduresItemWPF item in items)
//            {
//                if (set)
//                    item.Data.Flags |= flag;
//                else
//                    item.Data.Flags &= ~flag;
//            }
//        }

//        #endregion


//        /// <summary>
//        /// get checked item data in multi check mode
//        /// </summary>
//        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
//        public List<PanelProcedureItemID> ItemsChecked
//        {
//            get
//            {
//                List<PanelProceduresItemWPF> items = this.PanelProcedureItemsChecked;
//                List<PanelProcedureItemID> ids = new List<PanelProcedureItemID>();
//                if (items != null)
//                {
//                    foreach (PanelProceduresItemWPF pitem in items)
//                    {
//                        ids.Add(pitem.Data.ID);
//                    }
//                }

//                return ids;

//            }
//        }

//        /// <summary>
//        /// get marked item data
//        /// </summary>
//        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
//        public List<PanelProcedureItemID> ItemsMarked
//        {
//            get
//            {
//                List<PanelProcedureItemID> ids = new List<PanelProcedureItemID>();
//                foreach (Control c in this.Controls)
//                {
//                    if (c is PanelProceduresItemWPF && ((PanelProceduresItemWPF)c).Data.Flags.HasFlag(PanelProcedureItemFlags.Marked))
//                        ids.Add(((PanelProceduresItemWPF)c).Data.ID);
//                }


//                return ids;

//            }
//        }

//        /// <summary>
//        /// Scroll list up and down
//        /// </summary>
//        /// <param name="direction"></param>
//        //s public new void Scroll(ScrollDirection direction)
//        //{
//        //    bool visible = true;

//        //    SetControlsParameters pars = new SetControlsParameters();
//        //    if (direction == ScrollDirection.Down)
//        //    {
//        //        pars.itemsToRearrange = this.ItemsSorted(null);
//        //        for (int i = pars.itemsToRearrange.Count - 1; i >= 0; i--)
//        //        {
//        //            if (!pars.itemsToRearrange[i].Collapsed || pars.itemsToRearrange[i].GroupRepresent)
//        //            {
//        //                if (pars.itemsToRearrange[i].Visible) return; // last item is visible - do not allow scroll
//        //                break;
//        //            }
//        //        }
//        //    }
//        //    else // if (direction == ScrollDirection.Up)
//        //    {
//        //        if (firstItemLocation.Equals(new Point(0, 0))) return;
//        //        pars.itemsToRearrange = this.ItemsSorted(null);
//        //    }


//        //    switch (ScrollType)
//        //    {
//        //        case ScrollType.OneItem:
//        //            if (direction == ScrollDirection.Down)
//        //            {
//        //                firstItemLocation = LocationPrevious(firstItemLocation, out visible);
//        //            }
//        //            else // if (direction == ScrollDirection.Up)
//        //            {
//        //                firstItemLocation = LocationNext(firstItemLocation, out visible, false);
//        //            }
//        //            break;
//        //        case ScrollType.OneColumn:
//        //            if (direction == ScrollDirection.Down)
//        //            {
//        //                firstItemLocation = LocationPreviousColumn(firstItemLocation, out visible);
//        //            }
//        //            else // if (direction == ScrollDirection.Up)
//        //            {
//        //                firstItemLocation = LocationNextColumn(firstItemLocation, out visible);
//        //            }
//        //            break;
//        //    }



//        //    pars.firstLocation = firstItemLocation;
//        //    pars.firstLocationVisible = visible; // LocationVisible(firstItemLocation)


//        //    SetControls(SetControlsType.RearrangeSortedItems, pars);
//        //}

//        /// <summary>
//        /// has marked items
//        /// </summary>
//        private bool HasMarkedItems()
//        {
//            foreach (Control pitem in this.Controls)
//            {
//                if (pitem is PanelProceduresItemWPF && ((PanelProceduresItemWPF)pitem).Data.Flags.HasFlag(PanelProcedureItemFlags.Marked))
//                    return true;
//            }
//            return false;

//        }

//        /// <summary>
//        /// get items checked
//        /// </summary>
//        private List<PanelProceduresItemWPF> PanelProcedureItemsChecked
//        {
//            get
//            {
//                List<PanelProceduresItemWPF> items = new List<PanelProceduresItemWPF>();
//                foreach (Control pitem in this.Controls)
//                {
//                    if (pitem is PanelProceduresItemWPF && ((PanelProceduresItemWPF)pitem).Checked) items.Add((PanelProceduresItemWPF)pitem);
//                }
//                return items;
//            }
//        }

//        /// <summary>
//        /// get first item checked
//        /// </summary>
//        private PanelProceduresItemWPF PanelProcedureItemChecked
//        {
//            get
//            {
//                foreach (Control pitem in this.Controls)
//                {
//                    if (pitem is PanelProceduresItemWPF && ((PanelProceduresItemWPF)pitem).Checked) return (PanelProceduresItemWPF)pitem;

//                }
//                return null;

//            }
//        }

//        /// <summary>
//        /// auto-generated IDs
//        /// </summary>
//        /// <returns></returns>
//        //private int GetUniqueID()
//        //{
//        //    TUniqueId max = -1;
//        //    foreach (Control pitem in this.Controls)
//        //    {
//        //        if (pitem is PanelProcedureItem && ((PanelProcedureItem)pitem).Data.ID > max) max = ((PanelProcedureItem)pitem).Data.ID;
//        //    }
//        //    max += 1;

//        //    return max;
//        //}

//        /// <summary>
//        /// item in the list
//        /// </summary>
//        /// <param name="ID"></param>
//        /// <returns></returns>
//        private PanelProceduresItemWPF this[PanelProcedureItemID ID]
//        {
//            get
//            {
//                foreach (Control pitem in this.Controls)
//                {
//                    if (pitem is PanelProceduresItemWPF && ((PanelProceduresItemWPF)pitem).Data.ID == ID) return (PanelProceduresItemWPF)pitem;
//                }

//                return null;
//            }
//        }

//        private PanelProceduresItemWPF this[TUniqueId StudyID, TUniqueId SeriesID, TUniqueId ImageID]
//        {
//            get
//            {
//                foreach (Control pitem in this.Controls)
//                {
//                    if (pitem is PanelProceduresItemWPF && ((PanelProceduresItemWPF)pitem).Data.ID.StudyID == StudyID && ((PanelProceduresItemWPF)pitem).Data.ID.SeriesID == SeriesID && ((PanelProcedureItemWPF)pitem).Data.ID.ImageID == ImageID) return (PanelProcedureItemWPF)pitem;
//                }

//                return null;
//            }
//        }

//        private List<PanelProceduresItemWPF> this[TUniqueId StudyID]
//        {
//            get
//            {
//                List<PanelProceduresItemWPF> items = new List<PanelProceduresItemWPF>();
//                foreach (Control pitem in this.Controls)
//                {
//                    if (pitem is PanelProceduresItemWPF && ((PanelProceduresItemWPF)pitem).Data.ID.StudyID == StudyID) items.Add((PanelProceduresItemWPF)pitem);
//                }

//                return items;
//            }
//        }

//        /// <summary>
//        /// group of items
//        /// </summary>
//        /// <param name="groupID"></param>
//        /// <returns></returns>
//        private List<PanelProceduresItemWPF> GetItemsForGroup(TUniqueId groupID)
//        {

//            List<PanelProceduresItemWPF> items = new List<PanelProceduresItemWPF>();
//            foreach (Control pitem in this.Controls)
//            {
//                if (pitem is PanelProceduresItemWPF && ((PanelProceduresItemWPF)pitem).Data.ID.StudyID == groupID) items.Add((PanelProceduresItemWPF)pitem);
//            }

//            return items;
//        }

//        /// <summary>
//        /// get index of the item
//        /// </summary>
//        /// <param name="ID"></param>
//        /// <returns></returns>
//        private int GetItemIndex(PanelProcedureItemID ID)
//        {
//            for (int i = 0; i < itemsIDs.Count; i++)
//                if (itemsIDs[i] == ID) return i;

//            return -1;
//        }

//        /// <summary>
//        /// get items sorted by displayed index 
//        /// </summary>
//        /// <param name="fromID">get items with index > item with ID = from ID</param>
//        /// <returns></returns>
//        private List<PanelProceduresItemWPF> ItemsSorted(PanelProcedureItemID? fromID)
//        {
//            int fromIndex = -1; //all
//            if (fromID != null) fromIndex = GetItemIndex((PanelProcedureItemID)fromID);
//            List<PanelProceduresItemWPF> items = new List<PanelProceduresItemWPF>();
//            for (int i = fromIndex + 1; i < itemsIDs.Count; i++)
//            {
//                items.Add(this[itemsIDs[i]]);

//            }

//            return items;
//        }

//        /// <summary>
//        /// get group repres. item when group is collapsed
//        /// </summary>
//        /// <param name="groupID"></param>
//        /// <returns></returns>
//        private PanelProceduresItemWPF GetGroupRepresent(TUniqueId groupID)
//        {
//            List<PanelProceduresItemWPF> group = GetItemsForGroup(groupID);
//            foreach (PanelProceduresItemWPF pitem in group)
//            {
//                if (pitem.GroupRepresent) return pitem;

//            }
//            return null;
//        }

//        /// <summary>
//        /// check group represent
//        /// </summary>
//        /// <param name="item"></param>
//        //private void CheckGroupRepresent(PanelProcedureItem item)
//        //{
//        //    if (!item.Collapsed || item.GroupRepresent)
//        //    {
//        //        item.Checked = true;
//        //        return;
//        //    }
//        //    PanelProcedureItem pitem = GetGroupRepresent(item.Data.ID.StudyID);
//        //    if (pitem != null) pitem.Checked = true;
//        //}

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="type"></param>
//        private void SortItems(SortType sort)
//        {

//            switch (sort)
//            {
//                case SortType.Default:
//                    itemsIDs.Clear();
//                    foreach (PanelProcedureItemID id in itemsIDsOriginal)
//                    {
//                        itemsIDs.Add(id);
//                    }
//                    break;
//                default:
//                    List<PanelProceduresItemWPF> items = new List<PanelProceduresItemWPF>(); //this.ItemsSorted(null);
//                    foreach (PanelProcedureItemID itemid in itemsIDsOriginal)
//                    {
//                        items.Add(this[itemid]);
//                    }
//                    items.Sort(new CompareItems(sort));
//                    itemsIDs.Clear();
//                    foreach (PanelProceduresItemWPF item in items)
//                    {
//                        itemsIDs.Add(item.Data.ID);
//                    }
//                    break;
//            }


//            SetControlsParameters pars = new SetControlsParameters
//            {
//                firstLocation = firstItemLocation,
//                itemsToRearrange = this.ItemsSorted(null)
//            };
//            SetControls(SetControlsType.RearrangeSortedItems, pars);

//        }

//        /// <summary>
//        /// see if scroll buttons are needed
//        /// </summary>
//        /// <param name="lastItem"></param>
//        private void CheckScrollNeeded(PanelProceduresItemWPF lastItem)
//        {
//            //s bool scrolled = !(firstItemLocation.X == 0 && firstItemLocation.Y == 0);
//            //PanelProcedureItem pitem = GetGroupRepresent(lastItem.Data.ID.StudyID);
//            //EventNeedScroll?.Invoke(lastItem.Collapsed && pitem != null ? scrolled || !LocationVisible(pitem.Location) : scrolled || !LocationVisible(lastItem.Location));
//        }

//        /// <summary>
//        /// Arrange controls
//        /// </summary>
//        /// <param name="setType"></param>
//        /// <param name="procedureItem">Add new item after given toSetAfterItem or as last control in the list if toSetAfterItem is null</param>
//        /// <param name="toSetAfterItem">Arrange all after given toSetAfterItem or all if toSetAfterItem is null</param>
//        private void SetControls(SetControlsType setType, SetControlsParameters parameters)
//        {
//            SetControlsParameters pars = new SetControlsParameters();
//            switch (setType)
//            {
//                case SetControlsType.AddItem:
//                    #region Add new item as last control in the list or after given toSetAfterItem

//                    Point location = new Point(0, -ItemSize.Height);  //location of the control to set item after

//                    if (parameters.toSetAfterItem is null)  // if toSetAfterItem place new item as the last in the list
//                    {

//                        //find location of the last item
//                        for (int i = itemsIDs.Count - 1; i >= 0; i--)
//                        {
//                            if (!this[itemsIDs[i]].Collapsed || this[itemsIDs[i]].GroupRepresent)
//                            {
//                                location = this[itemsIDs[i]].Location;
//                                break;
//                            }
//                        }

//                        itemsIDs.Add(parameters.procedureItem.Data.ID);
//                        itemsIDsOriginal.Add(parameters.procedureItem.Data.ID);

//                    }
//                    else
//                    {
//                        location = parameters.toSetAfterItem.Location;
//                        itemsIDs.Insert(GetItemIndex(parameters.toSetAfterItem.Data.ID) + 1, parameters.procedureItem.Data.ID);
//                        itemsIDsOriginal.Insert(GetItemIndex(parameters.toSetAfterItem.Data.ID) + 1, parameters.procedureItem.Data.ID);

//                        if (parameters.toSetAfterItem.Collapsed && parameters.toSetAfterItem.Data.ID.StudyID != parameters.procedureItem.Data.ID.StudyID) // if group is collapsed, add item after last in the group 
//                        {
//                            PanelProceduresItemWPF pitem = GetGroupRepresent(parameters.toSetAfterItem.Data.ID.StudyID);
//                            if (pitem != null) location = pitem.Location;

//                        }
//                    }


//                    //s if (parameters.procedureItem.Collapsed && !parameters.procedureItem.GroupRepresent) doExpand = false;
//                    parameters.procedureItem.Location = LocationNext(location);
//                    parameters.procedureItem.Visible = (!parameters.procedureItem.Collapsed || parameters.procedureItem.GroupRepresent);
//                    parameters.procedureItem.Size = this.ItemSize;

//                    this.Controls.Add(parameters.procedureItem);
//                    EventItemsCountChanged?.Invoke(this.Controls.Count);
//                    // ovo treba iz WL if (this.Controls.Count == 1 && this.ItemsCheckMode == PanelProceduresCheckMode.Single && this.LeaveOneCheckedInSingleCheckMode) parameters.procedureItem.Checked = true;


//                    //refresh only if visible item and set somewhere in the middle
//                    if (parameters.procedureItem.Visible && parameters.toSetAfterItem != null)
//                    {
//                        pars.itemsToRearrange = this.ItemsSorted(parameters.procedureItem.Data.ID);
//                        if (pars.itemsToRearrange != null && pars.itemsToRearrange.Count > 0)
//                        {
//                            pars.firstLocation = LocationNext(parameters.procedureItem.Location);
//                            SetControls(SetControlsType.RearrangeSortedItems, pars);
//                        }

//                    }
//                    else if (itemsIDs.Count > 0)
//                    {
//                        CheckScrollNeeded(this[itemsIDs[itemsIDs.Count - 1]]);

//                    }


//                    // or if in collapsed group - to refresh repre. thumb
//                    if (parameters.procedureItem.Collapsed)
//                    {
//                        PanelProceduresItemWPF pitem = GetGroupRepresent(parameters.procedureItem.Data.ID.StudyID);
//                        if (pitem != null) pitem.Refresh();
//                    }

//                    #endregion
//                    break;

//                case SetControlsType.RemoveItem:
//                    //pars.firstLocation = parameters.procedureItem.Location;
//                    //pars.firstLocationVisible = LocationVisible(pars.firstLocation);
//                    //pars.itemsToRearrange = this.ItemsSorted(parameters.procedureItem.Data.ID);
//                    this.Controls.Remove(parameters.procedureItem);
//                    EventItemsCountChanged?.Invoke(this.Controls.Count);
//                    itemsIDs.Remove(parameters.procedureItem.Data.ID);
//                    itemsIDsOriginal.Remove(parameters.procedureItem.Data.ID);
//                    pars.firstLocation = firstItemLocation;
//                    pars.itemsToRearrange = this.ItemsSorted(null);

//                    SetControls(SetControlsType.RearrangeSortedItems, pars);

//                    ScrollToFillSpace(pars);



//                    break;
//                case SetControlsType.RearrangeSortedItems:
//                    if (parameters.itemsToRearrange == null || parameters.itemsToRearrange.Count == 0) return;

//                    //s if (autoExpand)
//                    //{
//                    if (parameters.firstLocation.X + this.ItemSize.Width <= this.Width)
//                    {

//                    }
//                    else //if (this.AutoExpandMaximumNumberOfColumns > this.AutoExpandMinimumNumberOfColumns && this.AutoExpandMaximumNumberOfColumns > this.Width / ItemSize.Width)
//                    {
//                        this.Width = Math.Max(Math.Min(parameters.firstLocation.X + this.ItemSize.Width, MaxWidth), MinWidth);
//                    }
//                    //}

//                    foreach (PanelProceduresItemWPF pitem in parameters.itemsToRearrange)
//                    {
//                        if (pitem.Collapsed && !pitem.GroupRepresent)
//                        {
//                            if (pitem.Visible) pitem.Visible = false;
//                        }
//                        else
//                        {
//                            if (!pitem.Location.Equals(parameters.firstLocation)) pitem.Location = parameters.firstLocation;
//                            parameters.firstLocation = LocationNext(parameters.firstLocation);
//                        }

//                    }

//                    for (int i = parameters.itemsToRearrange.Count - 1; i >= 0; i--)
//                    {
//                        if (!parameters.itemsToRearrange[i].Collapsed || parameters.itemsToRearrange[i].GroupRepresent)
//                        {
//                            DeallocateSpace(parameters.itemsToRearrange[i]);
//                            break;
//                        }
//                    }

//                    CheckScrollNeeded(parameters.itemsToRearrange[parameters.itemsToRearrange.Count - 1]);
//                    break;
//            }
//        }

//        //TODO ova procedura nije optimizovana - pitanje je i da li radi tacno ono sto hocemo
//        private void ScrollToFillSpace(SetControlsParameters pars)
//        {
//            for (int i = pars.itemsToRearrange.Count - 1; i >= 0; i--)
//            {
//                if (!pars.itemsToRearrange[i].Collapsed || pars.itemsToRearrange[i].GroupRepresent)
//                {
//                    // if last visible but there are some (up) unvisible - scroll down
//                    bool loop = true;
//                    while (LocationNext(pars.itemsToRearrange[i].Location) != null && loop)
//                    {
//                        if (firstItemLocation.X < 0 || firstItemLocation.Y < 0) //update first item location
//                        {
//                            firstItemLocation = LocationNext(firstItemLocation);
//                            pars.firstLocation = firstItemLocation;

//                            SetControls(SetControlsType.RearrangeSortedItems, pars);

//                        }
//                        else
//                        {
//                            loop = false;
//                        }


//                    }
//                    break;
//                }
//            }
//        }
//        /// <summary>
//        /// Get location for control before given location
//        /// </summary>
//        /// <param name="location"></param>
//        /// <param name="visible"></param>
//        /// <returns></returns>
//        private Point LocationPrevious(Point location)
//        {
//            Point locationNew = location;

//            if (location.Y - this.ItemSize.Height >= 0)
//            {
//                locationNew = new Point(location.X, location.Y - this.ItemSize.Height);

//            }
//            else
//            {
//                int Y = 0;
//                while (Y + 2 * ItemSize.Height <= this.Height)
//                {
//                    Y += ItemSize.Height;
//                }
//                locationNew = new Point(location.X - this.ItemSize.Width, Y);
//            }

//            return locationNew;
//        }

//        /// <summary>
//        /// Get location of previous column used for scrolling by column
//        /// </summary>
//        /// <param name="location"></param>
//        /// <param name="visible"></param>
//        /// <returns></returns>
//        private Point LocationPreviousColumn(Point location)
//        {
//            Point locationNew = new Point(location.X - this.ItemSize.Width, 0);

//            return locationNew;
//        }

//        /// <summary>
//        /// Get location of next column used for scrolling by column
//        /// </summary>
//        /// <param name="location"></param>
//        /// <param name="visible"></param>
//        /// <returns></returns>
//        private Point LocationNextColumn(Point location)
//        {
//            Point locationNew = new Point(location.X + this.ItemSize.Width, 0);
//            return locationNew;
//        }

//        /// <summary>
//        /// Get location for control after given location and expand if allocating
//        /// </summary>
//        /// <param name="location">given location</param>
//        /// <param name="visible">will it be visible</param>
//        /// <returns></returns>
//        private Point LocationNext(Point location)
//        {
//            Point locationNew = location;

//            if (location.Y + 2 * this.ItemSize.Height <= this.Height)
//            {
//                // can be placed bellow last control
//                locationNew = new Point(location.X, location.Y + this.ItemSize.Height);
//                ////if (location.X + this.ItemSize.Width > this.Width && this.AutoExpandMaximumNumberOfColumns > this.AutoExpandMinimumNumberOfColumns && this.AutoExpandMaximumNumberOfColumns > this.Width / ItemSize.Width)
//                ////{
//                ////    if ((doExpand && autoExpand) || this.ManualExpandMinimumNumberOfColumns > this.Width / this.ItemSize.Width)
//                ////        this.Width += ItemSize.Width;
//                ////}

//            }
//            else
//            {

//                locationNew = new Point(location.X + this.ItemSize.Width, 0);


//            }

//            //s if (doExpand && autoExpand)
//            //{
//            if (locationNew.X + this.ItemSize.Width <= this.Width)
//            {
//                //can be placed beside on the top of the next row 
//            }
//            else //if (this.AutoExpandMaximumNumberOfColumns > this.AutoExpandMinimumNumberOfColumns && this.AutoExpandMaximumNumberOfColumns > this.Width / ItemSize.Width)
//            {
//                this.Width = Math.Max(Math.Min(locationNew.X + this.ItemSize.Width, MaxWidth), MinWidth);
//            }
//            //}

//            //visible = LocationVisible(locationNew);
//            return locationNew;
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="lastItem"></param>
//        private void DeallocateSpace(PanelProceduresItemWPF lastItem)
//        {
//            if (lastItem != null)
//            {
//                this.Width = Math.Max(Math.Min(lastItem.Right, MaxWidth), MinWidth);

//            }
//            else
//            {
//                this.Width = Math.Max(0, MinWidth);
//                //while ((this.Width - ItemSize.Width) / ItemSize.Width >= this.AutoExpandMinimumNumberOfColumns)
//                //{
//                //    this.Width -= ItemSize.Width;
//                //}
//            }

//        }


//        /// <summary>
//        /// Is given location visible
//        /// </summary>
//        /// <param name="location">given location</param>
//        /// <returns></returns>
//        //s private bool LocationVisible(Point location)
//        //{
//        //    if (location.Y + this.ItemSize.Height <= this.Height && location.X + this.ItemSize.Width <= this.Width && location.Y >= 0 && location.X >= 0)
//        //    {
//        //        return true;
//        //    }

//        //    return false;
//        //}

//        #region item events
//        /// <summary>
//        /// Occurs when item checked changes. In single check mode, decheck others
//        /// </summary>
//        /// <param name="item"></param>
//        private void Item_EventCheckedChanged(PanelProceduresItemWPF item)
//        {
//            //relevantno samo za APR selekciju
//            if (item.Checked && this.Properties.ItemsCheckMode == PanelProceduresCheckMode.Single)
//            {
//                foreach (Control pitem in this.Controls)
//                {
//                    if (pitem is PanelProceduresItemWPF && !item.Equals(pitem))
//                    {
//                        ((PanelProceduresItemWPF)pitem).Checked = false;
//                        EventItemCheckedChanged?.Invoke(((PanelProceduresItemWPF)pitem).Data.ID, false);
//                    }
//                }
//            }
//            EventItemCheckedChanged?.Invoke(item.Data.ID, item.Checked);
//            if (this.MainMode == PanelProceduresMode.APRSelection && item.Checked)
//            {
//                TAPRSelectionData apr = new TAPRSelectionData
//                {
//                    APRId = item.Data.APRId,
//                    SelectionType = item.Data.APRSelection,
//                    Side = item.Data.APRSide
//                };

//                TGlobalDispatch.SetAPREntry = apr;
//                if (this.Properties.ItemsCheckMode == PanelProceduresCheckMode.SingleAutoDeCheck)
//                {
//                    item.Checked = false;
//                    EventItemCheckedChanged?.Invoke(item.Data.ID, false);
//                }

//            }
//        }

//        /// <summary>
//        /// get list of bmps for given group 
//        /// </summary>
//        /// <param name="item"></param>
//        private List<Bitmap> Item_EventGetGroupImages(TUniqueId groupID)
//        {
//            List<Bitmap> bitmaps = new List<Bitmap>();
//            List<PanelProceduresItemWPF> group = GetItemsForGroup(groupID);
//            foreach (PanelProceduresItemWPF pitem in group)
//            {
//                if (pitem.ThumbImages != null) bitmaps.AddRange(pitem.ThumbImages);
//            }

//            return bitmaps;
//        }

//        /// <summary>
//        /// Occurs when user double clicks for (de)collapsing the group
//        /// </summary>
//        /// <param name="item"></param>
//        private void Item_EventCollapseChanged(PanelProceduresItemWPF item)
//        {
//            bool collapsedGroup = item.Collapsed;
//            List<PanelProceduresItemWPF> group = GetItemsForGroup(item.Data.ID.StudyID);
//            bool visible;
//            foreach (PanelProceduresItemWPF pitem in group)
//            {
//                if (collapsedGroup && (pitem.Location.X < 0 || pitem.Location.Y < 0))
//                    firstItemLocation = LocationNext(firstItemLocation);
//                pitem.Collapsed = collapsedGroup;
//                pitem.GroupRepresent = false;
//            }


//            item.GroupRepresent = collapsedGroup;
//            item.Refresh();

//            SetControlsParameters pars = new SetControlsParameters
//            {
//                itemsToRearrange = this.ItemsSorted(null),
//                firstLocation = firstItemLocation
//            };
//            SetControls(SetControlsType.RearrangeSortedItems, pars);
//        }

//        /// <summary>
//        /// Notifies item if can be dechecked on click
//        /// </summary>
//        /// <returns></returns>
//        private bool Item_EventCanDecheckOnClick()
//        {
//            return this.Properties.ItemsCheckMode != PanelProceduresCheckMode.SingleAutoDeCheck && (this.Properties.ItemsCheckMode == PanelProceduresCheckMode.Multi || !this.Properties.LeaveOneCheckedInSingleCheckMode);
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <returns></returns>
//        private bool Item_getMark(PanelProceduresItemWPF item)
//        {
//            if (inManualSorting)
//            {
//                // numerate
//                if (!item.Collapsed && !item.Data.Flags.HasFlag(PanelProcedureItemFlags.HasSortingIndex))
//                {
//                    item.Data.Flags |= PanelProcedureItemFlags.HasSortingIndex;
//                    item.SortingIndex = manualCurrentSortingIndex;
//                    manualCurrentSortingIndex += 1;
//                    item.Refresh();
//                }

//                // check if all items have sorting index - if yes, sort them automatically and leave sort mode
//                foreach (Control c in this.Controls)
//                {
//                    if (c is PanelProceduresItemWPF && !((PanelProceduresItemWPF)c).Data.Flags.HasFlag(PanelProcedureItemFlags.HasSortingIndex))
//                        return true;
//                }
//                SortItems(SortType.Manual);
//                LeaveManualSorting();
//                return true;
//            }
//            else if (inMarkingItems)
//            {
//                // numerate
//                if (!item.Collapsed)
//                {
//                    if (item.Data.Flags.HasFlag(PanelProcedureItemFlags.Marked))
//                        item.Data.Flags &= ~PanelProcedureItemFlags.Marked;
//                    else
//                        item.Data.Flags |= PanelProcedureItemFlags.Marked;
//                    item.Refresh();
//                }


//                return true;
//            }


//            return false;

//        }



//        #endregion

//        #region context menu logic


//        private void InitializeContextMenu()
//        {
//            if (this.contextMenuOptions == ContextMenuOptions.None) return;
//            contextMenu.Items.Clear();
//            contextMenu.BackColor = this.BackColor;
//            contextMenu.ForeColor = Color.Yellow;

//            if (this.contextMenuOptions.HasFlag(ContextMenuOptions.CopyPaste))
//            {
//                ToolStripMenuItem toolStripMenuItemCopy = new System.Windows.Forms.ToolStripMenuItem
//                {
//                    Name = "toolStripMenuItemCopy",
//                    //toolStripMenuItem1.Size = new System.Drawing.Size(86, 24);
//                    Text = "Copy"
//                };
//                contextMenu.Items.Add(toolStripMenuItemCopy);
//                toolStripMenuItemCopy.Click += ToolStripMenuItemCopy_Click;

//                ToolStripMenuItem toolStripMenuItemPaste = new System.Windows.Forms.ToolStripMenuItem
//                {
//                    Name = "toolStripMenuItemPaste",
//                    Text = "Paste",
//                    Enabled = false
//                };
//                contextMenu.Items.Add(toolStripMenuItemPaste);
//                toolStripMenuItemPaste.Click += ToolStripMenuItemPaste_Click;

//                ToolStripSeparator toolStripSeparator = new ToolStripSeparator();
//                contextMenu.Items.Add(toolStripSeparator);
//            }

//            if (this.contextMenuOptions.HasFlag(ContextMenuOptions.SortBy))
//            {
//                ToolStripMenuItem toolStripMenuItemSortBy = new System.Windows.Forms.ToolStripMenuItem
//                {
//                    Name = "toolStripMenuItemSortBy",
//                    Text = "Sort by"
//                };
//                contextMenu.Items.Add(toolStripMenuItemSortBy);

//                ToolStripMenuItem toolStripMenuItemSortByDefault = new System.Windows.Forms.ToolStripMenuItem
//                {
//                    BackColor = contextMenu.BackColor,
//                    ForeColor = contextMenu.ForeColor,
//                    Font = contextMenu.Font,
//                    DisplayStyle = ToolStripItemDisplayStyle.Text,
//                    Name = "toolStripMenuItemSortByDefault",
//                    Text = "Default",
//                    Tag = SortType.Default

//                };
//                ToolStripMenuItem toolStripMenuItemSortByGroup = new System.Windows.Forms.ToolStripMenuItem
//                {
//                    BackColor = contextMenu.BackColor,
//                    ForeColor = contextMenu.ForeColor,
//                    Font = contextMenu.Font,
//                    DisplayStyle = ToolStripItemDisplayStyle.Text,
//                    Name = "toolStripMenuItemSortByGroup",
//                    Text = "Group",
//                    Tag = SortType.ByGroup
//                };
//                ToolStripMenuItem toolStripMenuItemSortByName = new System.Windows.Forms.ToolStripMenuItem
//                {
//                    BackColor = contextMenu.BackColor,
//                    ForeColor = contextMenu.ForeColor,
//                    Font = contextMenu.Font,
//                    DisplayStyle = ToolStripItemDisplayStyle.Text,
//                    Name = "toolStripMenuItemSortByName",
//                    Text = "Name",
//                    Tag = SortType.ByName
//                };
//                ToolStripMenuItem toolStripMenuItemSortByAcqTime = new System.Windows.Forms.ToolStripMenuItem
//                {
//                    BackColor = contextMenu.BackColor,
//                    ForeColor = contextMenu.ForeColor,
//                    Font = contextMenu.Font,
//                    DisplayStyle = ToolStripItemDisplayStyle.Text,
//                    Name = "toolStripMenuItemSortByAcqTime",
//                    Text = "Acquisition time",
//                    Tag = SortType.ByAcqTime
//                };
//                ToolStripMenuItem toolStripMenuItemSortByAccNumber = new System.Windows.Forms.ToolStripMenuItem
//                {
//                    BackColor = contextMenu.BackColor,
//                    ForeColor = contextMenu.ForeColor,
//                    Font = contextMenu.Font,
//                    DisplayStyle = ToolStripItemDisplayStyle.Text,
//                    Name = "toolStripMenuItemSortByAccNumber",
//                    Text = "Accession number",
//                    Tag = SortType.ByAccNumber
//                };
//                toolStripMenuItemSortByDefault.Click += ToolStripMenuItemSortBy_Click;
//                toolStripMenuItemSortByName.Click += ToolStripMenuItemSortBy_Click;
//                toolStripMenuItemSortByAcqTime.Click += ToolStripMenuItemSortBy_Click;
//                toolStripMenuItemSortByAccNumber.Click += ToolStripMenuItemSortBy_Click;
//                toolStripMenuItemSortByGroup.Click += ToolStripMenuItemSortBy_Click;

//                toolStripMenuItemSortBy.DropDownItems.Add(toolStripMenuItemSortByDefault);
//                toolStripMenuItemSortBy.DropDownItems.Add(toolStripMenuItemSortByGroup);
//                toolStripMenuItemSortBy.DropDownItems.Add(toolStripMenuItemSortByName);
//                toolStripMenuItemSortBy.DropDownItems.Add(toolStripMenuItemSortByAcqTime);
//                toolStripMenuItemSortBy.DropDownItems.Add(toolStripMenuItemSortByAccNumber);

//            }

//            if (this.contextMenuOptions.HasFlag(ContextMenuOptions.ManualSorting))
//            {
//                ToolStripMenuItem toolStripMenuItemStartManualSorting = new System.Windows.Forms.ToolStripMenuItem
//                {
//                    Name = "toolStripMenuItemStartManualSorting",
//                    Text = "Start manual sorting"
//                };
//                contextMenu.Items.Add(toolStripMenuItemStartManualSorting);
//                toolStripMenuItemStartManualSorting.Click += ToolStripMenuItemStartManualSorting_Click;

//                ToolStripMenuItem toolStripMenuItemCompleteManualSorting = new System.Windows.Forms.ToolStripMenuItem
//                {
//                    Name = "toolStripMenuItemCompleteManualSorting",
//                    Text = "Complete manual sorting"
//                };
//                contextMenu.Items.Add(toolStripMenuItemCompleteManualSorting);
//                toolStripMenuItemCompleteManualSorting.Click += ToolStripMenuItemCompleteManualSorting_Click;


//            }
//            if (this.contextMenuOptions.HasFlag(ContextMenuOptions.SortBy) || this.contextMenuOptions.HasFlag(ContextMenuOptions.ManualSorting))
//            {
//                ToolStripSeparator toolStripSeparator = new ToolStripSeparator();
//                contextMenu.Items.Add(toolStripSeparator);
//            }

//            if (this.contextMenuOptions.HasFlag(ContextMenuOptions.MarkProjections))
//            {
//                ToolStripMenuItem toolStripMenuItemStartMarking = new System.Windows.Forms.ToolStripMenuItem
//                {
//                    Name = "toolStripMenuItemStartMarking",
//                    Text = "Mark projections"
//                };
//                contextMenu.Items.Add(toolStripMenuItemStartMarking);
//                toolStripMenuItemStartMarking.Click += ToolStripMenuItemStartMarking_Click;

//                ToolStripMenuItem toolStripMenuItemCompleteMarking = new System.Windows.Forms.ToolStripMenuItem
//                {
//                    Name = "toolStripMenuItemCompleteMarking",
//                    Text = "Exit marking projections mode"
//                };
//                contextMenu.Items.Add(toolStripMenuItemCompleteMarking);
//                toolStripMenuItemCompleteMarking.Click += ToolStripMenuItemCompleteMarking_Click;

//                ToolStripSeparator toolStripSeparator = new ToolStripSeparator();
//                contextMenu.Items.Add(toolStripSeparator);
//            }

//            if (this.contextMenuOptions.HasFlag(ContextMenuOptions.Print))
//            {
//                ToolStripMenuItem toolStripMenuItemPrint = new System.Windows.Forms.ToolStripMenuItem
//                {
//                    Name = "toolStripMenuItemPrint",
//                    Text = "Print"
//                };
//                contextMenu.Items.Add(toolStripMenuItemPrint);
//                toolStripMenuItemPrint.Click += ToolStripMenuItemPrint_Click;

//                ToolStripSeparator toolStripSeparator = new ToolStripSeparator();
//                contextMenu.Items.Add(toolStripSeparator);
//            }
//            if (this.contextMenuOptions.HasFlag(ContextMenuOptions.SetDose))
//            {
//                ToolStripMenuItem toolStripMenuItemSetDose = new System.Windows.Forms.ToolStripMenuItem
//                {
//                    Name = "toolStripMenuItemSetDose",
//                    Text = "Set dose"
//                };
//                contextMenu.Items.Add(toolStripMenuItemSetDose);
//                toolStripMenuItemSetDose.Click += ToolStripMenuItemSetDose_Click;

//                ToolStripSeparator toolStripSeparator = new ToolStripSeparator();
//                contextMenu.Items.Add(toolStripSeparator);
//            }







//            this.ContextMenuStrip = contextMenu;
//            this.contextMenu.Opening += ContextMenu_Opening;
//        }

//        private void ContextMenu_Opening(object sender, CancelEventArgs e)
//        {
//            bool itemClicked = true;
//            PanelProcedureItemID? id = null;
//            if (!(contextMenu.SourceControl is PanelProcedureItemWPF))
//                itemClicked = false;
//            if (itemClicked)
//                id = ((PanelProcedureItemWPF)(contextMenu.SourceControl)).Data.ID;

//            if (contextMenu.Items.ContainsKey("toolStripMenuItemCopy")) contextMenu.Items["toolStripMenuItemCopy"].Enabled = itemClicked && !this[(PanelProcedureItemID)id].Collapsed;
//            if (contextMenu.Items.ContainsKey("toolStripMenuItemPaste")) contextMenu.Items["toolStripMenuItemPaste"].Enabled = itemClicked && contextMenuItemIDCopy != null && !this[(PanelProcedureItemID)id].Collapsed && this[(PanelProcedureItemID)id].MultiFrame == 0;
//            if (contextMenu.Items.ContainsKey("toolStripMenuItemPrint")) contextMenu.Items["toolStripMenuItemPrint"].Enabled = (itemClicked && !this[(PanelProcedureItemID)id].Collapsed) || HasMarkedItems();
//            if (contextMenu.Items.ContainsKey("toolStripMenuItemSetDose")) contextMenu.Items["toolStripMenuItemSetDose"].Enabled = (itemClicked && !this[(PanelProcedureItemID)id].Collapsed) || HasMarkedItems();

//            if (contextMenu.Items.ContainsKey("toolStripMenuItemStartManualSorting"))
//            {
//                contextMenu.Items["toolStripMenuItemStartManualSorting"].Text = (inManualSorting ? "Restart manual sorting" : "Start manual sorting");
//                contextMenu.Items["toolStripMenuItemStartManualSorting"].Enabled = !inMarkingItems;
//            }
//            if (contextMenu.Items.ContainsKey("toolStripMenuItemCompleteManualSorting")) contextMenu.Items["toolStripMenuItemCompleteManualSorting"].Enabled = inManualSorting;

//            if (contextMenu.Items.ContainsKey("toolStripMenuItemStartMarking"))
//            {
//                contextMenu.Items["toolStripMenuItemStartMarking"].Enabled = !inManualSorting;
//            }
//            if (contextMenu.Items.ContainsKey("toolStripMenuItemCompleteMarking")) contextMenu.Items["toolStripMenuItemCompleteMarking"].Enabled = inMarkingItems;

//            contextMenuItemIDClicked = id;
//        }

//        private void ToolStripMenuItemSortBy_Click(object sender, EventArgs e)
//        {
//            if (sender is ToolStripMenuItem && ((ToolStripMenuItem)sender).Tag is SortType)
//                SortItems((SortType)(((ToolStripMenuItem)sender).Tag));
//        }

//        private void ToolStripMenuItemPrint_Click(object sender, EventArgs e)
//        {
//            List<PanelProcedureItemID> ids = new List<PanelProcedureItemID>();
//            if (inMarkingItems)
//                ids = ItemsMarked;
//            else if (contextMenuItemIDClicked != null && !this[(PanelProcedureItemID)contextMenuItemIDClicked].Collapsed)
//                ids.Add((PanelProcedureItemID)contextMenuItemIDClicked);

//            if (ids.Count > 0) EventPrint?.Invoke(ids);
//        }

//        private void ToolStripMenuItemSetDose_Click(object sender, EventArgs e)
//        {
//            List<PanelProcedureItemID> ids = new List<PanelProcedureItemID>();
//            if (inMarkingItems)
//                ids = ItemsMarked;
//            else if (contextMenuItemIDClicked != null && !this[(PanelProcedureItemID)contextMenuItemIDClicked].Collapsed)
//                ids.Add((PanelProcedureItemID)contextMenuItemIDClicked);

//            if (ids.Count > 0) EventSetDose?.Invoke(ids);

//        }

//        private void ToolStripMenuItemStartManualSorting_Click(object sender, EventArgs e)
//        {
//            LeaveManualSorting();
//            inManualSorting = true;

//        }

//        private void ToolStripMenuItemCompleteManualSorting_Click(object sender, EventArgs e)
//        {
//            SortItems(SortType.Manual);
//            LeaveManualSorting();
//        }

//        private void LeaveManualSorting()
//        {
//            foreach (Control pitem in this.Controls)
//            {
//                if (pitem is PanelProceduresItemWPF)
//                {
//                    ((PanelProceduresItemWPF)pitem).Data.Flags &= ~PanelProcedureItemFlags.HasSortingIndex;
//                    pitem.Refresh();
//                }
//            }
//            manualCurrentSortingIndex = 1;
//            inManualSorting = false;
//        }

//        private void ToolStripMenuItemStartMarking_Click(object sender, EventArgs e)
//        {
//            LeaveMarkingMode();
//            inMarkingItems = true;

//        }

//        private void ToolStripMenuItemCompleteMarking_Click(object sender, EventArgs e)
//        {
//            LeaveMarkingMode();
//        }

//        private void LeaveMarkingMode()
//        {
//            foreach (Control pitem in this.Controls)
//            {
//                if (pitem is PanelProceduresItemWPF)
//                {
//                    ((PanelProceduresItemWPF)pitem).Data.Flags &= ~PanelProcedureItemFlags.Marked;
//                    pitem.Refresh();
//                }
//            }
//            inMarkingItems = false;
//        }



//        private void ToolStripMenuItemCopy_Click(object sender, EventArgs e)
//        {
//            if (contextMenuItemIDClicked == null || this[(PanelProcedureItemID)contextMenuItemIDClicked].Collapsed) return;
//            contextMenuItemIDCopy = contextMenuItemIDClicked;
//        }

//        private void ToolStripMenuItemPaste_Click(object sender, EventArgs e)
//        {
//            if (contextMenuItemIDClicked == null || this[(PanelProcedureItemID)contextMenuItemIDClicked].Collapsed) return;
//            PanelProceduresItemWPF item = this[(PanelProcedureItemID)contextMenuItemIDClicked];
//            if (EventCopyPaste?.Invoke((PanelProcedureItemID)contextMenuItemIDCopy, (PanelProcedureItemID)contextMenuItemIDClicked) == true)
//            {
//                item.Data.CopyFrom(this[(PanelProcedureItemID)contextMenuItemIDCopy].Data);
//                //item.Refresh();
//                contextMenuItemIDCopy = null;
//            }

//        }




//        #endregion

//        #region internal types
//        private enum SetControlsType
//        {
//            AddItem,
//            RemoveItem,
//            RearrangeSortedItems
//        }


//        private class SetControlsParameters
//        {
//            public PanelProceduresItemWPF procedureItem; //item to add or remove
//            public PanelProceduresItemWPF toSetAfterItem;
//            public List<PanelProceduresItemWPF> itemsToRearrange;
//            public Point firstLocation;

//        }
//        #endregion
//    }
//}