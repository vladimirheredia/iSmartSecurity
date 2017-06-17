using iSmartSecurity;
using iSmartSecurity.ViewModels;
using iSmartSecurity.Views;
using Microsoft.Expression.Encoder.Devices;
using Microsoft.ProjectOxford.Face;
using System;
using System.IO;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using WebcamControl;

namespace iSmartSecurityView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        
        public MainWindow()
        {
            InitializeComponent();
            var cam = new WelcomeScreen();
            contentControl.Content = cam;
            VideoNavigationSingleton.Instance.Content = contentControl;
           
        }



    }
}
