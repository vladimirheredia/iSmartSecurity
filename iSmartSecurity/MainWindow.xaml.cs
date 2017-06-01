using Microsoft.ProjectOxford.Face;
using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace iSmartSecurity
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private iSmartSecurityFacade facade = new iSmartSecurityFacade();
        public MainWindow()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Button click event to browse for image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            var openDlg = new Microsoft.Win32.OpenFileDialog();

            openDlg.Filter = "JPEG Image(*.jpg)|*.jpg";
            bool? result = openDlg.ShowDialog(this);

            if (!(bool)result)
            {
                return;
            }

            string filePath = openDlg.FileName;
            Title = "Detecting...";
            facade.getPicture(filePath);
            Uri fileUri = new Uri(filePath);
            BitmapImage bitmapSource = new BitmapImage();

            bitmapSource.BeginInit();
            bitmapSource.CacheOption = BitmapCacheOption.None;
            bitmapSource.UriSource = fileUri;
            bitmapSource.EndInit();

            FacePhoto.Source = bitmapSource;
            FacePhoto.Source = facade.Image;
            Title = String.Format("Detection Finished. {0} face(s) detected", facade.securitySystem.proxy.ImageCount);

        }
    }
}
