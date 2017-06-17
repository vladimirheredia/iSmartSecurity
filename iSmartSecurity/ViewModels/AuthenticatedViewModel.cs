using BehaviorModule;
using iSmartSecurityView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace iSmartSecurity.ViewModels
{
    class AuthenticatedViewModel : WpfBase
    {

        public AuthenticatedViewModel()
        {
            //for testing only
            ImagePath = @"C:\pic\vh.png";

            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private DispatcherTimer timer;
        private int totalSecs = 0;

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (totalSecs == 5)
            {
                VideoNavigationSingleton.Instance.NavigateToPage(VideoNavigationSingleton.ContentPages.WelcomeScreen);
                timer.Stop();
                return;
            }

            Timer = string.Format("00:0{0}", totalSecs);
            totalSecs++;
        }

        private string _timer;
        public string Timer
        {
            get { return _timer; }

            set
            {
                _timer = value;
                NotifyPropertyChanged("Timer");
            }
        }

        /// <summary>
        /// Set image path
        /// </summary>
        private string imagePath;
        public string ImagePath
        {


            get { return imagePath; }
            set
            {
                imagePath = value;
                NotifyPropertyChanged("ImagePath");
            }

        }
    }
}
