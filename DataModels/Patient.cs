using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    public class Patient: ObservableObject
    {
        public int PersonID { get; set; }
        //public string DisplayPatientID { get; set; }

        public string DisplayPatientID
        {
            get
            {
                return $"Patient ID: {PersonID}";
            }
        }

        public int BirthYear { get; set; }
        public PatientAge PatientAgeGroup { get; set; }

        public ObservableCollection<Medicine>? MedicineList { get; set; } = new ObservableCollection<Medicine>();

    }
    public enum PatientAge
    {
        _40         = 1,
        _40_50      = 2,
        _50_60      = 3,
        _60_70      = 4,
        _70_        = 5
    }

    public class PatientAgeGroupViewModel: ObservableObject
    {
        public PatientAgeGroupViewModel(PatientAge PatientAge, string PatientAgeGroupName)
        {
            this.PatientAge = PatientAge;
            this.PatientAgeGroupName = PatientAgeGroupName;
        }
        public PatientAgeGroupViewModel(PatientAge PatientAge, string PatientAgeGroupName, int PercentageOfPatients, int NumberOfPatients)
        {
            this.PatientAge = PatientAge;
            this.PatientAgeGroupName = PatientAgeGroupName;
            this.PercentageOfPatients = PercentageOfPatients;
            this.NumberOfPatients = NumberOfPatients;
        }
        public PatientAge PatientAge { get; set; }
        public string PatientAgeGroupName { get; set; }

        private int _percentageOfPatients = 0;
        public int PercentageOfPatients
        {
            get
            {
                return _percentageOfPatients;
            }
            set
            {
                _percentageOfPatients = value;
                OnPropertyChanged(nameof(PercentageOfPatients));
            }
        }

        private int _numberOfPatients = 0;
        public int NumberOfPatients
        {
            get
            {
                return _numberOfPatients;
            }
            set
            {
                _numberOfPatients = value;
                OnPropertyChanged(nameof(NumberOfPatients));
            }
        }

    }
}
