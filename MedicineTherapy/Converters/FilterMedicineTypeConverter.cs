using DataModels;
using MedicineTherapy.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MedicineTherapy.Converters
{

public class FilterMedicineTypeConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var allMedicine = values[0] as ObservableCollection<Medicine>;
            var medicineType = values[1] as MedicineTypeViewModel;

            if (medicineType == null || allMedicine == null) return null;

            return allMedicine.ToList().FindAll(medicine => medicine.MedicineType.ToString() == medicineType.MedicineType);

            //return filteredMedicinesList;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
