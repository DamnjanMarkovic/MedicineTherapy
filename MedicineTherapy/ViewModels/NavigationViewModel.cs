using DataModels;
using MedicineTherapy.Commands;
using MedicineTherapy.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace MedicineTherapy.ViewModels
{

    public class NavigationViewModel : ObservableObject
    {

        internal delegate void EventUpdateCurrentViewDelegate(BaseView view);
        internal EventUpdateCurrentViewDelegate EventUpdateCurrentView;

        public ICommand UpdateCurrentViewCommand => new UpdateCurrentView(this, CurrentView);

        private bool _dataChanged = false;

        public bool DataChanged
        {
            get { return _dataChanged; }
            set
            {
                _dataChanged = value;

            }
        }

        private BaseView selectedItem;
        public BaseView SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }


        private BaseView _currentView;
        public BaseView CurrentView
        {
            get
            {
                return _currentView;
            }
            set
            {
                _currentView = value;
                OnPropertyChanged(nameof(CurrentView));
                SelectedItem = _currentView;
            }
        }

        private List<BaseView> _views;
        public List<BaseView> Views
        {
            get
            {
                if (_views == null)
                    _views = new List<BaseView>();
                return _views;
            }
        }

        public NavigationViewModel()
        {
            AddViewModelsToList();
            CurrentView = Views[0];
            EventUpdateCurrentView?.Invoke(CurrentView);

        }

        private void AddViewModelsToList()
        {
            Views.Add(new PatientsView());
            //Views.Add(new PatientsAge());
            Views.Add(new MedicineView());
            Views.Add(new MedicineTypeView());

        }

    }
}
