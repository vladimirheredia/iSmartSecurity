using iSmartSecurity.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;


namespace iSmartSecurityView
{
    public class VideoNavigationSingleton
    {
        private static VideoNavigationSingleton instance;
        public ContentControl Content { get; set; }

        public enum ContentPages
        {
            WelcomeScreen,
            CameraScreen,
            HelpScreen,
            Authentication,
            Unauthenticated,
            VisitorFormView,
            VisitorView
        }

        public static VideoNavigationSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new VideoNavigationSingleton();
                }
                return instance;
            }
            
        }
        private VideoNavigationSingleton()
        {

        }

        public object PageContext { get; set; }

        public void NavigateToPage(ContentPages page, object context = null)
        {
            switch (page)
            {
                case ContentPages.CameraScreen:
                    CameraView camview = new CameraView();
                    Content.Content = camview;
                    break;
                case ContentPages.Authentication:
                    AuthenticatedView authView = new AuthenticatedView((Guid)context);
                    Content.Content = authView;
                    break;
                case ContentPages.WelcomeScreen:
                    WelcomeScreen welcome = new WelcomeScreen();
                    Content.Content = welcome;
                    break;
                case ContentPages.HelpScreen:
                    HelpScreenView helpScreen = new HelpScreenView();
                    Content.Content = helpScreen;
                    break;
                case ContentPages.Unauthenticated:
                    UnathenticatedView unauthView = new UnathenticatedView();
                    Content.Content = unauthView;
                    break;
                case ContentPages.VisitorFormView:
                    VisitorFormView formView = new VisitorFormView();
                    Content.Content = formView;
                    break;
                case ContentPages.VisitorView:
                    VisitorView vistorView = new VisitorView(context);
                    Content.Content = vistorView;
                    break;
                default:
                    break;
            }

            PageContext = context;

        }
    }
}
