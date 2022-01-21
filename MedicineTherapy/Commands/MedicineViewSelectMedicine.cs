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
        private readonly Medicine _medicine;

        public MedicineViewSelectMedicine(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            //_medicine = medicine;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }


        public void Execute(object parameter)
        {
            _mainViewModel.PatientAgeGroupCollection = new ObservableCollection<PatientAgeGroup>();
            Medicine medicineSelected = parameter as Medicine;
            var patientCount = 0;
            if (medicineSelected != null)
            {
                patientCount = medicineSelected.patientList.Count;

                if (patientCount > 0)
                {
                    var totalNumberOfPatients = medicineSelected.patientList.Count;
                    var numberOfPatientsGroup_40 = 0;
                    var numberOfPatientsGroup_40_50 = 0;
                    var numberOfPatientsGroup_50_60 = 0;
                    var numberOfPatientsGroup_60_70 = 0;
                    var numberOfPatientsGroup_70_ = 0;


                    medicineSelected.patientList.ToList().ForEach(patient =>
                    {
                        switch (patient.PatientAgeGroup)
                        {
                            case PatientAge._40:
                                numberOfPatientsGroup_40 += 1;
                                break;
                            case PatientAge._40_50:
                                numberOfPatientsGroup_40_50 += 1;
                                break;
                            case PatientAge._50_60:
                                numberOfPatientsGroup_50_60 += 1;
                                break;
                            case PatientAge._60_70:
                                numberOfPatientsGroup_60_70 += 1;
                                break;
                            case PatientAge._70_:
                                numberOfPatientsGroup_70_ += 1;
                                break;
                        }
                    });


                    _mainViewModel.PatientAgeGroupCollection.Add(new PatientAgeGroup(PatientAge._40, "Under 40 Years",
                        100 * numberOfPatientsGroup_40 / patientCount, numberOfPatientsGroup_40));
                    _mainViewModel.PatientAgeGroupCollection.Add(new PatientAgeGroup(PatientAge._40_50, "40 - 50 Years",
                        100 * numberOfPatientsGroup_40_50 / patientCount, numberOfPatientsGroup_40_50));
                    _mainViewModel.PatientAgeGroupCollection.Add(new PatientAgeGroup(PatientAge._50_60, "50 - 60 Years",
                        100 * numberOfPatientsGroup_50_60 / patientCount, numberOfPatientsGroup_50_60));
                    _mainViewModel.PatientAgeGroupCollection.Add(new PatientAgeGroup(PatientAge._60_70, "60 - 70 Years",
                        100 * numberOfPatientsGroup_60_70 / patientCount, numberOfPatientsGroup_60_70));
                    _mainViewModel.PatientAgeGroupCollection.Add(new PatientAgeGroup(PatientAge._70_, "Over 70 Years",
                        100 * numberOfPatientsGroup_70_ / patientCount, numberOfPatientsGroup_70_));

                }



            }

            _mainViewModel.NumberOfPatientOnSelectedMedicine = $"Number of patients taking selected medicine: {patientCount}";
        }


    }
}
