using DataModels;
using MedicineTherapy.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MedicineTherapy.Commands
{    
    public class MedicineViewSelectMedicine : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly MainViewModel _mainViewModel;

        public MedicineViewSelectMedicine(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }


        public void Execute(object parameter)
        {
            Medicine medicineSelected = parameter as Medicine;
            var patientCount = 0;
            if (medicineSelected != null)
            {
                patientCount = medicineSelected.patientList.Count;
                
                _mainViewModel.PatientAgeGroupCollection.ToList().ForEach(patientAgeGroup =>
                {
                    patientAgeGroup.NumberOfPatients = 0;
                    patientAgeGroup.PercentageOfPatients = 0;
                });
                if (patientCount > 0)
                {

                    medicineSelected.patientList.ToList().ForEach(patient =>
                    {
                        switch (patient.PatientAgeGroup)
                        {
                            case PatientAge._40:
                                _mainViewModel.PatientAgeGroupCollection
                                .ToList()
                                .Find(patientAgeGroup => patientAgeGroup.PatientAge == PatientAge._40)
                                .NumberOfPatients += 1;

                                _mainViewModel.PatientAgeGroupCollection
                                .ToList()
                                .Find(patientAgeGroup => patientAgeGroup.PatientAge == PatientAge._40)
                                .PercentageOfPatients = (100 *
                                _mainViewModel.PatientAgeGroupCollection
                                .ToList()
                                .Find(patientAgeGroup => patientAgeGroup.PatientAge == PatientAge._40)
                                .NumberOfPatients) / patientCount;

                                break;
                            case PatientAge._40_50:
                                _mainViewModel.PatientAgeGroupCollection
                                .ToList()
                                .Find(patientAgeGroup => patientAgeGroup.PatientAge == PatientAge._40_50)
                                .NumberOfPatients += 1;

                                _mainViewModel.PatientAgeGroupCollection
                                .ToList()
                                .Find(patientAgeGroup => patientAgeGroup.PatientAge == PatientAge._40_50)
                                .PercentageOfPatients = (100 *
                                _mainViewModel.PatientAgeGroupCollection
                                .ToList()
                                .Find(patientAgeGroup => patientAgeGroup.PatientAge == PatientAge._40_50)
                                .NumberOfPatients) / patientCount;

                                break;
                            case PatientAge._50_60:
                                _mainViewModel.PatientAgeGroupCollection
                                .ToList()
                                .Find(patientAgeGroup => patientAgeGroup.PatientAge == PatientAge._50_60)
                                .NumberOfPatients += 1;
                                
                                _mainViewModel.PatientAgeGroupCollection
                                .ToList()
                                .Find(patientAgeGroup => patientAgeGroup.PatientAge == PatientAge._50_60)
                                .PercentageOfPatients = (100 *
                                _mainViewModel.PatientAgeGroupCollection
                                .ToList()
                                .Find(patientAgeGroup => patientAgeGroup.PatientAge == PatientAge._50_60)
                                .NumberOfPatients) / patientCount;
                                break;
                            case PatientAge._60_70:
                                _mainViewModel.PatientAgeGroupCollection
                                .ToList()
                                .Find(patientAgeGroup => patientAgeGroup.PatientAge == PatientAge._60_70)
                                .NumberOfPatients += 1;
                                
                                _mainViewModel.PatientAgeGroupCollection
                                .ToList()
                                .Find(patientAgeGroup => patientAgeGroup.PatientAge == PatientAge._60_70)
                                .PercentageOfPatients = (100 *
                                _mainViewModel.PatientAgeGroupCollection
                                .ToList()
                                .Find(patientAgeGroup => patientAgeGroup.PatientAge == PatientAge._60_70)
                                .NumberOfPatients) / patientCount;
                                break;
                            case PatientAge._70_:
                                _mainViewModel.PatientAgeGroupCollection
                                .ToList()
                                .Find(patientAgeGroup => patientAgeGroup.PatientAge == PatientAge._70_)
                                .NumberOfPatients += 1;
                                
                                _mainViewModel.PatientAgeGroupCollection
                                .ToList()
                                .Find(patientAgeGroup => patientAgeGroup.PatientAge == PatientAge._70_)
                                .PercentageOfPatients = (100 *
                                _mainViewModel.PatientAgeGroupCollection
                                .ToList()
                                .Find(patientAgeGroup => patientAgeGroup.PatientAge == PatientAge._70_)
                                .NumberOfPatients) / patientCount;
                                
                                break;
                        }
                    });
                }
            }

            _mainViewModel.NumberOfPatientOnSelectedMedicine = $"Number of patients taking selected medicine: {patientCount}";
        }
    }
}
