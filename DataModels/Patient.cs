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

        public ObservableCollection<Medicine>? MedicineList { get; set; } = new ObservableCollection<Medicine>();

    }
}
