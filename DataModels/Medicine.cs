using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    public class Medicine
    {
        public int MedicineID { get; set; }
        public string MedicineName { get; set; }
        public MedicineTypeEnum MedicineType { get; set; }

        public ObservableCollection<Patient>? patientList { get; set; } = new ObservableCollection<Patient>();
    }

    public enum MedicineTypeEnum
    {
        NewAntiDiabetic = 1,
        AntiDiabetic = 2,
        Insulin = 3,
        Dislipidemic = 4,
        BloodPresure = 5,
        HeartMedicine = 6,
        Other = 7

    }
}
