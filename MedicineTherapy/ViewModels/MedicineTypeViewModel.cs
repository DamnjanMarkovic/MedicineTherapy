using DataModels;
using MedicineTherapy.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineTherapy.ViewModels
{
    public class MedicineTypeViewModel: ObservableObject
    {
        public MedicineTypeViewModel(string MedicineType, MedicineTypeEnum MedicineTypeEnum)
        {
            this.MedicineTypeEnum = MedicineTypeEnum;
            this.MedicineType = MedicineType;
        }

        public MedicineTypeEnum MedicineTypeEnum { get; set; }
        public string MedicineType { get; set; }
        private int _numberOfMedicine = 0;
        public int NumberOfMedicine
        {
            get
            {
                return _numberOfMedicine;
            }
            set
            {
                _numberOfMedicine = value;
                OnPropertyChanged(nameof(NumberOfMedicine));
            }
        }

        private ObservableCollection<Medicine> _medicinesInType = new ObservableCollection<Medicine>();
        public ObservableCollection<Medicine> MedicinesInType
        {
            get
            {
                return _medicinesInType;
            }
            set
            {
                _medicinesInType = value;
                OnPropertyChanged(nameof(MedicinesInType));
            }
        }


    }
}
