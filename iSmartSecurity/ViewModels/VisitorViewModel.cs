using BehaviorModule;
using iSmartSecurityView;
using System;
using System.Collections.Generic;
using System.Windows.Threading;

namespace iSmartSecurity.ViewModels
{
    public class VisitorViewModel : WpfBase
    {

        private DispatcherTimer timer;
        private int totalSecs = 0;


        public VisitorViewModel(object obj)
        {
            VisitorFullName = ((List<string>)obj)[0];
            EmployeeFullName = ((List<string>)obj)[1];
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }



        /// <summary>
        /// Timer event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// Timer for page
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

        /// <summary>
        /// Property to get / set visitor's full name
        /// </summary>
        private string visitorFullName;
        public string VisitorFullName
        {
            get { return visitorFullName; }
            set
            {
                visitorFullName = value;
                NotifyPropertyChanged("VisitorFullName");
            }
        }


        /// <summary>
        /// Property to get / set employee's full name
        /// </summary>
        private string employeeFullName;
        public string EmployeeFullName
        {
            get { return employeeFullName; }
            set
            {
                employeeFullName = value;
                NotifyPropertyChanged("EmployeeFullName");
            }
        }
    }
}
