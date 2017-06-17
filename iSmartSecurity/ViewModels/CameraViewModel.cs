using BehaviorModule;
using iSmartSecurity.Views;
using Microsoft.Expression.Encoder.Devices;
using Microsoft.Practices.Prism.Commands;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using WebcamControl;
using System;
using iSmartSecurityView;
using System.Windows.Threading;

namespace iSmartSecurity.ViewModels
{
    public class CameraViewModel : WpfBase
    {
        private iSmartSecurityFacade facade = new iSmartSecurityFacade();
        public System.Windows.Input.ICommand AuthenticateClick { get; set; }
        public CameraViewModel( Webcam cam, ProgressBar bar)
        {
            //this.DeviceList = comboBox;
            this.WebCam = cam;
            this.Bar = bar;

            AuthenticateClick = new DelegateCommand<object>(AuthenticateEvent);

            // Binding binding_1 = new Binding("SelectedValue");
            // binding_1.Source = DeviceList;
            //// WebCam.SetBinding(Webcam.VideoDeviceProperty, binding_1);
            //webCam.VideoDevice 

            // Create directory for saving image files
            string imagePath = @"C:\WebcamSnapshots";

            if (!Directory.Exists(imagePath))
            {
                Directory.CreateDirectory(imagePath);
            }
            // Set some properties of the Webcam control
            //WebcamCtrl.VideoDirectory = videoPath;
            WebCam.ImageDirectory = imagePath;
            WebCam.FrameRate = 30;
            WebCam.FrameSize = new System.Drawing.Size(300, 300);
            // WebcamCtrl.Height = 300;

            // Find available a/v devices
            //var vidDevices = EncoderDevices.FindDevices(EncoderDeviceType.Video);
            //DeviceList.ItemsSource = vidDevices;
            //DeviceList.SelectedIndex = 1;
            webCam.VideoDevice = EncoderDevices.FindDevices(EncoderDeviceType.Video)[1];
            WebCam.StartPreview();            

        }

        private async void AuthenticateEvent(object obj)
        {
            Bar.Visibility = System.Windows.Visibility.Visible;


            string imagePath = @"C:\WebcamSnapshots";

            //TODO: check error when deleting twice
            DirectoryInfo directory = new DirectoryInfo(imagePath);
            foreach (var item in directory.GetFiles())
            {
                item.Delete();
            }

            WebCam.TakeSnapshot();

            var path = directory.GetFiles()[0].FullName;
           var isMatchFound = await facade.getPicture(path);

            if (isMatchFound)
            {
                VideoNavigationSingleton.Instance.NavigateToPage(VideoNavigationSingleton.ContentPages.Authentication);
            }

            Bar.Visibility = System.Windows.Visibility.Hidden;

        }

        private ComboBox deviceList;
        public ComboBox DeviceList
        {
            get { return deviceList; }
            set
            {
                deviceList = value;
                NotifyPropertyChanged("DeviceLIst");
            }
        }

        private Webcam webCam;
        public Webcam WebCam
        {
            get { return webCam; }
            set
            {
                webCam = value;
                NotifyPropertyChanged("WebCam");
            }
        }

        public ProgressBar Bar { get; set; }
    }
}
