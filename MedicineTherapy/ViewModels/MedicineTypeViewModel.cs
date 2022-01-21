using DataModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineTherapy.ViewModels
{
    public class MedicineTypeViewModel
    {
        public string MedicineType { get; set; }
        public string NumberOfMedicine { get; set; }
        public List<string> MedicineList { get; set; } = new List<string>();

        public int NumberOfPatients { get; set; }
        public List<Patient> PatientList { get; set; } = new List<Patient>();
    }
}
