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
        //public int NumberOfMedicine { get; set; }
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

        private ObservableCollection<Medicine> _medicinesNamesInType = new ObservableCollection<Medicine>();
        public ObservableCollection<Medicine> MedicinesNamesInType
        {
            get
            {
                return _medicinesNamesInType;
            }
            set
            {
                _medicinesNamesInType = value;
                OnPropertyChanged(nameof(MedicinesNamesInType));
            }
        }


    }
}
