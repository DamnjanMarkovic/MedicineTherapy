using DataModels;
using MedicineTherapy.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MedicineTherapy.Converters
{
     
    [ValueConversion(typeof(ObservableCollection<Medicine>), typeof(string))]
    public class ObservableCollectionToMedicineNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var medicineArrived = value as ObservableCollection<Medicine>;
            if (medicineArrived != null && medicineArrived.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (string s in medicineArrived.ToList().Select(medicine => medicine.MedicineName)) sb.AppendLine(s);
                return sb.ToString();
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string[] lines = ((string)value).Split(new string[] { @"\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            return lines.ToList<String>();
        }
    }
}
