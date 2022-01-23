using DataModels;
using DataProvider;
using MedicineTherapy.Commands;
using MedicineTherapy.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media;

namespace MedicineTherapy.ViewModels
{
    public class MainViewModel: ObservableObject
    {
        

        #region Commands
        public ICommand MedicineViewSelectMedicine() => new MedicineViewSelectMedicine(this);
        public ICommand MedicineTypeSelect() => new MedicineTypeSelect(this);
        public ICommand PatientsViewSelectPatient() => new PatientsViewSelectPatient(this);

        #endregion

        #region Properties

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

        private string _numberOfPatientOnSelectedMedicine;
        public string NumberOfPatientOnSelectedMedicine
        {
            get
            {
                return _numberOfPatientOnSelectedMedicine;
            }
            set
            {
                _numberOfPatientOnSelectedMedicine = value;
                OnPropertyChanged(nameof(NumberOfPatientOnSelectedMedicine));
            }
        }
        private string _numberOfMedicinesOnSelectedPatient;
        public string NumberOfMedicinesOnSelectedPatient
        {
            get
            {
                return _numberOfMedicinesOnSelectedPatient;
            }
            set
            {
                _numberOfMedicinesOnSelectedPatient = value;
                OnPropertyChanged(nameof(NumberOfMedicinesOnSelectedPatient));
            }
        }
        
        private ObservableCollection<DataModels.PatientAgeGroupViewModel> _patientAgeGroupCollection = new ObservableCollection<DataModels.PatientAgeGroupViewModel>();
        public ObservableCollection<DataModels.PatientAgeGroupViewModel> PatientAgeGroupCollection
        {
            get
            {
                return _patientAgeGroupCollection;
            }
            set
            {
                _patientAgeGroupCollection = value;
                OnPropertyChanged(nameof(PatientAgeGroupCollection));
            }
        }

        private ObservableCollection<MedicineTypeViewModel> _medicineTypeCollection = new ObservableCollection<MedicineTypeViewModel>();
        public ObservableCollection<MedicineTypeViewModel> MedicineTypeCollection
        {
            get
            {
                return _medicineTypeCollection;
            }
            set
            {
                _medicineTypeCollection = value;
                OnPropertyChanged(nameof(MedicineTypeCollection));
            }
        }
        #endregion

        #region Constructor
        public MainViewModel()
        {
            NavigationViewModel = new NavigationViewModel();
            Archive archiveProvider = new Archive();
            _patients = archiveProvider.GetPatients();
            _medicines = archiveProvider.GetMedicines();
            _medicineTypes = archiveProvider.GetMedicineTypes();
            SetPatientAgeGroupList();
            SetMedicineTypesGroupList();
            SetMedicineInType();
        }

        public void SetMedicineInType()
        {
            _medicineTypeCollection.ToList().ForEach(medicineType =>
            {
                var medList = _medicines.ToList().FindAll(medicine => medicine.MedicineType.ToString() == medicineType.MedicineType);

                medicineType.MedicinesInType = new ObservableCollection<Medicine>(medList);
            });
        }

        private void SetMedicineTypesGroupList()
        {

            _medicineTypeCollection = new ObservableCollection<MedicineTypeViewModel>();
            if (_medicineTypes != null && _medicineTypes.Count > 0) { 
            _medicineTypes.ToList().ForEach(medicineTypeElement =>
            {
                MedicineTypeViewModel medicineType = new MedicineTypeViewModel
                                        (medicineTypeElement.MedicineTyper.ToString(), medicineTypeElement.MedicineTyper);

                _medicineTypeCollection.Add(medicineType);
            });
            }
        }

        private void SetPatientAgeGroupList()
        {
            _patientAgeGroupCollection.Add(new DataModels.PatientAgeGroupViewModel(PatientAge._40, "Under 40 Years"));
            _patientAgeGroupCollection.Add(new DataModels.PatientAgeGroupViewModel(PatientAge._40_50, "40 - 50 Years"));
            _patientAgeGroupCollection.Add(new DataModels.PatientAgeGroupViewModel(PatientAge._50_60, "50 - 60 Years"));
            _patientAgeGroupCollection.Add(new DataModels.PatientAgeGroupViewModel(PatientAge._60_70, "60 - 70 Years"));
            _patientAgeGroupCollection.Add(new DataModels.PatientAgeGroupViewModel(PatientAge._70_, "Over 70 Years"));
        }

        #endregion

    }
}
