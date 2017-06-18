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
    public class HelpScreenViewModel : WpfBase
    {
        public HelpScreenViewModel()
        {
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

        /// <summary>
        /// get /set timer
        /// </summary>
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
    }
}
