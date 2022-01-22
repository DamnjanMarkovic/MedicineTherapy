using MedicineTherapy.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace MedicineTherapy.Views
{
    public class BaseView : UserControl, INotifyPropertyChanged
    {

        public delegate void EventUpdateViewDelegate();
        public EventUpdateViewDelegate EventUpdateView;

        public MainViewModel dataContext { get; set; }

        public ListCollectionView collectionView;

        private string _viewInfo;
        public string ViewInfo
        {
            get
            {
                return _viewInfo;
            }
            set
            {
                _viewInfo = value;
                OnPropertyChanged(nameof(ViewInfo));
            }
        }


        public string ViewName { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
