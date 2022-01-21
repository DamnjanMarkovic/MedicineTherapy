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
    /// Interaction logic for MedicineView.xaml
    /// </summary>
    public partial class MedicineView : BaseView
    {
        public ICommand MedicineViewSelectMedicine
        {
            get { return (ICommand)GetValue(MedicineViewSelectMedicineProperty); }
            set { SetValue(MedicineViewSelectMedicineProperty, value); }
        }
        public static readonly DependencyProperty MedicineViewSelectMedicineProperty =
            DependencyProperty.Register("MedicineViewSelectMedicine", typeof(ICommand), typeof(MedicineView), new PropertyMetadata(null));

        public MedicineView()
        {
            InitializeComponent();
            ViewName = "Medicine";
        }

        private void BaseView_Loaded(object sender, RoutedEventArgs e)
        {
            dataContext = DataContext as MainViewModel;

            if (dataContext != null)
            {
                MedicineViewSelectMedicine = dataContext.MedicineViewSelectMedicine();
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var senderCombo = sender as ComboBox;
            var selectedMedicine = senderCombo.SelectedItem as Medicine;
            if (MedicineViewSelectMedicine != null)
                MedicineViewSelectMedicine.Execute(selectedMedicine);

        }
    }
}
