using CustomControls;
using DataModels;
using DataProvider;
using MedicineTherapy.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
    
namespace MedicineTherapy.ViewModels
{
    public class MainViewModel: ObservableObject
    {
        private Brush _background = Brushes.DarkBlue;
        public Brush Background
        {
            get
            {
                return _background;
            }
            set
            {
                _background = value;
                OnPropertyChanged(nameof(Background));
            }
        }

        private NavigationViewModel _navigationViewModel;
        public NavigationViewModel NavigationViewModel
        {
            get
            {
                return _navigationViewModel;
            }
            set
            {
                _navigationViewModel = value;
                OnPropertyChanged(nameof(NavigationViewModel));
            }
        }
        private ObservableCollection<Patient> _patients = new ObservableCollection<Patient>();
        public ObservableCollection<Patient> Patients
        {
            get
            {
                return _patients;
            }
            set
            {
                _patients = value;
                OnPropertyChanged(nameof(Patients));
            }
        }

        private ObservableCollection<Medicine> _medicines = new ObservableCollection<Medicine>();
        public ObservableCollection<Medicine> Medicines
        {
            get
            {
                return _medicines;
            }
            set
            {
                _medicines = value;
                OnPropertyChanged(nameof(Medicines));
            }
        }

        private ObservableCollection<MedicineType> _medicineTypes = new ObservableCollection<MedicineType>();
        public ObservableCollection<MedicineType> MedicineTypes
        {
            get
            {
                return _medicineTypes;
            }
            set
            {
                _medicineTypes = value;
                OnPropertyChanged(nameof(MedicineTypes));
            }
        }

        private ObservableCollection<MedicineTypeViewModel> _medicineTypeVMList = new ObservableCollection<MedicineTypeViewModel>();
        public ObservableCollection<MedicineTypeViewModel> MedicineTypeVMList
        {
            get
            {
                return _medicineTypeVMList;
            }
            set
            {
                _medicineTypeVMList = value;
                OnPropertyChanged(nameof(MedicineTypeVMList));
            }
        }

        public MainViewModel()
        {
            NavigationViewModel = new NavigationViewModel();
            Archive archiveProvider = new Archive();
            _patients = archiveProvider.GetPatients();
            _medicines = archiveProvider.GetMedicines();
            _medicineTypes = archiveProvider.GetMedicineTypes();
            SetMedicineTypeList();
        }

        private void SetMedicineTypeList()
        {
            _medicineTypeVMList = new ObservableCollection<MedicineTypeViewModel>();
            _medicineTypes.ToList().ForEach(medicineTypeElement =>
            {
                MedicineTypeViewModel medicineType = new MedicineTypeViewModel();
                medicineType.MedicineType = medicineTypeElement.MedicineTyper.ToString();
                medicineType.NumberOfMedicine = medicineTypeElement.MedicineList.Count;

                medicineType.MedicineList = medicineTypeElement.MedicineList.ToList().Select(i => i.MedicineName).ToList();

                _medicineTypeVMList.Add(medicineType);
            });
        }
    }
}
