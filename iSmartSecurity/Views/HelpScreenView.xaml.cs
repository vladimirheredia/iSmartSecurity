﻿using iSmartSecurity.ViewModels;
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

namespace iSmartSecurity.Views
{
    /// <summary>
    /// Interaction logic for HelpScreenView.xaml
    /// </summary>
    public partial class HelpScreenView : UserControl
    {
        public HelpScreenView()
        {
            InitializeComponent();
            DataContext = new HelpScreenViewModel();
        }
    }
}
