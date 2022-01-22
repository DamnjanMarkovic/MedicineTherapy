using DataModels;
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
    public class FilterPatientAgeConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var allPatients = values[0] as ObservableCollection<Patient>;
            var patientAgeGroup = values[1] as PatientAgeGroupViewModel;
            if (allPatients == null || patientAgeGroup == null) return null;
            return allPatients.ToList().FindAll(patient => patient.PatientAgeGroup == patientAgeGroup.PatientAge);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
