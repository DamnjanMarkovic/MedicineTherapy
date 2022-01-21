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
    /// Interaction logic for NavigationControl.xaml
    /// </summary>
    public partial class NavigationControl : UserControl
    {
        private NavigationViewModel dataContext;
        public NavigationControl()
        {
            InitializeComponent();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            dataContext = DataContext as NavigationViewModel;
            if (dataContext != null)
            {
                dataContext.EventUpdateCurrentView += UpdateSelectedItem;
                listViewsNC.SelectedItem = dataContext.CurrentView;
            }
            Loaded -= UserControl_Loaded;
        }


        private void UpdateSelectedItem(BaseView view)
        {
            listViewsNC.SelectedItem = view;
        }

    }
}
