using MedicineTherapy.DataProvider;
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
        private Brush _background = Brushes.Green;
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

        public MainViewModel()
        {
            Archive archiveProvider = new Archive();
            _patients = archiveProvider.GetPatients();
        }

    }
}
