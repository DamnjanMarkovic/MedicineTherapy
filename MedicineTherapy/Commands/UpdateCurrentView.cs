using MedicineTherapy.ViewModels;
using MedicineTherapy.Views;
using System;
using System.Linq;
using System.Windows.Input;

namespace MedicineTherapy.Commands
{

    public class UpdateCurrentView : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private NavigationViewModel _navigationViewModel;
        private BaseView _currentView;

        public UpdateCurrentView(NavigationViewModel navigationViewModel, BaseView currentView)
        {
            _navigationViewModel = navigationViewModel;
            _currentView = currentView;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }


        public void Execute(object parameter)
        {


            BaseView viewSelected = (BaseView)parameter;

            if (!_navigationViewModel.Views.Contains(viewSelected))
                _navigationViewModel.Views.Add(viewSelected);


            _navigationViewModel.CurrentView = _navigationViewModel.Views
                .FirstOrDefault(vm => vm == viewSelected);


        }


    }
}
