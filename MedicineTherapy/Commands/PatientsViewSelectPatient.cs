using DataModels;
using MedicineTherapy.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MedicineTherapy.Commands
{

    public class PatientsViewSelectPatient : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly MainViewModel _mainViewModel;

        public PatientsViewSelectPatient(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {

            Patient patientSelected = parameter as Patient;
            var medicineCount = 0; 
            
            _mainViewModel.MedicineTypeCollection.ToList().ForEach(medicineTypeGroup =>
            {
                medicineTypeGroup.NumberOfMedicine = 0;
                medicineTypeGroup.MedicinesInType.Clear();
            });
            if (patientSelected != null)
            {
                medicineCount = patientSelected.MedicineList.Count;


                if (medicineCount > 0)
                {
                    patientSelected.MedicineList.ToList().ForEach(medicine =>
                    {
                        switch (medicine.MedicineType)
                        {
                            case MedicineTypeEnum.NewAntiDiabetic:

                                _mainViewModel.MedicineTypeCollection
                                .ToList()
                                .Find(medicineTypeGroup => medicineTypeGroup.MedicineTypeEnum == MedicineTypeEnum.NewAntiDiabetic)
                                .NumberOfMedicine += 1;

                                _mainViewModel.MedicineTypeCollection
                                .ToList()
                                .Find(medicineTypeGroup => medicineTypeGroup.MedicineTypeEnum == MedicineTypeEnum.NewAntiDiabetic)
                                .MedicinesInType.Add(medicine);
                                break;
                            case MedicineTypeEnum.AntiDiabetic:
                                _mainViewModel.MedicineTypeCollection
                                .ToList()
                                .Find(medicineTypeGroup => medicineTypeGroup.MedicineTypeEnum == MedicineTypeEnum.AntiDiabetic)
                                .NumberOfMedicine += 1;

                                _mainViewModel.MedicineTypeCollection
                                .ToList()
                                .Find(medicineTypeGroup => medicineTypeGroup.MedicineTypeEnum == MedicineTypeEnum.AntiDiabetic)
                                .MedicinesInType.Add(medicine);

                                break;
                            case MedicineTypeEnum.Insulin:
                                _mainViewModel.MedicineTypeCollection
                                .ToList()
                                .Find(medicineTypeGroup => medicineTypeGroup.MedicineTypeEnum == MedicineTypeEnum.Insulin)
                                .NumberOfMedicine += 1;

                                _mainViewModel.MedicineTypeCollection
                                .ToList()
                                .Find(medicineTypeGroup => medicineTypeGroup.MedicineTypeEnum == MedicineTypeEnum.Insulin)
                                .MedicinesInType.Add(medicine);
                                break;
                            case MedicineTypeEnum.Dislipidemic:
                                _mainViewModel.MedicineTypeCollection
                                .ToList()
                                .Find(medicineTypeGroup => medicineTypeGroup.MedicineTypeEnum == MedicineTypeEnum.Dislipidemic)
                                .NumberOfMedicine += 1;

                                _mainViewModel.MedicineTypeCollection
                                .ToList()
                                .Find(medicineTypeGroup => medicineTypeGroup.MedicineTypeEnum == MedicineTypeEnum.Dislipidemic)
                                .MedicinesInType.Add(medicine);
                                break;
                            case MedicineTypeEnum.BloodPresure:
                                _mainViewModel.MedicineTypeCollection
                                .ToList()
                                .Find(medicineTypeGroup => medicineTypeGroup.MedicineTypeEnum == MedicineTypeEnum.BloodPresure)
                                .NumberOfMedicine += 1;

                                _mainViewModel.MedicineTypeCollection
                                .ToList()
                                .Find(medicineTypeGroup => medicineTypeGroup.MedicineTypeEnum == MedicineTypeEnum.BloodPresure)
                                .MedicinesInType.Add(medicine);
                                break;
                            case MedicineTypeEnum.HeartMedicine:
                                _mainViewModel.MedicineTypeCollection
                                .ToList()
                                .Find(medicineTypeGroup => medicineTypeGroup.MedicineTypeEnum == MedicineTypeEnum.HeartMedicine)
                                .NumberOfMedicine += 1;

                                _mainViewModel.MedicineTypeCollection
                                .ToList()
                                .Find(medicineTypeGroup => medicineTypeGroup.MedicineTypeEnum == MedicineTypeEnum.HeartMedicine)
                                .MedicinesInType.Add(medicine);
                                break;
                            case MedicineTypeEnum.Other:
                                _mainViewModel.MedicineTypeCollection
                                .ToList()
                                .Find(medicineTypeGroup => medicineTypeGroup.MedicineTypeEnum == MedicineTypeEnum.Other)
                                .NumberOfMedicine += 1;

                                _mainViewModel.MedicineTypeCollection
                                .ToList()
                                .Find(medicineTypeGroup => medicineTypeGroup.MedicineTypeEnum == MedicineTypeEnum.Other)
                                .MedicinesInType.Add(medicine);
                                break;
                            default:
                                break;
                        }
                    });
                }

            }
            _mainViewModel.NavigationViewModel.CurrentView.EventUpdateView?.Invoke();
            _mainViewModel.NumberOfMedicinesOnSelectedPatient = $"Number of medicines taken by the selected patient: {medicineCount}";
        }
    }
}
