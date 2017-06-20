using BehaviorModule;
using iSmartSecurity.Models;
using iSmartSecurityView;
using System;
using System.Windows.Threading;

namespace iSmartSecurity.ViewModels
{
    public class AuthenticatedViewModel : WpfBase
    {
        Guid Context { get; set; }
        public String Building { get; set; }
        public String Floor { get; set; }
        public String Department { get; set; }

        public AuthenticatedViewModel(Guid context)
        {
            //for testing only
            ImagePath = @"C:\pic\vh.png";
            this.Context = context;

            foreach (var item in EmployeeVisitorRepository.Employees)
            {
                if (item.UserId == this.Context)
                {
                    this.FullName = item.FirstName + " " + item.LastName;
                    Building = "Building: " + item.PersonLocation.Building;
                    Floor = "Floor: " + item.PersonLocation.Floor;
                    Department = "Department: " + item.PersonLocation.Department;
                    Message = "Please proceed!";
                }
            }

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
        /// User info
        /// </summary>
        private string message;
        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                NotifyPropertyChanged("Message");
            }
        }

        /// <summary>
        /// Sets/Gets full name
        /// </summary>
        private string fullName;
        public string FullName
        {
            get { return fullName; }
            set
            {
                fullName = value;
                NotifyPropertyChanged("FullName");
            }
        }

        /// <summary>
        /// Timer property for the view
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
