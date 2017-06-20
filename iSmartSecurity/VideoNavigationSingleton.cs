using iSmartSecurity.Views;
using System;
using System.Windows.Controls;


namespace iSmartSecurityView
{

    /// <summary>
    /// This class is a singleton / factory to create the views of the application at run time
    /// </summary>
    public class VideoNavigationSingleton
    {
        private static VideoNavigationSingleton instance;
        public ContentControl Content { get; set; }


        /// <summary>
        /// Enum with the name of the views or pages to be used by the app.
        /// </summary>
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

        /// <summary>
        /// This is the Instance of the class
        /// </summary>
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


        /// <summary>
        /// Data context to pass to controls or pages.
        /// </summary>
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
