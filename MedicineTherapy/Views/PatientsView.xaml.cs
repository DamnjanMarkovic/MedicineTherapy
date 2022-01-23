using DataModels;
using MedicineTherapy.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MedicineTherapy.Views
{
    /// <summary>
    /// Interaction logic for PatientsView.xaml
    /// </summary>
    public partial class PatientsView : BaseView
    {
        public ICommand PatientsViewSelectPatient
        {
            get { return (ICommand)GetValue(PatientsViewSelectPatientProperty); }
            set { SetValue(PatientsViewSelectPatientProperty, value); }
        }
        public static readonly DependencyProperty PatientsViewSelectPatientProperty =
            DependencyProperty.Register("PatientsViewSelectPatient", typeof(ICommand), typeof(PatientsView), new PropertyMetadata(null));
        public PatientsView()
        {
            InitializeComponent();
            ViewName = "Patients";
        }
        private void BaseView_Loaded(object sender, RoutedEventArgs e)
        {
            dataContext = DataContext as MainViewModel;
            if (dataContext != null)
            {
                PatientsViewSelectPatient = dataContext.PatientsViewSelectPatient();
                EventUpdateView += UpdateView;
                comboPatientAgeGroups.SelectedIndex = comboPatientAgeGroups.Items.Count -1;
                comboPatiens.SelectedIndex = 0;
            }
        }

        private void UpdateView()
        {
            listMedicineType.Items.Refresh();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var senderCombo = sender as ComboBox;
            var selectedPatient = senderCombo.SelectedItem as Patient;
            if (PatientsViewSelectPatient != null)
                PatientsViewSelectPatient.Execute(selectedPatient);

        }

        private void comboPatientAgeGroups_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboPatiens.Items.Count > 0)
            {
                comboPatiens.SelectedIndex = 0;
            }
            else
            {
                if (PatientsViewSelectPatient != null)
                    PatientsViewSelectPatient.Execute(null);
            }
        }
    }
}
