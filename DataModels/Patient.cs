using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    public class Patient
    {
        public int PersonID { get; set; }
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
}
