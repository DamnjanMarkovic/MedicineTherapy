using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    public class MedicineType
    {
        public MedicineTypeEnum MedicineTyper { get; set; }
        public ObservableCollection<Medicine> MedicineList { get; set; } = new ObservableCollection<Medicine>();

    }
}
