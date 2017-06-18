using BehaviorModule;
using iSmartSecurity.Models;
using iSmartSecurityView;
using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSmartSecurity.ViewModels
{
    public class VisitorFormViewModel : WpfBase
    {
        public System.Windows.Input.ICommand FindRegistration { get; set; }


        public VisitorFormViewModel()
        {
            FindRegistration = new DelegateCommand<object>(OnRegistrationEvent);


        }

        /// <summary>
        /// Button event for the form
        /// </summary>
        /// <param name="obj"></param>
        private void OnRegistrationEvent(object obj)
        {
            List<string> empVisitor = new List<string>();
            foreach (var item in EmployeeVisitorRepository.Visitors)
            {
                if (visitorName == (item.FirstName + " " + item.LastName))
                {
                    empVisitor.Add(visitorName);
                    empVisitor.Add(EmployeeName);
                    VideoNavigationSingleton.Instance.NavigateToPage(VideoNavigationSingleton.ContentPages.VisitorView,empVisitor );
                    return;
                }

            }
            //if not found
            VideoNavigationSingleton.Instance.NavigateToPage(VideoNavigationSingleton.ContentPages.HelpScreen);
        }


        /// <summary>
        /// Visitor Name
        /// </summary>
        private string visitorName;
        public string VisitorName
        {
            get { return visitorName; }
            set
            {
                visitorName = value;
                NotifyPropertyChanged("VisitorName");
            }
        }


        /// <summary>
        /// Employee Name
        /// </summary>
        private string employeeName;
        public string EmployeeName
        {
            get { return employeeName; }
            set
            {
                employeeName = value;
                NotifyPropertyChanged("EmployeeName");
            }
        }
    }
}
