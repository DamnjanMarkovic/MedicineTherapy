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
    /// Interaction logic for MedicineTypeView.xaml
    /// </summary>
    public partial class MedicineTypeView : BaseView
    {
        public ICommand MedicineTypeSelect
        {
            get { return (ICommand)GetValue(MedicineTypeSelectProperty); }
            set { SetValue(MedicineTypeSelectProperty, value); }
        }
        public static readonly DependencyProperty MedicineTypeSelectProperty =
            DependencyProperty.Register("MedicineTypeSelect", typeof(ICommand), typeof(MedicineTypeView), new PropertyMetadata(null));

        public MedicineTypeView()
        {
            InitializeComponent();
            ViewName = "Medicine Types";
        }

        private void BaseView_Loaded(object sender, RoutedEventArgs e)
        {
            dataContext = DataContext as MainViewModel;

            if (dataContext != null)
            {
                MedicineTypeSelect = dataContext.MedicineTypeSelect();
                comboMedicineTypes.SelectedIndex = 0;
            }
        }

        private void ComboBox_MedicineTypeCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var senderCombo = sender as ComboBox;
            var selectedMedicineType = senderCombo.SelectedItem as MedicineTypeViewModel;
            if (MedicineTypeSelect != null)
                MedicineTypeSelect.Execute(selectedMedicineType);

        }
    }
}
