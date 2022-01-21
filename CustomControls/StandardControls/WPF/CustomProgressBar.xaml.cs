﻿using System;
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

namespace CustomControls
{
    /// <summary>
    /// Interaction logic for CustomProgressBar.xaml
    /// </summary>
    public partial class CustomProgressBar : ProgressBar
    {

        public CustomProgressBar()
        {
            InitializeComponent();
        }

        private void ProgressBar_Loaded(object sender, RoutedEventArgs e)
        {
            Loaded -= ProgressBar_Loaded;
            this.Height = 50;
        }
    }
}
