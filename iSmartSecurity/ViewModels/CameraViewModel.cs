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
using System.Linq;

namespace iSmartSecurity.ViewModels
{
    public class CameraViewModel : WpfBase
    {
        //use facade to access system's module
        private iSmartSecurityFacade facade = new iSmartSecurityFacade();
        public System.Windows.Input.ICommand AuthenticateClick { get; set; }
        public CameraViewModel( Webcam cam, ProgressBar bar)
        {
            //this.DeviceList = comboBox;
            this.WebCam = cam;
            this.Bar = bar;

            AuthenticateClick = new DelegateCommand<object>(AuthenticateEvent);

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
            WebCam.FrameSize = new System.Drawing.Size(200, 200);
            webCam.Width = 350;
            //DeviceList.SelectedIndex = 1;
            webCam.VideoDevice = EncoderDevices.FindDevices(EncoderDeviceType.Video)[1];
            WebCam.StartPreview();            

        }


        /// <summary>
        /// Authenticate event
        /// </summary>
        /// <param name="obj"></param>
        private async void AuthenticateEvent(object obj)
        {
            Bar.Visibility = System.Windows.Visibility.Visible;


            string imagePath = @"C:\WebcamSnapshots";

            //TODO: check error when deleting twice
            DirectoryInfo directory = new DirectoryInfo(imagePath);
            foreach (var item in directory.GetFiles())
            {
                try
                {
                    item.Delete();
                }
                catch (Exception ex)
                {
                    continue;
                }
                
            }

            WebCam.TakeSnapshot();

            var path = directory.GetFiles().OrderByDescending(f=> f.LastWriteTime).First().FullName;
            var isMatchFound = await facade.getPicture(path);
            var faceId = facade.PersistedFaceId;

            if (isMatchFound)
            {
                VideoNavigationSingleton.Instance.NavigateToPage(VideoNavigationSingleton.ContentPages.Authentication, faceId);
            }else
            {
                VideoNavigationSingleton.Instance.NavigateToPage(VideoNavigationSingleton.ContentPages.Unauthenticated);

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
