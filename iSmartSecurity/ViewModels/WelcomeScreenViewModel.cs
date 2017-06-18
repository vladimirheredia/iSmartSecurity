using BehaviorModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Commands;
using iSmartSecurityView;

namespace iSmartSecurity.ViewModels
{
    public class WelcomeScreenViewModel : WpfBase
    {
      public  System.Windows.Input.ICommand OnSelectPerson { get; set; }

      public System.Windows.Input.ICommand OnSelectVisitor { get; set; }

        public WelcomeScreenViewModel()
        {
            OnSelectPerson = new DelegateCommand<object>(OnSelectePersonEvent);

            OnSelectVisitor = new DelegateCommand<object>(OnSelectVisitorEvent);
        }

        /// <summary>
        /// When user selects visitor buttonf open visitor's page
        /// </summary>
        /// <param name="obj"></param>
        private void OnSelectVisitorEvent(object obj)
        {
            VideoNavigationSingleton.Instance.NavigateToPage(VideoNavigationSingleton.ContentPages.VisitorFormView);

        }

        /// <summary>
        /// Navigate to Camera page
        /// </summary>
        /// <param name="obj"></param>
        private void OnSelectePersonEvent(object obj)
        {
            VideoNavigationSingleton.Instance.NavigateToPage(VideoNavigationSingleton.ContentPages.CameraScreen);
        }
    }
}
